using System;
using System.Security.Cryptography;
using System.Text;

namespace proyecto
{
    class RSACreador
    {
        public RSACryptoServiceProvider RSAService { get; set; } // Instancia de la clase que nos permite toda la encriptación

        public RSACreador()
        {
            this.RSAService = new RSACryptoServiceProvider();
        }

        public byte[] CrearPublica() // Creación de la llave PÚBLICA - ENCRIPTAR
        {
            string xmlPublica = this.RSAService.ToXmlString(false);
            return Encoding.ASCII.GetBytes(xmlPublica);
        }

        public byte[] CrearPrivada() // Creación de la llave PRIVADA - DESENCRIPTAR
        {
            string xmlPrivada = this.RSAService.ToXmlString(true);
            return Encoding.ASCII.GetBytes(xmlPrivada);
        }

        public static byte[] encrypt(string texto_noencriptado, string xmlPublica) // Método de encriptación
        {
            RSACryptoServiceProvider RSA = new RSACryptoServiceProvider(2048);
            RSA.FromXmlString(xmlPublica);
            byte[] texto_encriptado = RSA.Encrypt(Encoding.ASCII.GetBytes(texto_noencriptado), false);
            return texto_encriptado;
        }

        public static byte[] desencrypt(string texto_encriptado, string xmlPrivada) // Método de desencriptación
        {
            RSACryptoServiceProvider RSA = new RSACryptoServiceProvider(2048);
            RSA.FromXmlString(xmlPrivada);
            byte[] texto_desencriptado = RSA.Decrypt(Convert.FromBase64String(texto_encriptado), false);
            return texto_desencriptado;
        }
    }
}
