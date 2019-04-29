using System;
using System.Collections.Generic;
using System.Text;

namespace AppBuscadorRutas.Models
{
    public class ListViewRutas
    {
        public int ID { get; set; }
        public string Ruta { get; set; }
        public int Tiempo { get; set; }
        public int Precio { get; set; }
        public int Distancia { get; set; }
    }
}
