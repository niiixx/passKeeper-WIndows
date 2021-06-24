using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace proyecto
{
    public partial class form_Home : Form
    {
        public form_Home()
        {
            InitializeComponent();
        }

        private void form_Home_Load(object sender, EventArgs e) // Nada más cargar el form se ejecuta
        {
            int color = 1;
            string pass = "";
            dataCuentas.Rows.Clear(); // Limpiamos la tabla por si hay datos residuales
            SQLiteConnection conexion = Conexion.conectar();
            Encriptador encriptador = new Encriptador();
            conexion.Open();

            SQLiteCommand selectSQL = new SQLiteCommand("Select * From cuentas WHERE idusuario like @idusuario", conexion); // Realizamos la búsqueda en la tabla de cuentas

            selectSQL.Parameters.AddWithValue("@idusuario", Sesion.id);

            using (SQLiteDataReader read = selectSQL.ExecuteReader())
            {
                while (read.Read())
                {
                    pass = read.GetValue(read.GetOrdinal("pass")).ToString(); // Pasamos la pass a string para desencriptarla luego

                    dataCuentas.Rows.Add(new object[] { // Rellenamos la tabla en órden
                    read.GetValue(read.GetOrdinal("sitio")),  
                    read.GetValue(read.GetOrdinal("user")),
                    encriptador.deseencriptar(pass) // Pass se muestra desencriptada
                    });
                }
                read.Close();
            }
            conexion.Close();

            foreach (DataGridViewRow row in dataCuentas.Rows) // Cambiamos color de las pares (Porque? Para que se te cansen menos los ojos al ver la tabla)
            {
                if(color % 2 == 0)
                {
                    row.DefaultCellStyle.BackColor = Color.LemonChiffon;
                }
                color++;
            }
                    
            lblNombre.Text = "Buenas, " + Sesion.nombre + "!"; // Mostramos el usuario con mensaje de bienvenida   
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnMinimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void txtFiltro_KeyPress(object sender, KeyPressEventArgs e) // Filtrado
        {
            int i = 0, j = 0;
            string contenido = "";
            int validador = 0;

            if (txtFiltro.Text != "") // Validamos si esta relleno
            {
                if (e.KeyChar == Convert.ToChar(Keys.Enter)) // Solo se aplica el filtro si se ha pulsado ENTER
                {
                    foreach (DataGridViewRow r in dataCuentas.Rows) // Recorremos las columnas
                    {
                        for (i = 0; i < 3; i++) // Primero recorremos cada fila
                        {
                            contenido = Convert.ToString(dataCuentas.Rows[j].Cells[i].Value); // Guardamos el contenido de cada fila
                            if (contenido == txtFiltro.Text) // SI alguno coincide con el valor del filtro = es columna es buena
                                validador = 1;
                        }

                        if (validador == 1) // Si columna es buena se muestra
                            r.Visible = true;
                        else // No se muestras si no coinciden los filtros
                            r.Visible = false;
                        j++;
                        validador = 0;
                    }
                }
            }
            else
            {
                foreach (DataGridViewRow r in dataCuentas.Rows)
                {
                    r.Visible = true;
                }
            }
        }
        private void linkLogOut_Click(object sender, EventArgs e) // Log out - mostramos mensaje de seguridad
        {
            DialogResult Result;
            Result = MessageBox.Show("¿Estás seguro de cerrar sesión?", "AVISO", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
            if (Result == DialogResult.OK)
            {
                form_login form_cargar = new form_login(); // INSTANCIAMOS EL FORM DEL PROGRAMA
                form_cargar.Visible = true; // MOSTRAMOS EL NUEVO
                this.Visible = false; // QUITAMOS EL LOGIN
            }
        }

        private void linkGestionPass_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            form_GestionarPass frm_log = new form_GestionarPass();
            frm_log.Visible = true;
            this.Visible = false;
        }

        private void linkGestionUsuario_Click(object sender, EventArgs e)
        {
            form_GestionUsuario frm_log = new form_GestionUsuario();
            frm_log.Visible = true;
            this.Visible = false;
        }

        private void btnHome_Click(object sender, EventArgs e)
        {
            form_Home frm_Cargar = new form_Home();
            frm_Cargar.Visible = true;
            this.Visible = false;
        }

        // MOVIENTO DEL FORM SIN BORDES 
        private int m, mx, my;
        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            m = 1;
            mx = e.X;
            my = e.Y;
        }

        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            if (m == 1)
                this.SetDesktopLocation(MousePosition.X - mx, MousePosition.Y - my);
        }

        private void panel1_MouseUp(object sender, MouseEventArgs e)
        {
            m = 0;
        }
    }
}
