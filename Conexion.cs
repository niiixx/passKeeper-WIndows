using System.Data.SQLite;

namespace proyecto
{
    class Conexion // Conexión con SQLite
    {
        public static SQLiteConnection conectar() // DATOS DE LA BBDD - *******Si se cambia de tabla/bbdd cambiar esto*******
        {
            if (!System.IO.File.Exists("bbdd_proyectos.sqlite")) // SI NO EXISTE SE CREA
            {
                SQLiteConnection.CreateFile("bbdd_proyectos.sqlite");

                using (var sqlite2 = new SQLiteConnection("Data Source=bbdd_proyectos.sqlite")) // Rellenamos la nueva tabla
                {
                    sqlite2.Open();
                    string sql = "create table usuarios (id INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT, usuario varchar(45) NOT NULL, " +
                                                        "pass varchar(174) NOT NULL, nombre varchar(45) NOT NULL, pregunta varchar(174), respuesta varchar(174))";
                    SQLiteCommand command = new SQLiteCommand(sql, sqlite2); // CREAR TABLA DE USUARIOS
                    command.ExecuteNonQuery();

                    string sql2 = "create table cuentas (idusuario INTEGER NOT NULL, sitio varchar(45) NOT NULL, user varchar(45) NOT NULL, pass varchar(174) NOT NULL)"; // CREAR TABLA DE CUENTAS
                    SQLiteCommand command2 = new SQLiteCommand(sql2, sqlite2);
                    command2.ExecuteNonQuery();
                }
            }

            var conexion = new SQLiteConnection("Data Source=bbdd_proyectos.sqlite"); // CONECTAMOS
            return conexion;
        }
    }
}
