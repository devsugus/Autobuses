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
		public ResultPage (string CiudadOrigen, string CiudadDestino)
		{
			InitializeComponent ();
            IServicioAPIRest<Rutas> servicio = new ServicioAPIRest<Rutas>(@"https://webapiseseautobuses.azurewebsites.net/api/rutasApi/"+CiudadOrigen+"/"+CiudadDestino);
            List<Rutas> ListaRutas = servicio.Obtener();
            ResultadoRutas.ItemsSource = ListaRutas;
           
        }
    }
}