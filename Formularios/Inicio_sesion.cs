using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp1;

namespace WindowsFormsApp1.Formularios
{
    public partial class Inicio_sesion : Form
    {
        public Inicio_sesion()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Inicio_sesion_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string nombreUsuario = txtNombre.Text;
            string contrasena = txtContrasena.Text;

            if (nombreUsuario == "yenifer" && contrasena == "yenifer")
            {
                
                frmPrinciapal formularioPrincipal = new frmPrinciapal(nombreUsuario);
                formularioPrincipal.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("El nombre de usuario o la contraseña son incorrectos. Por favor, intente de nuevo.", "Error de inicio de sesión", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtNombre.Clear();
                txtContrasena.Clear();
            }
        }

    }
}
