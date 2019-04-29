using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace AutobusesSese.Models.repositorios
{

    public class Repositorio : IRepositorio
    {
        public AutobusesSeseEntities1 db = new AutobusesSeseEntities1();

        public void ActualizaCiudad(Ciudades MiCiudad)
        {
            db.Entry(MiCiudad).State = EntityState.Modified;
            db.SaveChangesAsync();
        }

        public void ActualizaRuta(Rutas MiRuta)
        {
            db.Entry(MiRuta).State = EntityState.Modified;
            db.SaveChangesAsync();
        }

        public void BorraCiudad(Ciudades MiCiudad)
        {
            db.Ciudades.Remove(MiCiudad);
            db.SaveChangesAsync();
        }

        public void BorraRuta(Rutas MiRuta)
        {
            db.Rutas.Remove(MiRuta);
            db.SaveChangesAsync();
        }

        public void CreaCiudad(Ciudades MiCiudad)
        {
            db.Ciudades.Add(MiCiudad);
            db.SaveChangesAsync();
        }

        public void CreaRuta(Rutas MiRuta)
        {
            db.Rutas.Add(MiRuta);
            db.SaveChangesAsync();
        }

        public async Task<Ciudades> DameCiudad(int Id)
        {
            Ciudades miCiudad = await db.Ciudades.FindAsync(Id);
            if (miCiudad == null)
            {
                return default(Ciudades);
            }
            else
            {
                return miCiudad;
            }
        }

        public async Task<List<Ciudades>> DameCiudades()
        {
            return await db.Ciudades.ToListAsync();
        }

        public async Task<Rutas> DameRuta(int Id)
        {
            Rutas miRuta = await db.Rutas.FindAsync(Id);
            if (miRuta == null)
            {
                return default(Rutas);
            }
            else
            {
                return miRuta;
            }
        }

        public async Task<List<Rutas>> DameRutas()
        {
            return await db.Rutas.ToListAsync();
        }
    }
}