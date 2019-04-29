using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppBuscadorRutas
{
    public partial class MainPage : ContentPage
    {
        ListView listView;
        string[] names = { "Madrid","Zaragoza","Barcelona" };
        public MainPage()
        {
            InitializeComponent();
            
        }

        async void Button_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ResultPage());
        }
    }
}
