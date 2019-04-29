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
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            RunAsyncCiudades().GetAwaiter().GetResult();
        }

        static async Task RunAsyncCiudades()
        {
            IServicioAPI<Ciudades> servicio = new ServicioAPI<Ciudades>("URL CIUDADES");
            List<Ciudades> ListadoDeCiudades = await servicio.ObtenerListaDatosAsync();
        }

        async void Button_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ResultPage());
        }
    }
}
