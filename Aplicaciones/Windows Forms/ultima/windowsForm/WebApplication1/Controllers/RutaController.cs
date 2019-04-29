using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class RutaController : ApiController
    {
        RepositorioRutas modelo;

        public RutaController()
        {
            this.modelo = new RepositorioRutas();
        }

        public List<Rutas> Get()
        {

            return modelo.GetRutas();
        }

        [HttpGet]
        [Route("api/Ruta/{Origen}/{Destino}")]

        public List<Rutas> GetRutaOrigen(int Origen, int Destino)
        {
            return modelo.GetRutasporOrigenyDestino(Origen, Destino);
        }
//        protected void Page_Load(object sender , EventArgs e) { 
//        string filter = Request.QueryString["Combined_Name"];
//        Response.Clear();
//ContentType= "application/json; charset=utf-8";
//.Write(ShowJSON(filter));
//.End();
//        }
    }
}
