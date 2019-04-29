using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using AppBuscadorRutas.Services.Interfaces;
using AppBuscadorRutas.Services.Implementaciones;
using AppBuscadorRutas.Models;

namespace AppBuscadorRutas
{
	public partial class ResultPage : ContentPage
	{
		public ResultPage ()
		{

			InitializeComponent ();
            RunAsyncRutas().GetAwaiter().GetResult();
        }
        static async Task RunAsyncRutas()
        {
            IServicioAPI<Rutas> servicio = new ServicioAPI<Rutas>("....");
            List<Rutas> ListadoDeRutas = await servicio.ObtenerListaDatosAsync();
        }
    }
}