﻿using EGAXamarinAppDAE.Data;
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
    public class FicSrvCatEdificiosUpdate : IFicSrvCatEdificiosUpdate
    {
        private readonly DBContext DBLoContext;

        public FicSrvCatEdificiosUpdate()
        {
            DBLoContext = new DBContext(DependencyService.Get<ConfigSQLite>().EGAGetDataBasePath());
        }

        public async Task<string> Update_eva_cat_edificios(eva_cat_edificios eva_cat_edificios)
        {
            try
            {
                DBLoContext.Entry(eva_cat_edificios).State = EntityState.Modified;
                var res = await DBLoContext.SaveChangesAsync() > 0 ? "OK" : "ERROR AL EDITAR";
                DBLoContext.Entry(eva_cat_edificios).State = EntityState.Detached;
                return res;
            }
            catch (Exception ex)
            {
                return ex.Message.ToString();
            }
        }
    }
}
