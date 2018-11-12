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
        
         // Contiene la informacion para llenar el grid
//        public ObservableCollection<eva_cat_edificios> _FicSFDataGrid_ItemSource_Inventario;
        public ObservableCollection<eva_cat_edificios> _FicSFDataGrid_ItemSource_CatEdificios;

        //public eva_cat_edificios _FicSfDataGrid_SelectItem_Inventario;
        public eva_cat_edificios _FicSfDataGrid_SelectItem_CatEdificios;

        //Botonoes nuevo, eliminar, editar
        private ICommand _FicMetAddEdificioICommand,_FicMetUpdateEdificioICommand,_FicMetViewEdificioICommand,_FicMetRemoveEdificioICommand;

        private IFicSrvNavigationInventario IFicSrvNavigationInventario;

        private IFicSrvCatEdificiosList IFicSrvCatEdificiosList;

        private IFicSrvCatEdificiosInsert IFicSrvCatEdificiosInsert;

        private IFicSrvCatEdificiosUpdate IFicSrvCatEficiosUpdate;

        public FicVmCatEdificiosList(IFicSrvNavigationInventario IFicSrvNavigationInventario,
            IFicSrvCatEdificiosList IFicSrvCatEdificiosList,
            IFicSrvCatEdificiosInsert IFicSrvCatEdificiosInsert,
            IFicSrvCatEdificiosUpdate IFicSrvCatEdificiosUpdate)
        {
            this.IFicSrvNavigationInventario = IFicSrvNavigationInventario;
            this.IFicSrvCatEdificiosList = IFicSrvCatEdificiosList;
            this.IFicSrvCatEdificiosInsert = IFicSrvCatEdificiosInsert;
            this.IFicSrvCatEficiosUpdate = IFicSrvCatEficiosUpdate;
            //_FicSFDataGrid_ItemSource_Inventario = new ObservableCollection<eva_cat_edificios>();
            _FicSFDataGrid_ItemSource_CatEdificios = new ObservableCollection<eva_cat_edificios>();

        }//constructor

        public ObservableCollection<eva_cat_edificios> FicSfDataGrid_ItemSource_CatEdificios
        {
            get
            {
                //return _FicSFDataGrid_ItemSource_Inventario;
                return _FicSFDataGrid_ItemSource_CatEdificios;

            }//Este apunta a travez del bindinfContect al grid de la view
        }

        public eva_cat_edificios FicSfDataGrid_SelectItem_CatEdificios
        {
            get
            {
                //return _FicSfDataGrid_SelectItem_Inventario;
                return _FicSfDataGrid_SelectItem_CatEdificios;
            }
            set
            {
                if (value != null)
                {
                    //_FicSfDataGrid_SelectItem_Inventario = value;
                    _FicSfDataGrid_SelectItem_CatEdificios = value;

                    RaisePropertyChanged();
                }
            }
        }//Este apunta a un item seleccionado en el grid de la view

        public ICommand FicMetAddEdificioICommand
        {
            get
            {
                return _FicMetAddEdificioICommand = _FicMetAddEdificioICommand ?? new FicVmDelegateCommand(FicMetAddEdificio);
            }
        }

        private void FicMetAddEdificio()
        {

            IFicSrvNavigationInventario.FicMetNavigateTo<FicVmCatEdificiosInsert>();

        }

        public ICommand FicMetUpdateEdificioICommand
        {
            get
            {
                return _FicMetUpdateEdificioICommand = _FicMetUpdateEdificioICommand ?? new FicVmDelegateCommand(FicMetUpdateEdificio);
            }
        }

        private void FicMetUpdateEdificio()
        {
            if (FicSfDataGrid_SelectItem_CatEdificios != null)
            {
                IFicSrvNavigationInventario.FicMetNavigateTo<FicVmCatEdificiosUpdate>(FicSfDataGrid_SelectItem_CatEdificios);
            }
        }

        public ICommand FicMetViewEdificioICommand
        {
            get
            {
                return _FicMetViewEdificioICommand = _FicMetViewEdificioICommand ?? new FicVmDelegateCommand(FicMetViewEdificio);
            }
        }

        private void FicMetViewEdificio()
        {
            if (FicSfDataGrid_SelectItem_CatEdificios != null)
            {
                IFicSrvNavigationInventario.FicMetNavigateTo<FicVmCatEdificiosView>(FicSfDataGrid_SelectItem_CatEdificios);
            }
        }

        public ICommand FicMetRemoveEdificioICommand
        {
            get
            {
                return _FicMetRemoveEdificioICommand = _FicMetRemoveEdificioICommand ?? new FicVmDelegateCommand(FicMetRemoveEdificio);
            }
        }

        private async void FicMetRemoveEdificio()
        {
            if (FicSfDataGrid_SelectItem_CatEdificios != null)
            {
           
                var ask = await new Page().DisplayAlert("ALERTA!", "Seguro?", "Si", "No");
                if (ask)
                {
                    var res = await IFicSrvCatEdificiosList.Remove_eva_cat_edificios(FicSfDataGrid_SelectItem_CatEdificios);
                    if (res == "OK")
                    {
                        IFicSrvNavigationInventario.FicMetNavigateTo<FicVmCatEdificiosList>();
                    }
                    else
                    {
                        await new Page().DisplayAlert("DELETE", res.ToString(), "OK");
                    }
                }
            }
        }
        
        public async void OnAppearing()
        {
            try
            {
                var source_local_inv = await IFicSrvCatEdificiosList.FicMetGetListInventarios();
                if (source_local_inv != null)
                {
                    foreach (eva_cat_edificios inv in source_local_inv)
                    {
                        _FicSFDataGrid_ItemSource_CatEdificios.Add(inv);
                    }
                }//Llenar el grid
            }
            catch (Exception e)
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
