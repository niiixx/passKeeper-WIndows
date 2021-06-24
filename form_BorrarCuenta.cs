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
    public partial class form_BorrarCuenta : Form
    {
        public form_BorrarCuenta()
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

        private void form_BorrarCuenta_Load(object sender, EventArgs e)
        {
            lblNombre.Text = "Buenas, " + Sesion.nombre + "!"; // Mostramos el usuario con mensaje de bienvenida   
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

        private void txtUsuarioLog_TextChanged(object sender, EventArgs e)
        {
            Modelo modelo = new Modelo();
            if (modelo.existe_cuenta(txtSitioWeb.Text, txtUsuarioLog.Text)) // VEMOS SI LA CUENTA A BORRAR EXISTE
            {
                Logins log = new Logins();
                Encriptador encriptar = new Encriptador();
                txtPassLog.Visible = true;
                log = modelo.devuelve_cuenta(txtSitioWeb.Text, txtUsuarioLog.Text); // La buscamos

                if (log == null)
                    txtPassLog.Text = "No se encuentra la cuenta";
                else // Existe - Bloqueamos todo y solo permitimos borrar o salir
                {
                    txtPassLog.Text = encriptar.deseencriptar(log.Pass);
                    txtUsuarioLog.Enabled = false;
                    txtSitioWeb.Enabled = false;
                    lineShape3.Visible = true;
                    pctUnloc.Visible = true;
                    btnBorrar.Visible = true;
                    lblError.Visible = false;
                }
            }
        }

        private void btnBorrar_Click(object sender, EventArgs e) // Ya están bloqueados los controles
        {
            Logins log = new Logins();
            Modelo modelo = new Modelo();

            log.IdLogin = Sesion.id;
            log.User = txtUsuarioLog.Text;
            log.Sitio = txtSitioWeb.Text;
            log.Pass = txtPassLog.Text;

            modelo.eliminar_cuentas(log); // Borramos cuenta - Como ya estan bloqueados los controles no hay que comprobar nada en controlador
            MessageBox.Show("Cuenta eliminada con éxito!", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Information);

            /*LIMPIAMOS TODO*/
            form_BorrarCuenta frm_cargar = new form_BorrarCuenta();
            frm_cargar.Visible = true;
            this.Visible = false;
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
