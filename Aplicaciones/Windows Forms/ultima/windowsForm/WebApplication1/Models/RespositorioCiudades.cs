using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class RespositorioCiudades
    {
        AutobusesSeseEntities entidad;
        public RespositorioCiudades()
        {
            this.entidad = new AutobusesSeseEntities();
        }
    
    //Get Ciudades
    public List<Ciudades> GetCiudades()
    {
        var consulta = from Ciudades in entidad.Ciudades
                       select Ciudades;
        return consulta.ToList();

    }


    //recuperar NombreCiudades 

    public List<Ciudades> GetCiudadespornombre(string nombreciudad)
    {

            var consulta = from Ciudades in entidad.Ciudades
                           where Ciudades.NombreCiudad == nombreciudad
                           select Ciudades;
            if (consulta.Count() == 0)
            {
                return null;
            }
            else
            {
                return consulta.ToList();
            }

    }


       

    }
}