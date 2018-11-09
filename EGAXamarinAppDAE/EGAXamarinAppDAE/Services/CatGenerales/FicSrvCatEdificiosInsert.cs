using EGAXamarinAppDAE.Data;
using EGAXamarinAppDAE.Interfaces.CatGenerales;
using EGAXamarinAppDAE.Interfaces.SQLite;
using EGAXamarinAppDAE.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Xamarin.Forms;

namespace EGAXamarinAppDAE.Services.CatGenerales
{
    public class FicSrvCatEdificiosInsert : IFicSrvCatEdificiosInsert
    {

        private readonly DBContext DBLoContext;

        public FicSrvCatEdificiosInsert()
        {
            DBLoContext = new DBContext(DependencyService.Get<ConfigSQLite>().EGAGetDataBasePath());
        }

        public async Task<string> Insert_eva_cat_edificios(eva_cat_edificios eva_cat_edificios)
        {
            try
            {
                await DBLoContext.AddAsync(eva_cat_edificios);
                return await DBLoContext.SaveChangesAsync() > 0 ? "OK" : "ERROR AL REGISTRAR";
            }
            catch (Exception ex)
            {
                return ex.Message.ToString();
            }
        }

    }
}
