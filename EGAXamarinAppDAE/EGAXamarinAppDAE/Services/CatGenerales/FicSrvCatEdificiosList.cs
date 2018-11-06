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
    class FicSrvCatEdificiosList : IFicSrvCatEdificiosList
    {

        private readonly DBContext DBLoContext;

        public FicSrvCatEdificiosList()
        {
            DBLoContext = new DBContext(DependencyService.Get<ConfigSQLite>().EGAGetDataBasePath());
        }

        public async Task<IEnumerable<eva_cat_edificios>> FicMetGetListInventarios()
        {
            //Aqui se hace la consulta a la base de datos
            return await (from inv in DBLoContext.eva_cat_edificios select inv).AsNoTracking().ToListAsync();
        }
    }
}
