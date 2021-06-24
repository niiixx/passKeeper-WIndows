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
    public partial class form_EditarCuenta : Form
    {
        public string antiguo_usuario;
        public int validador = 0;

        public form_EditarCuenta()
        {
            InitializeComponent();
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

        private void form_EditarCuenta_Load(object sender, EventArgs e)
        {
            lblNombre.Text = "Buenas, " + Sesion.nombre + "!"; // Mostramos el usuario con mensaje de bienvenida   
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

        private void btnEditar_Click(object sender, EventArgs e)
        {
            Logins log = new Logins();
            Modelo modelo = new Modelo();
            Encriptador encriptar = new Encriptador();
            Controlador control = new Controlador();

            log.IdLogin = Sesion.id;
            log.User = txtUsuarioLog.Text;
            log.Sitio = txtSitioWeb.Text;
            log.Pass = encriptar.encriptar(txtPassLog.Text);

            if(control.validarPass(txtPassLog.Text) >= 30) // Validamos si la pass que ha introducido el usuario es segura
            {
                modelo.update_cuenta(log, antiguo_usuario); // Editamos la cuenta

                MessageBox.Show("Cuenta editada con éxito!", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Information);

                /*LIMPIAMOS TODO*/
                form_EditarCuenta frm_cargar = new form_EditarCuenta();
                frm_cargar.Visible = true;
                this.Visible = false;
            }
            else // No segura - Mensaje de error
                MessageBox.Show("Contraseña poco segura.", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void txtUsuarioLog_TextChanged(object sender, EventArgs e)
        {
            Modelo modelo = new Modelo();
            if (modelo.existe_cuenta(txtSitioWeb.Text, txtUsuarioLog.Text) && validador == 0) // Solo para comprobar la primera vez que web y user coincidan (saber cual es la que hay que cambiar)
            {
                Logins log = new Logins();
                Encriptador encriptar = new Encriptador();
                txtPassLog.Visible = true;
                log = modelo.devuelve_cuenta(txtSitioWeb.Text, txtUsuarioLog.Text); // DEVUELVE LA CUENTA ANTIGUA

                if (log == null)
                    txtPassLog.Text = "No se encuentra la cuenta";
                else // Mostramos el generar pass y boton de editar
                {
                    antiguo_usuario = txtUsuarioLog.Text;
                    txtPassLog.Text = encriptar.deseencriptar(log.Pass); // Mostramos la pass antigua
                    lineShape3.Visible = true;
                    pctUnloc.Visible = true;
                    btnEditar.Visible = true;
                    lblError.Visible = false;
                    txtSitioWeb.Enabled = false;
                    btnNueva.Visible = true;
                    validador = 1;
                }
            }
        }

        private void btnNueva_Click(object sender, EventArgs e)
        {
            Controlador control = new Controlador();
            txtPassLog.Text = control.crearContra(10);
        }

        private void txtSitioWeb_Leave(object sender, EventArgs e)
        {
            if (txtSitioWeb.Text == "")
                txtSitioWeb.Text = "Web";
        }

        private void txtSitioWeb_Enter(object sender, EventArgs e)
        {
            if (txtSitioWeb.Text == "Web")
                txtSitioWeb.Text = "";
        }

        private void txtUsuarioLog_Leave(object sender, EventArgs e)
        {
            if (txtUsuarioLog.Text == "")
                txtUsuarioLog.Text = "Usuario";
        }

        private void txtUsuarioLog_Enter(object sender, EventArgs e)
        {
            if (txtUsuarioLog.Text == "Usuario")
                txtUsuarioLog.Text = "";
        }
        private void txtPassLog_Leave(object sender, EventArgs e)
        {
            if (txtUsuarioLog.Text == "")
                txtUsuarioLog.Text = "Contraseña";
        }
        private void txtPassLog_Enter(object sender, EventArgs e)
        {
            if (txtUsuarioLog.Text == "Contraseña")
                txtUsuarioLog.Text = "";
        }

        private void txtPassLog_TextChanged(object sender, EventArgs e)
        {
            Controlador control = new Controlador();
            int peso = 0;
            peso = control.validarPass(txtPassLog.Text);
            if (txtPassLog.Text != "Contraseña")
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

        private void linkGestionPass_Click(object sender, EventArgs e)
        {
            form_GestionarPass frm_log = new form_GestionarPass();
            frm_log.Visible = true;
            this.Visible = false;
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
