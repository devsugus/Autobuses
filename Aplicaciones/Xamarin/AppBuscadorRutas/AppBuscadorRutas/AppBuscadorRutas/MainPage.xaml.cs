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

            IServicioAPI<Olimpiada> servicio = new ServicioAPI<Olimpiada>(@"http://localhost:52959/WcfDataServiceOlimpiada.svc/Paises('ESP')/Atletas?$format=json");
            Olimpiada olimpiada = servicio.Obtener();
            List<String> Ciudades = (from _Ciudad in olimpiada.value
                                     select _Ciudad.Nombre).ToList();
            SeleccionCiudadOrigen.ItemsSource = Ciudades;
            SeleccionCiudadDestino.ItemsSource = Ciudades;
        }
        async void Button_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ResultPage());
        }
    }
}
