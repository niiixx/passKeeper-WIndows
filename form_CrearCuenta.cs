using System;
using System.Data.SQLite;
using System.Windows.Forms;

namespace proyecto
{
    public partial class form_CrearCuenta : Form
    {
        public form_CrearCuenta()
        {
            InitializeComponent();
        }
        private void chckAleatorio_CheckedChanged(object sender, EventArgs e) // ALEATORIO PASS
        {
            if (chckAleatorio.Checked == true)
            {
                label7.Visible = true;
                nmLong.Visible = true;
                chckManual.Checked = false;
                btnCrear.Visible = true;
                labelSeguridad.Visible = false;
            }
            else
            {
                label7.Visible = false;
                nmLong.Visible = false;
                btnCrear.Visible = false;
            }
        }

        private void chckManual_CheckedChanged(object sender, EventArgs e) // MANUAL PASS
        {
            if (chckManual.Checked == true)
            {
                txtPassLog.Visible = true;
                chckAleatorio.Checked = false;
                btnCrear.Visible = true;
                labelSeguridad.Visible = true;
                lineShape3.Visible = true;
                pictLock.Visible = true;
            }
            else
            {
                txtPassLog.Visible = false;
                btnCrear.Visible = false;
                lblSeguirdad2.Visible = false;
                labelSeguridad.Text = "";
                lineShape3.Visible = false;
                pictLock.Visible = false;
                pctUnloc.Visible = false;
            }
        }

        private void txtPassLog_TextChanged_1(object sender, EventArgs e) // Mostramos cúan segura es la pass (solo sirve si es pass manual)
        {
            Controlador control = new Controlador();
            int peso = 0;
            peso = control.validarPass(txtPassLog.Text);
            if (peso < 0)
                labelSeguridad.Visible = false;
            if (peso < 20 && peso >= 0)
            {
                labelSeguridad.Visible = true;
                labelSeguridad.Text = "Seguridad muy débil";
            }
            if (peso < 30 && peso >= 20)
            {
                labelSeguridad.Visible = true;
                labelSeguridad.Text = "Seguridad débil";
            }
            if (peso < 40 && peso >= 30)
            {
                labelSeguridad.Visible = true;
                labelSeguridad.Text = "Seguridad media";
            }
            if (peso < 50 && peso >= 40)
            {
                labelSeguridad.Visible = true;
                labelSeguridad.Text = "Seguridad alta";
            }
            if (peso >= 50)
            {
                labelSeguridad.Visible = true;
                labelSeguridad.Text = "Seguridad muy alta";
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

        private void btnHome_Click(object sender, EventArgs e) // Volver al login sin registrarse
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

        private void btnCrear_Click(object sender, EventArgs e)
        {
            /* INSTANCIAS DE CLASES */
            Logins login = new Logins(); // GUARDARÁ LOGINS
            Controlador control = new Controlador(); // CONTROLARÁ LOGINS
            Encriptador encriptador = new Encriptador(); // ENCRIPTA

            login.User = txtUsuarioLog.Text;
            login.Sitio = txtSitioWeb.Text;
            login.IdLogin = Sesion.id;

            if (chckAleatorio.Checked == true)
                login.Pass = control.crearContra(decimal.ToInt32(nmLong.Value)); // Creamos contraseña aleatoria
            else
                login.Pass = txtPassLog.Text;

            // ENCRIPTAMOS LA PASS Y SE GUARDARÁ EN LA BBDD ENCRIPTADA
            login.Pass = encriptador.encriptar(login.Pass); 

            string respuesta_registro = control.ctrlSitio(login);

            MessageBox.Show(respuesta_registro, "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Information);

            form_CrearCuenta form_cargar = new form_CrearCuenta(); // INSTANCIAMOS EL FORM DEL PROGRAMA
            form_cargar.Visible = true; // MOSTRAMOS EL NUEVO
            this.Visible = false; // QUITAMOS EL LOGIN
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

        private void form_GestionPass_Load(object sender, EventArgs e)
        {
            chckManual.Checked = true;
            lblNombre.Text = "Buenas, " + Sesion.nombre + "!"; // Mostramos el usuario con mensaje de bienvenida   
        }

        private void txtSitioWeb_Enter(object sender, EventArgs e)
        {
            if (txtSitioWeb.Text == "Web")
                txtSitioWeb.Text = "";
        }

        private void txtSitioWeb_Leave(object sender, EventArgs e)
        {
            if (txtSitioWeb.Text == "")
                txtSitioWeb.Text = "Web";
        }

        private void txtUsuarioLog_Enter(object sender, EventArgs e)
        {
            if (txtUsuarioLog.Text == "Usuario")
                txtUsuarioLog.Text = "";
        }

        private void txtUsuarioLog_Leave(object sender, EventArgs e)
        {
            if (txtUsuarioLog.Text == "")
                txtUsuarioLog.Text = "Usuario";
        }

        private void txtPassLog_Enter(object sender, EventArgs e)
        {
            if (txtPassLog.Text == "Contraseña")
            {
                txtPassLog.Text = "";
                txtPassLog.UseSystemPasswordChar = true;
            }
        }

        private void txtPassLog_Leave(object sender, EventArgs e)
        {
            if (txtPassLog.Text == "")
            {
                txtPassLog.Text = "Contraseña";
                txtPassLog.UseSystemPasswordChar = false;
            }
        }

        private void linkGestionPass_Click(object sender, EventArgs e)
        {
            form_GestionarPass frm_log = new form_GestionarPass();
            frm_log.Visible = true;
            this.Visible = false;
        }

        private void pictureBox6_Click(object sender, EventArgs e) // Boton Home
        {
            form_Home frm_Cargar = new form_Home();
            frm_Cargar.Visible = true;
            this.Visible = false;
        }

        private void pictLock_Click(object sender, EventArgs e) // Mostrar pass con *
        {
            if (txtPassLog.Text != "Contraseña")
            {
                txtPassLog.UseSystemPasswordChar = false;
                pictLock.Visible = false;
                pctUnloc.Visible = true;
            }
        }

        private void pctUnloc_Click(object sender, EventArgs e) // Mostrar pass sin *
        {
            if (txtPassLog.Text != "Contraseña")
            {
                txtPassLog.UseSystemPasswordChar = true;
                pictLock.Visible = true;
                pctUnloc.Visible = false;
            }
        }
    }
}
