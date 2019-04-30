using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAPISeseAutobuses.Models
{
    public class Lanzador
    {
        public static void Main(String[] args)
        {
            ConexionBBDD cnn = new ConexionBBDD("desaprendiendodb.database.windows.net", "AlumnoSese", "P@$$w0rd!", "AutobusesSese");
            Busqueda bss = new Busqueda(cnn);
            /*
            * Introduce ciudad de origen y ciudad de destino para poder devolver el listado de rutas.
            */
            bss.rutas("Zaragoza", "Barcelona");

        }
    }
}