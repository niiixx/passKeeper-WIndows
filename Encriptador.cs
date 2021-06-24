using System;
using System.IO;
using System.Text;

namespace proyecto
{
    class Encriptador // Métodos de encriptar
    {
        public void crear_claves()
        {
            RSACreador rsa = new RSACreador();
            FileStream archivo_publica = new FileStream("clave_publica.xml", FileMode.Create, FileAccess.Write); // Busca la clave pública
            FileStream archivo_privada = new FileStream("clave_privada.xml", FileMode.Create, FileAccess.Write); // Busca la clave privada

            byte[] publica = rsa.CrearPublica(); // Crea la clave
            archivo_publica.Write(publica, 0, publica.Length);
            archivo_publica.Close();

            byte[] privada = rsa.CrearPrivada(); // Crea la clave
            archivo_privada.Write(privada, 0, privada.Length);
            archivo_privada.Close();
        }

        public string encriptar(string texto_a_encriptar) // Encripta
        {

            string xml_archivo = File.ReadAllText("clave_publica.xml");
            byte[] datos_encriptados = RSACreador.encrypt(texto_a_encriptar, xml_archivo);

            return Convert.ToBase64String(datos_encriptados);

        }
        public string deseencriptar(string texto_a_desencriptar) // Desencripta
        {

            string xml_archivo = File.ReadAllText("clave_privada.xml");
            byte[] datos_desencriptados = RSACreador.desencrypt(texto_a_desencriptar, xml_archivo);

            return Encoding.ASCII.GetString(datos_desencriptados);

        }
    }
}
