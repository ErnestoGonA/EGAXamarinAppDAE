﻿using EGAXamarinAppDAE.Interfaces.Navegacion;
using EGAXamarinAppDAE.ViewModels.Base;
using EGAXamarinAppDAE.ViewModels;
using EGAXamarinAppDAE.Views.CatGenerales;
using EGAXamarinAppDAE.Views.Navegacion;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace EGAXamarinAppDAE.Services.Navegacion
{
    //public class FicSrvNavigationInventario : IFicSrvCatEdificiosList
    public class FicSrvNavigationInventario : IFicSrvNavigationInventario
    {
        private IDictionary<Type, Type> FicViewModelRouting = new Dictionary<Type, Type>()
        {
            //AQUI SE HACE UNA UNION ENTRE LA VM Y VI DE CADA VIEW DE LA APP
            { typeof(FicVmCatEdificiosList),typeof(ViCatEdificiosList) },
            { typeof(FicVmCatEdificiosInsert),typeof(ViCatEdificiosInsert) },
            { typeof(FicVmCatEdificiosUpdate),typeof(ViCatEdificiosUpdate) },
            { typeof(FicVmCatEdificiosView),typeof(ViCatEdificiosView) },

            //{ typeof(FicVmInventariosList),typeof(FicViInventariosList) },
            //{ typeof(FicVmInventarioConteoList),typeof(FicViInventarioConteoList) },
            //{ typeof(FicVmInventarioConteosItem),typeof(FicViInventarioConteosItem) },
            //{ typeof(FicVmInventarioAcumuladoList),typeof(FicViInventarioAcumuladoList)},
            //{typeof(FicVmImportarWebApi), typeof(FicViImportarWebApi)},
            //{typeof(FicVmExportarWebApi), typeof(FicViExportarWebApi)}


        };

        #region METODOS DE IMPLEMENTACION DE LA INTERFACE -> IFicSrvNavigationInventario
        public void FicMetNavigateTo<FicTDestinationViewModel>(object FicNavigationContext = null)
        {
            Type FicPageType = FicViewModelRouting[typeof(FicTDestinationViewModel)];
            var FicPage = Activator.CreateInstance(FicPageType, FicNavigationContext) as Page;

            if (FicPage != null)
            {
                var mdp = Application.Current.MainPage as MasterDetailPage;
                mdp.Detail.Navigation.PushAsync(FicPage);
            }
        }

        public void FicMetNavigateTo(Type FicDestinationType, object FicNavigationContext = null)
        {
            Type FicPageType = FicViewModelRouting[FicDestinationType];
            var FicPage = Activator.CreateInstance(FicPageType, FicNavigationContext) as Page;

            if (FicPage != null)
            {
                var mdp = Application.Current.MainPage as MasterDetailPage;
                mdp.Detail.Navigation.PushAsync(FicPage);
            }
        }

        public void FicMetNavigateBack()
        {
            Application.Current.MainPage.Navigation.PopAsync(true);
        }
        #endregion

    }//CLASS
}//NAMESPACE
