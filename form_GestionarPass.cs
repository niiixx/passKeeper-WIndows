using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace proyecto
{
    public partial class form_GestionarPass : Form
    {
        public form_GestionarPass()
        {
            InitializeComponent();
        }


        private void btnBorrar_Click(object sender, EventArgs e)
        {
            form_BorrarCuenta frm_log = new form_BorrarCuenta();
            frm_log.Visible = true;
            this.Visible = false;
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            form_EditarCuenta frm_log = new form_EditarCuenta();
            frm_log.Visible = true;
            this.Visible = false;
        }

        private void btnCrear_Click(object sender, EventArgs e)
        {
            form_CrearCuenta frm_log = new form_CrearCuenta();
            frm_log.Visible = true;
            this.Visible = false;
        }


        private void form_GestionarPass_Load(object sender, EventArgs e)
        {
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

        private void btnHome_Click(object sender, EventArgs e) // Volver al login sin registrarse
        {
            form_Home frm_log = new form_Home();
            frm_log.Visible = true;
            this.Visible = false;
        }

        private void linkGestionUsuario_Click(object sender, EventArgs e)
        {
            form_GestionUsuario frm_log = new form_GestionUsuario();
            frm_log.Visible = true;
            this.Visible = false;
        }

        private void linkLogOut_Click(object sender, EventArgs e)
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

        private void pictureBox6_Click(object sender, EventArgs e) // Boton Home
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
