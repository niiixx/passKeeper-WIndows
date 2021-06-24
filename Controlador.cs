using System;
using System.Linq;

namespace proyecto
{
    class Controlador // Validaciones
    {
        public string ctrlRegistro(Usuarios usuario, int opcion) // VALIDACION REGISTRO = 0 // VALIDACION UPDATE USUARIO = 1
        {
            Modelo modelo = new Modelo();
            string respuesta = "";
            Encriptador encriptador = new Encriptador();

            if (usuario.Usuario.Contains("?") || 
                usuario.Usuario.Contains(" ") || 
                usuario.Usuario.Contains("¿") ||
                usuario.Usuario.Contains(":")) // NO SE PERMITEN CARACTERES ESPECIALES
                    respuesta = "El nombre de usuario no puede contener signos de interrogación, dos puntos ni espacios.";
            else
            {
                // VALIDAMOS SI ESTAN VACIOS
                if (string.IsNullOrEmpty(usuario.Usuario) || // *******Si se cambia de tabla/bbdd cambiar esto*******
                    string.IsNullOrEmpty(usuario.Pass) ||
                    string.IsNullOrEmpty(usuario.ConPass) ||
                    string.IsNullOrEmpty(usuario.Nombre) ||
                    string.IsNullOrEmpty(usuario.Tpreg) ||
                    string.IsNullOrEmpty(usuario.Respreg))
                        respuesta = "Debe de llenar todos los campos"; // VALIDAMOS QUE TODO SE RELLENE
                else
                {
                    if (usuario.Pass != usuario.ConPass) // VALIDAMOS QUE LAS CONTRASEÑAS SEAN IGUALES
                        respuesta = "Las contraseñas deben de coincidir";
                    else
                    {
                        if (validarPass(usuario.Pass) < 20) // VALIDAMOS LA LONGITUD DE LA CONTRASEÑA
                            respuesta = "No se puede usar una contraseña tan débil. La contraseña tiene que tener al menos 8 carácteres, mayúsuclas y minúsculas.";
                        else // VALIDAMOS QUE EL USUARIO NO EXISTA YA EN LA BBDD
                        {
                            if (modelo.existe_usuario(usuario.Usuario) == true && opcion == 0) // SIGNIFICA QUE EL USER YA EXISTE - Solo se aplica para nuevos registros
                                respuesta = "El usuario ya existe en el sistema";
                            else
                            {
                                usuario.Pass = encriptador.encriptar(usuario.Pass); // LA CONTRASEÑA SE GUARDA EN LA BASE DE DATOS ENCRIPTADA
                                usuario.Tpreg = encriptador.encriptar(usuario.Tpreg); // Encriptamos la pregunta
                                usuario.Respreg = encriptador.encriptar(usuario.Respreg); // Encriptamos la respuesta

                                if (opcion == 0) // Registro
                                    modelo.registro(usuario); // SI HA LLEGADO HASTA AQUÍ = TODO OK - LE REGISTRAMOS
                                if (opcion == 1) // Update
                                    modelo.update_usuario(usuario); // SI HA LLEGADO HASTA AQUÍ = TODO OK - LE UPDATEAMOS

                            }
                        }
                    }
                }
            }
            return respuesta;
        }

        public string ctrlLogin(string usuario, string pass) // VALIDACION LOGIN
        {
            Modelo modelo = new Modelo();
            string respuesta = "";
            Encriptador encriptador = new Encriptador();

            Usuarios usuario_introducido = null;

            if(string.IsNullOrEmpty(usuario) || string.IsNullOrEmpty(pass))
                respuesta = "Debe de llenar todos los campos"; // VALIDAMOS QUE TODO SE RELLENE
            else
            {
                usuario_introducido = modelo.existe_usuario_login(usuario); // BUSCAMOS SI EXISTE

                if(usuario_introducido == null) // NO EXISTE
                    respuesta = "El usuario no existe en el sistema";

                else // SI EXISTE, EL MÉTODO existe_usuario_login nos devuelve el usuario y su pass
                { // AHORA HAY QUE COMPROBAR QUE COINCIDAN LAS CONTRASEÑAS POR TANTO DESCIFRAMOS LA CONTRASEÑA DE LA BBDD Y LA COMPARAMOS CON LA QUE SE HA INTRODUCIDO

                    if(encriptador.deseencriptar(usuario_introducido.Pass) != pass) // No coinciden
                    {
                        respuesta = "Las contraseñas no es correcta.";
                    }
                    else
                    {
                        Sesion.id = usuario_introducido.Idusuarios;
                        Sesion.usuario = usuario;
                        Sesion.nombre = usuario_introducido.Nombre;
                        Sesion.pass = encriptador.deseencriptar(usuario_introducido.Pass);
                        Sesion.respuesta = encriptador.deseencriptar(usuario_introducido.Respreg);
                        Sesion.pregunta = encriptador.deseencriptar(usuario_introducido.Tpreg);
                    }
                }
            }
            return respuesta;
        }

