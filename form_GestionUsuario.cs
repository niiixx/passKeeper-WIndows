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
    public partial class form_GestionUsuario : Form
    {
        public form_GestionUsuario()
        {
            InitializeComponent();
        }
        private void form_GestionUsuario_Load(object sender, EventArgs e) // Cargamos todos los valores de la sesión del usuario
        {
            txtUsuario.Text = Sesion.usuario;
            txtNombre.Text = Sesion.nombre;
            txtPass.Text = Sesion.pass;
            txtPreg.Text = Sesion.pregunta;
            txtResp.Text = Sesion.respuesta;
            lblNombre.Text = "Buenas, " + Sesion.nombre + "!"; // Mostramos el usuario con mensaje de bienvenida
        }

        private void btn_Actualizar_Click(object sender, EventArgs e)
        {
            Usuarios usuario = new Usuarios();
            usuario.Usuario = txtUsuario.Text;
            usuario.Pass = txtPass.Text;
            usuario.ConPass = txtPass.Text;
            usuario.Nombre = txtNombre.Text;
            usuario.Tpreg = txtPreg.Text;
            usuario.Respreg = txtResp.Text;

            Controlador control = new Controlador();
            string respuesta_registro = control.ctrlRegistro(usuario, 1); // Validacion de que A no exista en el sistema B esten todos los campos rellenos

            if (respuesta_registro.Length > 0) // Si hay mensaje es que hay error - Mensaje de error y no se registra
                MessageBox.Show(respuesta_registro, "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
            {
                MessageBox.Show("Datos actualizados correctamente!. Se cerrará sesión para efectuar los cambios", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Information); // Good
                form_login frm_log = new form_login();
                frm_log.Visible = true;
                this.Visible = false;
            }
        }
        private void linkGestionPass_Click(object sender, EventArgs e)
        {
            form_GestionarPass frm_log = new form_GestionarPass();
            frm_log.Visible = true;
            this.Visible = false;
        }

        private void txtPass_TextChanged(object sender, EventArgs e)
        {
            Controlador control = new Controlador();
            int peso = 0;
            peso = control.validarPass(txtPass.Text);
            if (peso == 0)
                lblSeguirdad.Visible = false;
            if (peso < 20 && peso > 0)
            {
                lblSeguirdad.Visible = true;
                lblSeguirdad.Text = "Seguridad muy débil";
            }
            if (peso < 30 && peso >= 20)
            {
                lblSeguirdad.Visible = true;
                lblSeguirdad.Text = "Seguridad débil";
            }
            if (peso < 40 && peso >= 30)
            {
                lblSeguirdad.Visible = true;
                lblSeguirdad.Text = "Seguridad media";
            }
            if (peso < 50 && peso >= 40)
            {
                lblSeguirdad.Visible = true;
                lblSeguirdad.Text = "Seguridad alta";
            }
            if (peso >= 50)
            {
                lblSeguirdad.Visible = true;
                lblSeguirdad.Text = "Seguridad muy alta";
            }
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnMinimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
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

        private void btnHome_Click(object sender, EventArgs e) // Volver al login sin registrarse
        {
            form_Home frm_log = new form_Home();
            frm_log.Visible = true;
            this.Visible = false;
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
