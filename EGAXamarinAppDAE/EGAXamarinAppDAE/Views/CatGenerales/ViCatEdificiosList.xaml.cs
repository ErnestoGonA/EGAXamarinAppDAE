using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using EGAXamarinAppDAE.Data;
using EGAXamarinAppDAE.Interfaces.SQLite;
using EGAXamarinAppDAE.ViewModels;

namespace EGAXamarinAppDAE.Views.CatGenerales
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ViCatEdificiosList : ContentPage
	{
                
        public ViCatEdificiosList()
        {
            InitializeComponent();
            BindingContext = App.FicVmLocator.FicVmCatEdificiosList;
        }

        public ViCatEdificiosList(object FicNavigationContext)
        {
            InitializeComponent();
            BindingContext = App.FicVmLocator.FicVmCatEdificiosList;
        }

        protected async override void OnAppearing()
        {
            var FicViewModel = BindingContext as FicVmCatEdificiosList;
            if(FicViewModel!= null)
            {
                FicViewModel.OnAppearing();
            }
        }

    }
}