using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Windows.Forms;
using WindowsFormsApp1.Formularios;

public class ArchivoTexto : Archivo
{
    public int NumeroDeLineas { get; set; }

    public override void Abrir()
    {
        MessageBox.Show($"Abriendo el documento de texto {Nombre} con {NumeroDeLineas} líneas.");
    }
}

