using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AppBuscadorRutas.Services.Interfaces
{
    interface IServicioAPIRest <T> where T: class
    {
        List<T> Obtener();
    }
}