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
    public partial class frmRegistro : Form
    {
        public frmRegistro()
        {
            InitializeComponent();
        }

        private void btn_Registro_Click(object sender, EventArgs e) // Registrartse
        {
            Usuarios usuario = new Usuarios();
            usuario.Usuario = txtUsuario.Text;
            usuario.Pass = txtPass.Text;
            usuario.ConPass = txtConPass.Text;
            usuario.Nombre = txtNombre.Text;

            // La pregunta varia si es propia o predefinida
            if (checkBox1.Checked == true) 
                usuario.Tpreg = txtPreguntaPropia.Text;
            else
                usuario.Tpreg = cmbPreg.Text;

            usuario.Respreg = txtPreg.Text;

            Controlador control = new Controlador();
            string respuesta_registro = control.ctrlRegistro(usuario, 0); // Validacion de que A no exista en el sistema B esten todos los campos rellenos

            if(respuesta_registro.Length > 0) // Si hay mensaje es que hay error - Mensaje de error y no se registra
                MessageBox.Show(respuesta_registro, "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
            {
                MessageBox.Show("Registro completado correctamente!", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Information); // Good

                form_login form_cargar = new form_login(); // Cargar login
                form_cargar.Visible = true;
                this.Visible = false;
            }
        }

        private void txtPass_TextChanged(object sender, EventArgs e) // Mostramos cúan segura es la pass
        {
            Controlador control = new Controlador();
            int peso = 0;
            peso = control.validarPass(txtPass.Text);
            if (txtPass.Text != "Contraseña")
            {
                if (peso == 0)
                    lblSeguridad.Visible = false;
                if (peso < 20 && peso > 0)
                {
                    lblSeguridad.Visible = true;
                    lblSeguridad.Text = "Seguridad muy débil";
                }
                if (peso < 30 && peso >= 20)
                {
                    lblSeguridad.Visible = true;
                    lblSeguridad.Text = "Seguridad débil";
                }
                if (peso < 40 && peso >= 30)
                {
                    lblSeguridad.Visible = true;
                    lblSeguridad.Text = "Seguridad media";
                }
                if (peso < 50 && peso >= 40)
                {
                    lblSeguridad.Visible = true;
                    lblSeguridad.Text = "Seguridad alta";
                }
                if (peso >= 50)
                {
                    lblSeguridad.Visible = true;
                    lblSeguridad.Text = "Seguridad muy alta";
                }
            }
        }

        private void cmbPreg_SelectionChangeCommitted(object sender, EventArgs e) // Pregunta predeterminada
        {
            if (cmbPreg.SelectedItem != null)
            {
                txtPreg.Visible = true;
                lineShape5.Visible = true;
                pictureBox5.Visible = true;
            }
            else
            {
                txtPreg.Visible = false;
                lineShape5.Visible = false;
                pictureBox5.Visible = false;
            }
        }

        private void btnMinimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void pictureBox2_Click(object sender, EventArgs e) // Volver al login sin registrarse
        {
            form_login frm_log = new form_login();
            frm_log.Visible = true;
            this.Visible = false;
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

        private void txtConPass_Enter(object sender, EventArgs e)
        {
            if (txtConPass.Text == "Confirmar contraseña")
            {
                txtConPass.Text = "";
                txtConPass.UseSystemPasswordChar = true;
                label1.Visible = false;

            }
        }

        private void txtConPass_Leave(object sender, EventArgs e)
        {
            if (txtConPass.Text == "")
            {
                txtConPass.Text = "Confirmar contraseña";
                txtConPass.UseSystemPasswordChar = false;
            }
            else
            {
                if (txtPass.Text != txtConPass.Text)
                {
                    label1.Visible = true;
                    label1.Text = "Las contraseñas no coinciden";
                }
                if (txtPass.Text == txtConPass.Text)
                    label1.Text = "Las contraseñas coinciden";
            }
        }

        private void txtPreg_Enter(object sender, EventArgs e)
        {
            if (txtPreg.Text == "Respuesta")
                txtPreg.Text = "";
        }

        private void txtPreg_Leave(object sender, EventArgs e)
        {
            if (txtPreg.Text == "")
                txtPreg.Text = "Respuesta";
        }

        private void txtNombre_Enter(object sender, EventArgs e)
        {
            if (txtNombre.Text == "Nombre")
                txtNombre.Text = "";
        }

        private void txtNombre_Leave(object sender, EventArgs e)
        {
            if (txtNombre.Text == "")
                txtNombre.Text = "Nombre";
        }

        private void txtPreguntaPropia_Enter(object sender, EventArgs e)
        {
            if (txtPreguntaPropia.Text == "Pregunta")
                txtPreguntaPropia.Text = "";
        }

        private void txtPreguntaPropia_Leave(object sender, EventArgs e)
        {
            if (txtPreguntaPropia.Text == "")
                txtPreguntaPropia.Text = "Pregunta";
        }

        private void pictLock_Click(object sender, EventArgs e) // Contraseña con *
        {
            if(txtPass.Text != "Contraseña")
            {
                txtPass.UseSystemPasswordChar = false;
                pictLock.Visible = false;
                pctUnloc.Visible = true;
            }
            
        }

        private void pctUnloc_Click(object sender, EventArgs e) // Contraseña sin *
        {
            if (txtPass.Text != "Contraseña")
            {
                txtPass.UseSystemPasswordChar = true;
                pictLock.Visible = true;
                pctUnloc.Visible = false;
            }
            
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e) // SE USA PREGUNTA PROPIA
        {
            /* SE MUESTRA Y SE DEJA DE MOSTRAR LO QUE LE CORRESPONDA */
            if(checkBox1.Checked == true)
            {
                txtPreguntaPropia.Visible = true;
                lineShape6.Visible = true;
                txtPreg.Visible = true;
                pictureBox5.Visible = true;
                lineShape5.Visible = true;
                checkBox2.Checked = false;
            }
            else
            {
                txtPreguntaPropia.Visible = false;
                lineShape6.Visible = false;
                txtPreg.Visible = false;
                pictureBox5.Visible = false;
                lineShape5.Visible = false;
            }
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e) // SE USA PREGUNTA YA PREDETERMINADA
        {
            /* SE MUESTRA Y SE DEJA DE MOSTRAR LO QUE LE CORRESPONDA */
            if (checkBox2.Checked == true)
            {
                cmbPreg.Visible = true;
                checkBox1.Checked = false;
            }
            else
                cmbPreg.Visible = false;
        }


        private void frmRegistro_Load(object sender, EventArgs e)
        {
            checkBox1.Checked = true;
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
