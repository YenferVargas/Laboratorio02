using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using WindowsFormsApp1.Formularios;
using static WindowsFormsApp1.Formularios.frmListadoClientes;

namespace WindowsFormsApp1.Formularios
{
    public partial class frmClientes : Form
    {
        public frmClientes()
        {
            InitializeComponent();
        }

        private void frmClientes_Load(object sender, EventArgs e)
        {

        }

        private void pictureBoxImagen_Click(object sender, EventArgs e)
        {
          
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                pictureBoxImagen.Image = Image.FromFile(openFileDialog1.FileName);
            }
        }

        private void btnAgregar_Click_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtNombre.Text) && openFileDialog1.FileName != null)
            {
                Cliente nuevoCliente = new Cliente
                {
                    Nombre = txtNombre.Text,
                    Image = openFileDialog1.FileName 
                };

                ClienteManager.AddCliente(nuevoCliente);
                this.Close();
                           
            }
            else
            {
                MessageBox.Show("Por favor, complete todos los campos.");
            }
        }



    }
}
