using EGAXamarinAppDAE.Interfaces.Navegacion;
using EGAXamarinAppDAE.Interfaces.CatGenerales;
using EGAXamarinAppDAE.Models;
using EGAXamarinAppDAE.Services.CatGenerales;
using EGAXamarinAppDAE.ViewModels.Base;

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;
using System.Linq;
namespace EGAXamarinAppDAE.ViewModels
{
    public class FicVmCatEdificiosView: INotifyPropertyChanged
    {

        #region VARIABLES LOCALES
        private IFicSrvNavigationInventario IFicSrvNavigationInventario;

        private string _LabelAlias, _LabelDes, _LabelClave;
        private short _LabelId, _LabelPrioridad;

        private ICommand _FicMetRegesarCatEdificiosListICommand;

        public object FicNavigationContextC { get; set; }
        #endregion

        public FicVmCatEdificiosView(IFicSrvNavigationInventario IFicSrvNavigationInventario)
        {
            this.IFicSrvNavigationInventario = IFicSrvNavigationInventario;
        }

        #region VARIABLES DE CONEXION A LA VIEW
        public string LabelAlias
        {
            get { return _LabelAlias; }
            set
            {
                if (value != null)
                {
                    _LabelAlias = value;
                    RaisePropertyChanged("LabelAlias");
                }
            }

        }
        public string LabelDes
        {
            get { return _LabelDes; }
            set
            {
                if (value != null)
                {
                    _LabelDes = value;
                    RaisePropertyChanged("LabelDes");
                }
            }
        }
        public string LabelClave
        {
            get { return _LabelClave; }
            set
            {
                if (value != null)
                {
                    _LabelClave = value;
                    RaisePropertyChanged("LabelClave");
                }
            }
        }

        public short LabelId
        {
            get { return _LabelId; }
            set
            {
                if (value != null)
                {
                    _LabelId = value;
                    RaisePropertyChanged("LabelId");
                }
            }
        }

        public short LabelPrioridad
        {
            get { return _LabelPrioridad; }
            set
            {
                if (value != null)
                {
                    _LabelPrioridad = value;
                    RaisePropertyChanged("LabelPrioridad");
                }
            }
        }

        #endregion

        public async void OnAppearing()
        {
            var source_eva_cat_edificios = FicNavigationContextC as eva_cat_edificios;

            _LabelId = source_eva_cat_edificios.IdEdificio;
            _LabelAlias = source_eva_cat_edificios.Alias;
            _LabelDes = source_eva_cat_edificios.DesEdificio;
            _LabelPrioridad = source_eva_cat_edificios.Prioridad;
            _LabelClave = source_eva_cat_edificios.Clave;

            RaisePropertyChanged("LabelId");
            RaisePropertyChanged("LabelAlias");
            RaisePropertyChanged("LabelDes");
            RaisePropertyChanged("LabelPrioridad");
            RaisePropertyChanged("LabelClave");

        }

        #region MANEJO DE COMANDOS
        //private ICommand _FicMetRegesarCatEdificiosListICommand, _SaveCommand;
        public ICommand FicMetRegesarCatEdificiosListICommand
        {
            get
            {
                return _FicMetRegesarCatEdificiosListICommand = _FicMetRegesarCatEdificiosListICommand ??
                    new FicVmDelegateCommand(FicMetRegresarCatEdificios);
            }
        }

        private async void FicMetRegresarCatEdificios()
        {
            try
            {
                IFicSrvNavigationInventario.FicMetNavigateTo<FicVmCatEdificiosList>(FicNavigationContextC);
            }
            catch (Exception e)
            {
                await new Page().DisplayAlert("ALERTA", e.Message.ToString(), "OK");
            }
        }

        #endregion

        #region  INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;
        public void RaisePropertyChanged([CallerMemberName]string propertyName = "")
        {
            var handler = PropertyChanged;
            if (handler != null)
                handler(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
    }
}
