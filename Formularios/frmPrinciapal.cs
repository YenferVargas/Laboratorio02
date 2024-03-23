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

namespace WindowsFormsApp1.Formularios
{
    public partial class frmPrinciapal : Form
    {
        private string nombreUsuario;

    
        public frmPrinciapal(string nombreUsuario)
        {
            InitializeComponent();
            this.nombreUsuario = nombreUsuario;
            ActualizarStatusStrip();
        }

      
        private void ActualizarStatusStrip()
        {
            toolStrip0.Text = $"Bienvenido {nombreUsuario}";
        }


        frmArticulos fa;
        frmClientes fc;
        frmListadoClientes fl;
        public frmPrinciapal()
        {
            InitializeComponent();
        }

        void formulariosArticulos()
        {
            if(fa == null)
            {
                fa = new frmArticulos();
                fa.FormClosed += new FormClosedEventHandler(fa_cirra);
                fa.MdiParent = this;
                fa.Show();
            }
            
        }
        void formulariosClientes()
        {
            if (fc == null)
            {
                fc = new frmClientes();
                fc.FormClosed += new FormClosedEventHandler(fa_cirra);
                fc.MdiParent = this;
                fc.Show();
            }

        }
        private List<Cliente> listaDeClientes = new List<Cliente>();
        void formulariosListadoClientes()
        {
            if (fl == null)
            {
                fl = new frmListadoClientes(listaDeClientes);
                fl.FormClosed += new FormClosedEventHandler(fl_Cerrar);
                fl.MdiParent = this;
                fl.Show();
            }
        }

        void fl_Cerrar(object sender, EventArgs e)
        {
            fl = null; 
        }


        void fa_cirra(object senser, EventArgs e)
        {
            fa = null;
        }

        private void articulosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            formulariosArticulos();

        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            formulariosArticulos();
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            formulariosListadoClientes();
        }

        private void clientesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            formulariosListadoClientes();
        }

        private void toolStripStatusLabel2_Click(object sender, EventArgs e)
        {
            
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void toolStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }
    }


}
