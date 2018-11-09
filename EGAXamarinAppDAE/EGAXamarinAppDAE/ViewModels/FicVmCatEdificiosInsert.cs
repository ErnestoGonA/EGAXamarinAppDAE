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
    public class FicVmCatEdificiosInsert: INotifyPropertyChanged
    {
        #region VARIABLES LOCALES
        /*Variables para comunicarse con los servicios*/
        private IFicSrvNavigationInventario IFicSrvNavigationInventario;
        private IFicSrvCatEdificiosInsert IFicSrvCatEdificiosInsert;

        /* Labels de la view */
        private string _LabelAlias, _LabelDes, _LabelClave;
        private short _LabelPrioridad;

        /*Manejo logico de los comandos de la view*/
        private ICommand _FicMetRegesarCatEdificiosListICommand, _SaveCommand;

        /*ESTA VARIABLE SIRVE PARA TOMAR EL VALOR QUE PASAMOS <DE LA VIEW PADRE A LA VIEW HIJA>*/
        public object[] FicNavigationContextC { get; set; }

        #endregion

        public FicVmCatEdificiosInsert(IFicSrvNavigationInventario ficSrvNavigationInventario, IFicSrvCatEdificiosInsert ficSrvCatEdificiosInsert)
        {
            this.IFicSrvNavigationInventario = ficSrvNavigationInventario;
            this.IFicSrvCatEdificiosInsert = ficSrvCatEdificiosInsert;
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
                if(value != null){
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
                var mdp = Application.Current.MainPage as MasterDetailPage;
                await mdp.Detail.Navigation.PopAsync();
            } catch(Exception e)
            {
                await new Page().DisplayAlert("ALERTA", e.Message.ToString(), "OK");
            }
        }

        public ICommand SaveCommand
        {
            get { return _SaveCommand = _SaveCommand ?? new FicVmDelegateCommand(SaveCommandExecute); }
        }

        private async void SaveCommandExecute()
        {
            await new Page().DisplayAlert("ALERTA", "SAVING", "OK");
            try
            {
                var RespuestaInsert = await IFicSrvCatEdificiosInsert.Insert_eva_cat_edificios(new eva_cat_edificios()
                {
                    Alias = LabelAlias,
                    DesEdificio = LabelDes,
                    Prioridad = LabelPrioridad,
                    Clave = LabelClave,
                    FechaReg = DateTime.Now,
                    FechaUltMod = DateTime.Now,
                    UsuarioReg = "ERNESTO",
                    UsuarioMod = "ERNESTO",
                    Activo ="S",
                    Borrado = "N"
                });

                if (RespuestaInsert == "OK")
                {
                    await new Page().DisplayAlert("ADD", "¡EDITADO CON EXITO!", "OK");
                    IFicSrvNavigationInventario.FicMetNavigateTo<FicVmCatEdificiosList>(FicNavigationContextC);
                }
                else
                {
                    await new Page().DisplayAlert("ADD", RespuestaInsert.ToString(), "OK");
                }//SE INSERTO EL CONTEO?
            }
            catch (Exception e)
            {
                await new Page().DisplayAlert("ALERTA", e.Message.ToString(), "OK");
            }//MANEJO GLOBAL DE ERRORES
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