        public string recuperar_pass(string usuario, string respuesta) // Permite al usuario recuperar la pass mediante respuesta de seguridad
        {
            string pass = "";
            Modelo modelo = new Modelo();
            Encriptador encriptador = new Encriptador();
            Usuarios usuario_recuperar = null;

            if (string.IsNullOrEmpty(usuario) || string.IsNullOrEmpty(respuesta))
                pass = "Debe de llenar todos los campos";
            else
            {
                usuario_recuperar = modelo.existe_usuario_login(usuario); // BUSCAMOS SI EXISTE
                if (usuario_recuperar == null) // NO EXISTE
                    pass = "El usuario no existe en el sistema";

                else // SI EXISTE, EL MÉTODO existe_usuario_login nos devuelve el usuario y su pass
                { // AHORA HAY QUE COMPROBAR QUE COINCIDAN LAS CONTRASEÑAS POR TANTO DESCIFRAMOS LA CONTRASEÑA DE LA BBDD Y LA COMPARAMOS CON LA QUE SE HA INTRODUCIDO

                    if (encriptador.deseencriptar(usuario_recuperar.Respreg) != respuesta) // No coinciden
                        pass = "Las respuestas no coinciden.";
                    else
                        pass = encriptador.deseencriptar(usuario_recuperar.Pass);
                }
            }
            return pass;
        }

        public string ctrlSitio(Logins login) // Validación de crear cuenta
        {
            Modelo modelo = new Modelo();
            string respuesta = "";
            // VALIDAMOS SI ESTAN VACIOS
            if (string.IsNullOrEmpty(login.User) || // *******Si se cambia de tabla/bbdd cambiar esto*******
                string.IsNullOrEmpty(login.Pass) ||
                string.IsNullOrEmpty(login.Sitio))
            {
                respuesta = "Debe de llenar todos los campos"; // VALIDAMOS QUE TODO SE RELLENE
            }
            else
            {
                if(validarPass(login.Pass) < 30)
                    respuesta = "No se puede usar una contraseña tan débil. La contraseña tiene que tener al menos 8 carácteres, mayúsuclas y minúsculas.";
                else
                {
                    modelo.registro_cuentas(login);
                    respuesta = "Sus datos han sido guardados!";
                }
            }
            return respuesta;
        }

        public int validarPass(string pass) // Validación de la seguridad de la pass
        {
            // Devolvemos la calidad por peso
            int contador = 0;
            // Mas de 8 caracteres
            if (pass.Length >= 8) contador = contador + 10;
            // Contiene numeros
            if (pass.Any(char.IsDigit)) contador = contador + 10;
            // Contiene mayusculas
            if (pass.Any(char.IsUpper)) contador = contador + 10;
            // Contiene minusculas
            if (pass.Any(char.IsLower)) contador = contador + 5;
            // Contiene simbolos
            var values = new[] {"¡", "!", "#", "$", "%", "&", "/", "(", ")", "=", "?", "¿", ".", "-", "_", ":", ",", ";", "*", "+", "<", ">", "||" };
            if (values.Any(pass.Contains))
            {
                contador = contador + 10;
            }
            return contador;
        }

        public string crearContra(int n) // Algoritmo de creación de pass
        {
            // Valor de retorno
            string password = "";
            // Declaramos un Guid
            Guid miguid = Guid.NewGuid();
            // Tipo string
            string pass = Convert.ToBase64String(miguid.ToByteArray());
            // Corregimos
            pass = pass.Replace("=", ".").Replace("+", "!");
            // Generamos
            password = pass.Substring(0, n);
            // Retornamos

            if (validarPass(password) < 30) // Validamos que SIEMPRE sean seguras
                password = crearContra(n);

            return password;
        }
    }
}
