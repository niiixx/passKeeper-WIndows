using System;
using System.Windows.Forms;

namespace proyecto
{
    public partial class form_recuperar : Form
    {
        public form_recuperar()
        {
            InitializeComponent();
        }

        private void btnRecuperar_Click(object sender, EventArgs e)
        {
            Usuarios usuario_recuperar = null;
            Modelo modelo = new Modelo();
            Encriptador encriptador = new Encriptador();
            string usuario = txtUsuarioRec.Text;
            string respuesta = txtResRec.Text;
            usuario_recuperar = modelo.existe_usuario_login(usuario); // Validacion de que el usuario existe en el sistema

            lblPregRec.Text = encriptador.deseencriptar(usuario_recuperar.Tpreg); // Desencriptamos la pregunta del usuario

            Controlador control = new Controlador();
            string pass = control.recuperar_pass(usuario, respuesta); // Se muestra o contraseña o mensaje de error

            txtPassRec.Visible = true;
            txtPassRec.Text = pass;

            if (pass != "Las respuestas no coinciden.") // Se muestra contraseña y boton de poder copiar
                pctCopy.Visible = true;
        }

        private void txtUsuarioRec_TextChanged(object sender, EventArgs e) // Mostrar todo si usuario existe
        {
            Usuarios usuario_recuperar = null;
            Modelo modelo = new Modelo();
            Encriptador encriptador = new Encriptador();

            lblUsuario.Visible = true;
            bool existe;
            string usuario = txtUsuarioRec.Text;

            existe = modelo.existe_usuario(usuario);

            if (existe == true)
            { 
                lblUsuario.Text = "Usuario encontrado";
                usuario_recuperar = modelo.existe_usuario_login(usuario);
                lblPregRec.Text = encriptador.deseencriptar(usuario_recuperar.Tpreg);
                lblPregRec.Visible = true;
                txtResRec.Visible = true;
                btnRecuperar.Visible = true;
                lineShape2.Visible = true;
                pictureBox3.Visible = true;
            }
        }

        private void btnHome_Click(object sender, EventArgs e)
        {
            form_login frm_log = new form_login();
            frm_log.Visible = true;
            this.Visible = false;
        }

        private void txtUsuarioRec_Enter(object sender, EventArgs e)
        {
            if (txtUsuarioRec.Text == "Usuario")
                txtUsuarioRec.Text = "";
        }

        private void txtUsuarioRec_Leave(object sender, EventArgs e)
        {
            if (txtUsuarioRec.Text == "")
                txtUsuarioRec.Text = "Usuario";
        }

        private void txtResRec_Enter(object sender, EventArgs e)
        {
            if (txtResRec.Text == "Respuesta")
                txtResRec.Text = "";
        }

        private void txtResRec_Leave(object sender, EventArgs e)
        {
            if (txtResRec.Text == "")
                txtResRec.Text = "Respuesta";
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void pctCopy_Click(object sender, EventArgs e) // Copiar el texto
        {
            Clipboard.SetText(txtPassRec.Text);
            lblPortapapeles.Visible = true;
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

        private void pictureBox3_MouseHover(object sender, EventArgs e)
        {
            lblRespuestaHover.Visible = true;
        }

        private void pictureBox3_MouseLeave(object sender, EventArgs e)
        {
            lblRespuestaHover.Visible = false;
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
