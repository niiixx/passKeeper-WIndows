using System.Data.SQLite;

namespace proyecto
{
    class Modelo // INSTRUCCIONES SQL
    { // NOTA IMPOTANTE - Siempre que se ejecute una conexión/reader es necesario luego cerrarlo. Si no = ERROR SEGURO
        public void registro(Usuarios usuario) // Registrar usuario
        {
            SQLiteConnection conexion = Conexion.conectar();
            conexion.Open();
            SQLiteCommand insertSQL = new SQLiteCommand("INSERT INTO usuarios (usuario, pass, nombre, pregunta, respuesta)" + // comando de insercción - *******Si se cambia de tabla/bbdd cambiar esto*******
                                                        "VALUES(@usuario,@pass,@nombre,@pregunta,@respuesta)", conexion);
            insertSQL.Parameters.AddWithValue("@usuario", usuario.Usuario);
            insertSQL.Parameters.AddWithValue("@pass", usuario.Pass);
            insertSQL.Parameters.AddWithValue("@nombre", usuario.Nombre);
            insertSQL.Parameters.AddWithValue("@pregunta", usuario.Tpreg);
            insertSQL.Parameters.AddWithValue("@respuesta", usuario.Respreg);

            insertSQL.ExecuteNonQuery();
            conexion.Close();
        }

        public void update_usuario(Usuarios usuario) // Cambiar datos de usuario
        {
            SQLiteConnection conexion = Conexion.conectar();
            // comando de UPDATE - *******Si se cambia de tabla/bbdd cambiar esto*******
            conexion.Open();
            using (SQLiteCommand updateSQL = new SQLiteCommand("UPDATE usuarios SET usuario=@usuario, pass=@pass, nombre=@nombre, pregunta=@pregunta, respuesta=@respuesta " +
                                                        "WHERE id=@idusuario", conexion))
            {
                updateSQL.Parameters.AddWithValue("@usuario", usuario.Usuario);
                updateSQL.Parameters.AddWithValue("@pass", usuario.Pass);
                updateSQL.Parameters.AddWithValue("@nombre", usuario.Nombre);
                updateSQL.Parameters.AddWithValue("@pregunta", usuario.Tpreg);
                updateSQL.Parameters.AddWithValue("@respuesta", usuario.Respreg);
                updateSQL.Parameters.AddWithValue("@idusuario", Sesion.id);

                updateSQL.ExecuteNonQuery();
            }
            conexion.Close();
        }

        public void update_cuenta(Logins Log, string antiguo_usuario) // Cambiar datos de usuario
        {
            SQLiteConnection conexion = Conexion.conectar();
            // comando de UPDATE - *******Si se cambia de tabla/bbdd cambiar esto*******
            conexion.Open();
            using (SQLiteCommand updateSQL = new SQLiteCommand("UPDATE cuentas SET idusuario=@idusuario, sitio=@sitio, user=@user, pass=@pass WHERE user=@user_antiguo " +
                                                                "AND sitio=@sitio_antiguo", conexion))
            {
                updateSQL.Parameters.AddWithValue("@idusuario", Log.IdLogin);
                updateSQL.Parameters.AddWithValue("@sitio", Log.Sitio);
                updateSQL.Parameters.AddWithValue("@user", Log.User);
                updateSQL.Parameters.AddWithValue("@pass", Log.Pass);
                updateSQL.Parameters.AddWithValue("@user_antiguo", antiguo_usuario);
                updateSQL.Parameters.AddWithValue("@sitio_antiguo", Log.Sitio);

                updateSQL.ExecuteNonQuery();
            }
            conexion.Close();
        }

        public void registro_cuentas(Logins login) // Registrar cuenta
        {
            SQLiteConnection conexion = Conexion.conectar();
            conexion.Open();
            SQLiteCommand insertSQL = new SQLiteCommand("INSERT INTO cuentas(sitio, pass, user, idusuario)" + // comando de insercción - *******Si se cambia de tabla/bbdd cambiar esto*******
                                                       "VALUES(@sitio,@pass,@user,@idusuario)", conexion);

            insertSQL.Parameters.AddWithValue("@sitio", login.Sitio);
            insertSQL.Parameters.AddWithValue("@pass", login.Pass);
            insertSQL.Parameters.AddWithValue("@user", login.User);
            insertSQL.Parameters.AddWithValue("@idusuario", login.IdLogin);

            insertSQL.ExecuteNonQuery();
            conexion.Close();
        }

        public void eliminar_cuentas(Logins login) // Eliminar cuenta
        {
            SQLiteConnection conexion = Conexion.conectar();
            conexion.Open();
            SQLiteCommand insertSQL = new SQLiteCommand("DELETE from cuentas where sitio=@sitio AND user=@usuario", conexion);

            insertSQL.Parameters.AddWithValue("@sitio", login.Sitio);
            insertSQL.Parameters.AddWithValue("@usuario", login.User);

            insertSQL.ExecuteNonQuery();
            conexion.Close();
        }

