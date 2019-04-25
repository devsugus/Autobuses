using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppBuscadorRutas
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ResultPage : ContentPage
	{
		public ResultPage ()
		{
			InitializeComponent ();
            NavigationPage.SetHasBackButton(this, false);
            ((NavigationPage)Application.Current.MainPage).BarBackgroundColor = Color.Black;
		}
	}
}