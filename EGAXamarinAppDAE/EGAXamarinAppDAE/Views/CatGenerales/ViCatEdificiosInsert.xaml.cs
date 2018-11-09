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
	public partial class ViCatEdificiosInsert : ContentPage
	{

        private object[] FicCuerpoNavigationContext { get; set; }

		public ViCatEdificiosInsert (object[] FicNavigationContext)
		{
			InitializeComponent ();
            FicCuerpoNavigationContext = FicNavigationContext;
            BindingContext = App.FicVmLocator.FicVmCatEdificiosInsert;
		}

        protected async override void OnAppearing()
        {
            var FicViewModel = BindingContext as FicVmCatEdificiosInsert;
            if (FicViewModel != null)
            {
                FicViewModel.FicNavigationContextC = FicCuerpoNavigationContext;

                FicViewModel.OnAppearing();
                
            }
        }//SE EJECUTA CUANDO SE ABRE LA VIEW

    }
}