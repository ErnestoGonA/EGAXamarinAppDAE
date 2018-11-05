using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

using EGAXamarinAppDAE.Interfaces.Navegacion;
using EGAXamarinAppDAE.Interfaces.CatGenerales;
using EGAXamarinAppDAE.Models;
using System.ComponentModel;
using System.Windows.Input;
using EGAXamarinAppDAE.ViewModels.Base;
using Xamarin.Forms;
using System.Runtime.CompilerServices;

namespace EGAXamarinAppDAE.ViewModels
{
    public class FicVmCatEdificiosList : INotifyPropertyChanged
    {
        public ObservableCollection<eva_cat_edificios> _FicSFDataGrid_ItemSource_Inventario;
        public eva_cat_edificios _FicSfDataGrid_SelectItem_Inventario;
        private ICommand _FicMetAddConteoICommand, _FicMetAcumuladosICommand;

        private IFicSrvNavigationInventario IFicSrvNavigationInventario;
        private IFicSrvCatEdificiosList IFicSrvCatEdificiosList;

        public FicVmCatEdificiosList(IFicSrvNavigationInventario IFicSrvNavigationInventario, IFicSrvCatEdificiosList IFicSrvCatEdificiosList)
        {
            this.IFicSrvNavigationInventario = IFicSrvNavigationInventario;
            this.IFicSrvCatEdificiosList = IFicSrvCatEdificiosList;
            _FicSFDataGrid_ItemSource_Inventario = new ObservableCollection<eva_cat_edificios>();
        }//constructor

        public ObservableCollection<eva_cat_edificios> FicSfDataGrid_ItemSource_Inventario
        {
            get
            {
                return _FicSFDataGrid_ItemSource_Inventario;
            }//Este apunta a travez del bindinfContect al grid de la view
        }

        public eva_cat_edificios FicSfDataGrid_SelectItem_Inventario
        {
            get
            {
                return _FicSfDataGrid_SelectItem_Inventario;
            }
            set
            {
                if (value != null)
                {
                    _FicSfDataGrid_SelectItem_Inventario = value;
                    RaisePropertyChanged();
                }
            }
        }//Este apunta a un item seleccionado en el grid de la view

        public ICommand FicMetAddConteoICommand
        {
            get
            {
                return _FicMetAddConteoICommand = _FicMetAddConteoICommand ?? new FicVmDelegateCommand(FicMetAddConteo);
            }
        }//Este evento agrega el comando al boton de la view

        private void FicMetAddConteo()
        {
            if (_FicSfDataGrid_SelectItem_Inventario != null)
            {
                IFicSrvNavigationInventario.FicMetNavigateTo<FicVmCatEdificiosList>(_FicSfDataGrid_SelectItem_Inventario);
            }
        }

        public ICommand FicMetAcumuladosICommand
        {
            get
            {
                return _FicMetAcumuladosICommand = _FicMetAcumuladosICommand ?? new FicVmDelegateCommand(FicMetAcumulados);
            }
        }//Este evento agrega el comando al boton en la view

        private void FicMetAcumulados()
        {
            if (_FicSfDataGrid_SelectItem_Inventario != null)
            {
                IFicSrvNavigationInventario.FicMetNavigateTo<FicVmCatEdificiosList>(_FicSfDataGrid_SelectItem_Inventario);
            }
        }

        public async void OnAppearing()
        {
            try
            {
                //var source_local_inv = await IFicSrvCatEdificiosList.FicMetGetListInventarios();
                //if (source_local_inv != null)
                //{
                //    foreach(eva_cat_edificios inv in source_local_inv)
                //    {
                //        _FicSFDataGrid_ItemSource_Inventario.Add(inv);
                //    }
                //}//Llenar el grid
            }
            catch(Exception e)
            {
                await new Page().DisplayAlert("ALERTA", e.Message.ToString(), "OK");
            }
        }//Sobrecarga el metodo OnAppearing() de la view

        #region INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;
        public void RaisePropertyChanged([CallerMemberName]string propertyname = "")
        {
            var handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyname));
            }
        }
        #endregion

    }
}
