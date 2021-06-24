namespace proyecto
{
    class Usuarios // *******Si se cambia de tabla/bbdd cambiar esto*******
    {   // Clase con las respuestas de registro 
        int idusuarios;
        string usuario;
        string pass;
        string conPass;
        string nombre;
        string tpreg;
        string respreg;

        public int Idusuarios { get => idusuarios; set => idusuarios = value; }
        public string Usuario { get => usuario; set => usuario = value; }
        public string Pass { get => pass; set => pass = value; }
        public string ConPass { get => conPass; set => conPass = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public string Tpreg { get => tpreg; set => tpreg = value; }
        public string Respreg { get => respreg; set => respreg = value; }
    }
}
