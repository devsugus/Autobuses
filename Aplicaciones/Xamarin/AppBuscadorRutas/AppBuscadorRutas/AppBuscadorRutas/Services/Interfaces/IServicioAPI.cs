using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AppBuscadorRutas.Services.Interfaces
{
    interface IServicioAPI <T> where T: class
    {
        T Obtener();
    }
}