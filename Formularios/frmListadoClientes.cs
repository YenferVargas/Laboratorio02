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
    public partial class frmListadoClientes : Form
    {
        private List<Cliente> _clientes;

        public frmListadoClientes(List<Cliente> clientes)
        {
            InitializeComponent();
            _clientes = clientes;
            this.Activated += (s, e) => RefreshClienteList();

            this.btnAgregar.Click += new EventHandler(this.button1_Click);
        }
    
        public static class ClienteManager
        {
            public static List<Cliente> Clientes { get; set; } = new List<Cliente>();

            public static void AddCliente(Cliente cliente)
            {
                Clientes.Add(cliente);

            }

            public static List<Cliente> GetClientes()
            {
                return Clientes;
            }
        }
   

        private void RefreshClienteList()
        {
            _clientes = ClienteManager.GetClientes();
            dataGridViewClientes.DataSource = null;
            dataGridViewClientes.DataSource = _clientes;
        }

        private void button1_Click(object sender, EventArgs e)
        {
          
            if (Application.OpenForms.OfType<frmClientes>().Any())
            {
                
                Application.OpenForms.OfType<frmClientes>().First().BringToFront();
            }
            else
            {
                frmClientes formClientes = new frmClientes();
                formClientes.MdiParent = this.MdiParent;
                formClientes.Show();
            }
        }

        private void dataGridViewClientes_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        private void dataGridViewClientes_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (this.dataGridViewClientes.Columns[e.ColumnIndex].Name == "Image" && e.Value != null)
            {
                string path = e.Value.ToString();
                try
                {
                    e.Value = Image.FromFile(path);
                    e.FormattingApplied = true;
                }
                catch (System.IO.FileNotFoundException)
                {
                    
            
                    e.FormattingApplied = true;
                }
            }
        }
        private void ConfigurarColumnas()
        {

            var imageColumn = new DataGridViewImageColumn
            {
                Name = "Image",
                HeaderText = "Imagen",
                DataPropertyName = "ImagePath", 
                ImageLayout = DataGridViewImageCellLayout.Zoom
            };
            this.dataGridViewClientes.Columns.Add(imageColumn);
        }

        private void frmListadoClientes_Load(object sender, EventArgs e)
        {

        }
    }
}
