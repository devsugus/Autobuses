using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class CiudadController : ApiController
    {
        RespositorioCiudades modelo;

        public CiudadController()
        {
            this.modelo = new RespositorioCiudades();
        }

        public List<Ciudades> Get()
        {

            return modelo.GetCiudades();
        }

        [HttpGet]
        [Route("api/Ciudad/{NombreCiudad}")]

        public List<Ciudades> GetCiudadesNombre(string NombreCiudad)
        {
            return modelo.GetCiudadespornombre(NombreCiudad);
        }

    }
}
