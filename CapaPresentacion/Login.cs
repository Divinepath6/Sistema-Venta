using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CapaNegocio;
using CapaEntidad;
using System.Net.NetworkInformation;

namespace CapaPresentacion
{
    public partial class Login : Form {
        public Login() {
            InitializeComponent();
        }
        private void label2_Click(object sender, EventArgs e) {

        }
        private void label3_Click(object sender, EventArgs e) {

        }

        private void btningresar_Click(object sender, EventArgs e) {
            /*
            Si el programa muestra que hay demasiados intentos aun cuando es el primer intento
            es porque la siguiente linea requiere conexion a internete 
           */
            String MacAddress = NetworkInterface.GetAllNetworkInterfaces()
            .Where(nic => nic.OperationalStatus == OperationalStatus.Up && nic.NetworkInterfaceType != NetworkInterfaceType.Loopback)
            .Select(nic => nic.GetPhysicalAddress().ToString()).FirstOrDefault();
            /*
             NetworkInterface.GetAllNetworkInterfaces()
            .Where(nic => nic.OperationalStatus == OperationalStatus.Up && nic.NetworkInterfaceType != NetworkInterfaceType.Loopback)
            .Select(nic => nic.GetPhysicalAddress().ToString()).FirstOrDefault();
            */

            CN_Sesion cn_Sesion = new CN_Sesion();
            if(cn_Sesion.sesion(MacAddress)) {
                List<Usuario> TEST = new CN_Usuario().Listar();
                Usuario ousuario = new CN_Usuario().Listar().Where(u => u.Documento == txtdocumento.Text && u.Clave == txtclave.Text).FirstOrDefault();
                if(ousuario != null) {
                    if(ousuario.Estado) {
                        Inicio form = new Inicio(ousuario);
                        form.Show();
                        this.Hide();
                        form.FormClosing += frm_closing;
                        cn_Sesion.Inicio(MacAddress);
                    }
                    else {
                        MessageBox.Show("El usuario esta desactivado", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                }
                else {
                    MessageBox.Show("No se encontro el Usuario", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            else {
                MessageBox.Show("Demasiados intentos fallidos contacte a un administrador", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void btncancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frm_closing(object ssender, FormClosingEventArgs e)
        {
            txtdocumento.Text = "";
            txtclave.Text = "";
            this.Show();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
        private void Login_Load(object sender, EventArgs e){
            txtdocumento.Focus();
        }

        private void txtclave_TextChanged(object sender, EventArgs e)
        {

        }
        private void Login_KeyDown(object sender, KeyEventArgs e) {
     
        }

        private void txtdocumento_KeyPress(object sender, KeyPressEventArgs e) {
            if(e.KeyChar == (char)(Keys.Enter)) {
                txtclave.Focus();
            }
        }
        private void txtclave_KeyPress(object sender, KeyPressEventArgs e) {
            if(e.KeyChar == (char)(Keys.Enter)) {
                btningresar_Click(sender, e);
            }
        }
    }
}
