using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

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
    }
}
