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
    public class FicVmCatEdificiosImportarExportar
    {

        #region VARIABLES
        //Interfaces
        private IFicSrvCatEdificiosImportarExportar IFicSrvCatEdificiosImportarExportar;

        //Comandos
        private ICommand _ImportarCommand,_ExportarCommand;

        #endregion

        public FicVmCatEdificiosImportarExportar(IFicSrvCatEdificiosImportarExportar IFicSrvCatEdificiosImportarExportar)
        {
            this.IFicSrvCatEdificiosImportarExportar = IFicSrvCatEdificiosImportarExportar;
        }

        public async void OnAppearing()
        {

        }

        #region Commandos

        public ICommand ImportCommand
        {
            get { return _ImportarCommand = _ImportarCommand ?? new FicVmDelegateCommand(ImportarCommandExecute); }
        }

        private async void ImportarCommandExecute()
        {
            try
            {
                var res = await IFicSrvCatEdificiosImportarExportar.Importar_eva_cat_edificios();

                if (res == "OK")
                {
                    await new Page().DisplayAlert("Importar", "Importacion exitosa!", "OK");
                }
                else
                {
                    await new Page().DisplayAlert("Error al importar", res.ToString(), "OK");
                }

            }
            catch (Exception e)
            {
                await new Page().DisplayAlert("Exception", e.Message.ToString(), "OK");
            }
        }

        public ICommand ExportCommand
        {
            get { return _ExportarCommand = _ExportarCommand ?? new FicVmDelegateCommand(ExportarCommandExecute); }
        }

        private async void ExportarCommandExecute()
        {
            try
            {
                string res = await IFicSrvCatEdificiosImportarExportar.Exportar_eva_cat_edificios();

                System.Diagnostics.Debug.WriteLine("res\n"+res);

                if (res =="OK")
                {
                    await new Page().DisplayAlert("Exportar", "Exportacion exitosa!", "OK");
                }
                else
                {
                    await new Page().DisplayAlert("Error al exportar", res.ToString(), "OK");
                }

            }
            catch (Exception e)
            {
                await new Page().DisplayAlert("Exception", e.Message.ToString(), "OK");
            }
        }

        #endregion

    }
}
