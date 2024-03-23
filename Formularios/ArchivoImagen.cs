using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Windows.Forms;
using WindowsFormsApp1.Formularios;

public class ArchivoImagen : Archivo
{
    public string Formato { get; set; }

    public override void Abrir()
    {
        MessageBox.Show($"Mostrando la imagen {Nombre} con formato {Formato}.");
    }
}
