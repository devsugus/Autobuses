using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutobusesSese.Models.repositorios
{
    public interface IRepositorio
    {
        Task<Ciudades> DameCiudad(int Id);
        Task<List<Ciudades>> DameCiudades();
        void CreaCiudad(Ciudades MiCiudad);
        void ActualizaCiudad(Ciudades MiCiudad);
        void BorraCiudad(Ciudades MiCiudad);

        Task<Rutas> DameRuta(int Id);
        Task<List<Rutas>> DameRutas();
        void CreaRuta(Rutas MiRuta);
        void ActualizaRuta(Rutas MiRuta);
        void BorraRuta(Rutas MiRuta);
    }
}
