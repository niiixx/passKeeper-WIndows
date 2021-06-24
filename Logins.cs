namespace proyecto
{
    class Logins // Clase con los datos de usuario
    {
        int idLogin;
        string user;
        string pass;
        string sitio;

        public int IdLogin { get => idLogin; set => idLogin = value; }
        public string User { get => user; set => user = value; }
        public string Pass { get => pass; set => pass = value; }
        public string Sitio { get => sitio; set => sitio = value; }
    }
}
