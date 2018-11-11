using EGAXamarinAppDAE.Models;
using EGAXamarinAppDAE.ViewModels;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace EGAXamarinAppDAE.Views.CatGenerales
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ViCatEdificiosImportarExportar : ContentPage
	{
		public ViCatEdificiosImportarExportar ()
		{
			InitializeComponent ();
            BindingContext = App.FicVmLocator.FicVmCatEdificiosImportarExportar;
        }

        protected async override void OnAppearing()
        {

            var FicViewModel = BindingContext as FicVmCatEdificiosImportarExportar;
            if (FicViewModel != null)
            {
                FicViewModel.OnAppearing();
            }
        }

    }
}