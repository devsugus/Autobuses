using System;
using System.Collections.Generic;
using System.Text;

namespace BibliotecaWebAPI
{
    public interface IWebAPIcs
    {
        List<Ruta> DameRutas(int ciudadOrigen, int ciudadDestino);
        List<Ciudades> DameCiudades();

    }
}
