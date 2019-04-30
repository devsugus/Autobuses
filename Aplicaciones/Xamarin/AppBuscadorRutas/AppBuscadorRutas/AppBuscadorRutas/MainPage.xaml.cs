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

            IServicioAPIRest<Ciudades> servicio = new ServicioAPIRest<Ciudades>(@"https://webapiseseautobuses.azurewebsites.net/api/CiudadesAPI");
            List<Ciudades> ListaCiudades = servicio.Obtener();
            List<String> NombreCiudades = (from Ciudades in ListaCiudades
                                     select Ciudades.NombreCiudad).ToList();
            PickerCiudadOrigen.ItemsSource = NombreCiudades;
            PickerCiudadDestino.ItemsSource = NombreCiudades;
        }
        async void Button_Clicked(object sender, EventArgs e)
        {
            string CiudadOrigen = PickerCiudadOrigen.SelectedItem.ToString();
            string CiudadDestino = PickerCiudadDestino.SelectedItem.ToString();
            await Navigation.PushAsync(new ResultPage(CiudadOrigen, CiudadDestino));
        }
    }
}
