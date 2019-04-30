using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class RepositorioRutas
    {
        AutobusesSeseEntities entidad;
        public RepositorioRutas()
        {
            this.entidad = new AutobusesSeseEntities();
        }


        //Get Ciudades
        public List<Rutas> GetRutas()
        {
            var consulta2 = from Rutas in entidad.Rutas
                           select Rutas;
            return consulta2.ToList();

        }
        //public List<Ciudades> GetCiudades()
        //{
        //    var consulta = from Ciudades in entidad.Ciudades
        //                   select Ciudades;
        //    return consulta.ToList();

        //}

        public List<Rutas> GetRutasporOrigenyDestino(int origen, int destino)
        {

            var consulta2 = from Rutas in entidad.Rutas
                            where Rutas.Origen == origen &&
                                  Rutas.Destino == destino
                            select Rutas;
                            



            if (consulta2.Count() == 0)
            {
                return null;
            }
            else
            {
                return consulta2.ToList();
            }

        }
    }
}