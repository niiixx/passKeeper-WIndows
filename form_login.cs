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
    public partial class form_login : Form
    {
        public form_login()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e) // Boton de login
        {
            string usuario = txtUsuario.Text;
            string pass = txtPass.Text;

            Controlador control = new Controlador();
            string respuesta_login = control.ctrlLogin(usuario, pass); // Validacion de todos los campos

            if(respuesta_login.Length > 0)
                MessageBox.Show(respuesta_login, "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else // LOGIN CORRECTO
            {
                form_Home form_cargar = new form_Home(); // INSTANCIAMOS EL FORM DEL PROGRAMA
                form_cargar.Visible = true; // MOSTRAMOS EL NUEVO
                this.Visible = false; // QUITAMOS EL LOGIN
            }
        }

        private void btn_nocuenta_Click(object sender, EventArgs e)
        {
            frmRegistro form_registro = new frmRegistro();
            form_registro.Visible = true;
            this.Visible = false;
        }

        private void btnRecuperar_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            form_recuperar frm_rec = new form_recuperar();
            frm_rec.Visible = true;
            this.Visible = false;
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnMinimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void txtUsuario_Enter(object sender, EventArgs e)
        {
            if (txtUsuario.Text == "Usuario")
                txtUsuario.Text = "";
        }

        private void txtUsuario_Leave(object sender, EventArgs e)
        {
            if (txtUsuario.Text == "")
                txtUsuario.Text = "Usuario";
        }

        private void txtPass_Enter(object sender, EventArgs e)
        {
            if (txtPass.Text == "Contraseña")
            {
                txtPass.Text = "";
                txtPass.UseSystemPasswordChar = true;
            }
        }

        private void txtPass_Leave(object sender, EventArgs e)
        {
            if (txtPass.Text == "")
            {
                txtPass.UseSystemPasswordChar = false;
                txtPass.Text = "Contraseña";
            }
                
        }

        private void pictLock_Click(object sender, EventArgs e) // Mostrar pass con *
        {
            if (txtPass.Text != "Contraseña")
            {
                txtPass.UseSystemPasswordChar = false;
                pictLock.Visible = false;
                pctUnloc.Visible = true;
            }
        }

        private void pctUnloc_Click(object sender, EventArgs e) // Mostrar pass sin *
        {
            if (txtPass.Text != "Contraseña")
            {
                txtPass.UseSystemPasswordChar = true;
                pictLock.Visible = true;
                pctUnloc.Visible = false;
            }
        }

        /* HOVERS */
        private void pictureBox2_MouseHover(object sender, EventArgs e) 
        {
            lblUsuarioHover.Visible = true;
        }

        private void pictureBox2_MouseLeave(object sender, EventArgs e)
        {
            lblUsuarioHover.Visible = false;
        }

        private void pctUnloc_MouseHover(object sender, EventArgs e)
        {
            lblPassHover.Visible = true;
        }

        private void pctUnloc_MouseLeave(object sender, EventArgs e)
        {
            lblPassHover.Visible = false;
        }

        private void pictLock_MouseHover(object sender, EventArgs e)
        {
            lblPassHover.Visible = true;
        }

        private void pictLock_MouseLeave(object sender, EventArgs e)
        {
            lblPassHover.Visible = false;
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
