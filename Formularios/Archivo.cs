using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.IO;
using System.Drawing;

namespace WindowsFormsApp1.Formularios
{
    public class Archivo
    {
        public string Nombre { get; set; }
        public Image Imagen { get; set; }

        public virtual void Abrir()
        {
            long tamañoEnBytes = 0;

            using (MemoryStream ms = new MemoryStream())
            {
                Imagen?.Save(ms, Imagen.RawFormat);
                tamañoEnBytes = ms.Length;
            }

            MessageBox.Show($"Abriendo el archivo {Nombre} que tiene un tamaño de {tamañoEnBytes} bytes.");
        }
    }
}
