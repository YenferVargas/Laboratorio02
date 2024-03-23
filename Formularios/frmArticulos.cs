using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1.Formularios
{
    public partial class frmArticulos : Form
    {
     
        public class Articulo
        {
            public string Nombre { get; set; }
            public int Cantidad { get; set; }
            public decimal Precio { get; set; }
        }

  
        private BindingList<Articulo> listaArticulos = new BindingList<Articulo>();


        public frmArticulos()
        {
            InitializeComponent();
        }

        private void frmArticulos_Load(object sender, EventArgs e)
        {
            dateTimePickerFechaFactura.Format = DateTimePickerFormat.Custom;
            dateTimePickerFechaFactura.CustomFormat = "dd/MM/yyyy";

            dateTimePickerFechaFactura2.Format = DateTimePickerFormat.Custom;
            dateTimePickerFechaFactura2.CustomFormat = "dd/MM/yyyy";

            dataGridViewArticulos.DataSource = listaArticulos;

            DataGridViewButtonColumn btnEditar = new DataGridViewButtonColumn();
            btnEditar.Name = "btnEditar";
            btnEditar.HeaderText = "";
            btnEditar.Text = "Editar";
            btnEditar.UseColumnTextForButtonValue = true; 
            dataGridViewArticulos.Columns.Add(btnEditar);

            DataGridViewButtonColumn btnEliminar = new DataGridViewButtonColumn();
            btnEliminar.Name = "btnEliminar";
            btnEliminar.HeaderText = "";
            btnEliminar.Text = "Eliminar";
            btnEliminar.UseColumnTextForButtonValue = true; 
            dataGridViewArticulos.Columns.Add(btnEliminar);

        }
        private int? indiceFilaSeleccionada = null;

        private void btnagregar_Click(object sender, EventArgs e)
        {

            if (!string.IsNullOrWhiteSpace(txtArticulo.Text) &&
                !string.IsNullOrWhiteSpace(txtCantidad.Text) &&
                !string.IsNullOrWhiteSpace(txtPrecio.Text))
            {
                try
                {
                    Articulo articulo = new Articulo()
                    {
                        Nombre = txtArticulo.Text,
                        Cantidad = int.Parse(txtCantidad.Text),
                        Precio = decimal.Parse(txtPrecio.Text)
                    };

                  
                    if (!indiceFilaSeleccionada.HasValue)
                    {
                        listaArticulos.Add(articulo);
                    }
                    else 
                    {
                        
                        Articulo articuloExistente = listaArticulos[indiceFilaSeleccionada.Value];
                        articuloExistente.Nombre = articulo.Nombre;
                        articuloExistente.Cantidad = articulo.Cantidad;
                        articuloExistente.Precio = articulo.Precio;

  
                        dataGridViewArticulos.Refresh();

                     
                        indiceFilaSeleccionada = null;
                    }

                  
                    txtArticulo.Clear();
                    txtCantidad.Clear();
                    txtPrecio.Clear();

                 
                    btnagregar.Text = "Agregar";
                }
                catch (FormatException)
                {
                    MessageBox.Show("Por favor, ingresa números válidos para la cantidad y el precio.", "Error de formato");
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Se produjo un error: {ex.Message}", "Error");
                }
            }
            else
            {
                MessageBox.Show("Debes llenar todos los campos antes de agregar un artículo.", "Campos requeridos vacíos");
            }
        }

        private void btnGrabar_Click(object sender, EventArgs e)
        {

        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            {
              
                this.Close();
            }
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            
        }

        private void dataGridViewArticulos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                
                if (e.ColumnIndex == 0) 
                {
                    
                    indiceFilaSeleccionada = e.RowIndex;

                    
                    Articulo articulo = listaArticulos[indiceFilaSeleccionada.Value];

                  
                    txtArticulo.Text = articulo.Nombre;
                    txtCantidad.Text = articulo.Cantidad.ToString();
                    txtPrecio.Text = articulo.Precio.ToString();
                }
                else if (dataGridViewArticulos.Columns[e.ColumnIndex].Name == "btnEliminar")
                {
                
                    listaArticulos.RemoveAt(e.RowIndex);
                    
                }
            }
        }
    }
}
