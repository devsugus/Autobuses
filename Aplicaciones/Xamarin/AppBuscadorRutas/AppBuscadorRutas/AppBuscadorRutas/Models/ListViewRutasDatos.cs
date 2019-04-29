using System;
using System.Collections.Generic;
using System.Text;

namespace AppBuscadorRutas.Models
{
    public class ListViewRutasDatos
    {
        public List<Rutas> Rutas = new List<Rutas>()
        {
            new Rutas()
            {
                Origen = "Zaragoza";
                Precio = "12€";
            }
        }
    }
}
