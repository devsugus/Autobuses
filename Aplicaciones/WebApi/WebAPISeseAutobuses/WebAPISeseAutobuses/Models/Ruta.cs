using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAPISeseAutobuses.Models
{
    public class Ruta
    {
        /**
         * Propiedades
         */
        public string CiudadOrigen { set; get; }
        public string CiudadDestino { set; get; }
        public string Camino { set; get; }
        public decimal Valor { set; get; }
        public string IdValor { set; get; }
    }
}