        public bool existe_usuario(string usuario) // CHECK PARA REGISTRO - DEVUELVE SI EXISTE O NO
        {
            SQLiteDataReader reader;
            SQLiteConnection conexion = Conexion.conectar();
            conexion.Open();
            // *******Si se cambia de tabla/bbdd cambiar esto*******
            SQLiteCommand comando = new SQLiteCommand("SELECT id FROM usuarios WHERE usuario=@usuario", conexion); // comando de búsqueda(solo queremos saber si existe el usuario)

            comando.Parameters.AddWithValue("@usuario", usuario);
            
            reader = comando.ExecuteReader();

            if (reader.HasRows) // Hacemos una búsqueda completa
            {
                reader.Close();
                conexion.Close();
                return true; //USUARIO YA EXISTE
            }
            else
            {
                reader.Close();
                conexion.Close();
                return false; //USUARIO NO EXISTE
            }
        }

        public bool existe_cuenta(string sitio, string user) // CHECK PARA BORRAR CUENTA - MIRA SI EXISTE
        {
            SQLiteDataReader reader;
            SQLiteConnection conexion = Conexion.conectar();
            conexion.Open();
            // *******Si se cambia de tabla/bbdd cambiar esto*******
            SQLiteCommand comando = new SQLiteCommand("SELECT idusuario FROM cuentas WHERE sitio=@sitio AND user=@user", conexion); // comando de búsqueda(solo queremos saber si existe el usuario)

            comando.Parameters.AddWithValue("@sitio", sitio);
            comando.Parameters.AddWithValue("@user", user);

            reader = comando.ExecuteReader();

            if (reader.HasRows) // Hacemos una búsqueda completa
            {
                reader.Close();
                conexion.Close();
                return true; //CUENTA EXISTE
            }
            else
            {
                reader.Close();
                conexion.Close();
                return false; //CUENTA NO EXISTE
            }
        }

        public Logins devuelve_cuenta(string sitio, string user) // Devuelve la cuenta para editar/borrar
        {
            Logins log = null;
            SQLiteDataReader reader;
            SQLiteConnection conexion = Conexion.conectar();
            conexion.Open();
            // *******Si se cambia de tabla/bbdd cambiar esto*******
            SQLiteCommand comando = new SQLiteCommand("SELECT idusuario, sitio, user, pass FROM cuentas WHERE sitio=@sitio AND user=@user AND idusuario=@idusuario", conexion); // comando de búsqueda(solo queremos saber si existe el usuario)

            comando.Parameters.AddWithValue("@sitio", sitio);
            comando.Parameters.AddWithValue("@user", user);
            comando.Parameters.AddWithValue("@idusuario", Sesion.id);

            reader = comando.ExecuteReader(); // Comando de búsqueda

            while (reader.Read()) // Leemos todos fila a fila 
            {
                log = new Logins();
                log.IdLogin = int.Parse(reader["idusuario"].ToString()); // Convertimos el id(int) a string
                log.Sitio = reader["sitio"].ToString();
                log.User = reader["user"].ToString();
                log.Pass = reader["pass"].ToString();
            }

            reader.Close();
            conexion.Close();
            return log;
        }

        public Usuarios existe_usuario_login(string usuario) // CHECK PARA LOGIN - DEVUELVE EL USUARIO
        {
            Usuarios usu = null;
            SQLiteDataReader reader;
            SQLiteConnection conexion = Conexion.conectar();
            conexion.Open();
            // *******Si se cambia de tabla/bbdd cambiar esto*******
            SQLiteCommand selectSQL = new SQLiteCommand("SELECT id, nombre, pass, pregunta, respuesta FROM usuarios WHERE usuario=@usuario", conexion); // comando de búsqueda (queremos saber todos los datos del usuario)
            selectSQL.Parameters.AddWithValue("@usuario", usuario);

            reader = selectSQL.ExecuteReader(); // Comando de búsqueda

            while (reader.Read()) // Leemos todos fila a fila // *******Si se cambia de tabla/bbdd cambiar esto*******
            {
                usu = new Usuarios();
                usu.Idusuarios = int.Parse(reader["id"].ToString()); // Convertimos el id(int) a string
                usu.Nombre = reader["nombre"].ToString();
                usu.Pass = reader["pass"].ToString();
                usu.Tpreg = reader["pregunta"].ToString();
                usu.Respreg = reader["respuesta"].ToString();
            }

            reader.Close();
            conexion.Close();
            return usu;
        }

    }

}
