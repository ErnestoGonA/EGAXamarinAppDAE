﻿using EGAXamarinAppDAE.Data;
using EGAXamarinAppDAE.Interfaces.CatGenerales;
using EGAXamarinAppDAE.Interfaces.SQLite;
using EGAXamarinAppDAE.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using System.Linq;
using Microsoft.EntityFrameworkCore;


namespace EGAXamarinAppDAE.Services.CatGenerales
{
    public class FicSrvCatEdificiosImportarExportar : IFicSrvCatEdificiosImportarExportar
    {

        private readonly DBContext DBLoContext;
        private readonly HttpClient Client;

        public FicSrvCatEdificiosImportarExportar()
        {
            DBLoContext = new DBContext(DependencyService.Get<ConfigSQLite>().EGAGetDataBasePath());
            Client = new HttpClient();
            Client.MaxResponseContentBufferSize = 256000;
        }

        public async Task<string> Importar_eva_cat_edificios()
        {
            try
            {
                
                var GetRes = await GetCatEdificiosAPI();

                if (GetRes != null)
                {
                    foreach(eva_cat_edificios edificio in GetRes)
                    {
                        System.Diagnostics.Debug.WriteLine("Edificio\n" + edificio.Alias);
                        var existe = await ExisteEdificio(edificio);
                        if (existe != null)
                        {
                            try
                            {

                                DBLoContext.Entry(existe).State = EntityState.Detached;
                                DBLoContext.Entry(edificio).State = EntityState.Modified;
                                await DBLoContext.SaveChangesAsync();
                                DBLoContext.Entry(edificio).State = EntityState.Detached;
                            }
                            catch (Exception e)
                            {
                                System.Diagnostics.Debug.WriteLine("Exception\n"+e.Message.ToString());
                                return e.Message.ToString();
                            }
                        }
                        else
                        {
                            try
                            {
                                DBLoContext.Add(edificio);
                                await DBLoContext.SaveChangesAsync();
                                DBLoContext.Entry(edificio).State = EntityState.Detached;
                            }
                            catch (Exception e)
                            {
                                System.Diagnostics.Debug.WriteLine("ExceptionI\n" + e.Message.ToString());
                                return e.Message.ToString();
                            }
                        }
                        
                    }
                    return "OK";
                }
                else
                {
                    return "NO HAY DATOS";
                }
            }
            catch (Exception e)
            {
                return e.Message.ToString();
            }
        }

        private async Task<eva_cat_edificios> ExisteEdificio(eva_cat_edificios edificio)
        {
            return await (from inv in DBLoContext.eva_cat_edificios where inv.IdEdificio == edificio.IdEdificio select inv).AsNoTracking().SingleOrDefaultAsync();
        }

        private async Task<List<eva_cat_edificios>> GetCatEdificiosAPI()
        {
            string url = "http://localhost:51777/api/edificios";
            var res = await Client.GetAsync(url);
            return res.IsSuccessStatusCode ? JsonConvert.DeserializeObject<List<eva_cat_edificios>>(await res.Content.ReadAsStringAsync()) : null;
        }

        public async Task<string> Exportar_eva_cat_edificios()
        {
            try
            {
                List<eva_cat_edificios> list = await (from CE in DBLoContext.eva_cat_edificios select CE).AsNoTracking().ToListAsync();
                return await PutCatEdificiosAPI(list);
            }
            catch (Exception e)
            {
                return e.Message.ToString();
            }

        }

        private async Task<string> PutCatEdificiosAPI(List<eva_cat_edificios> list)
        {
            string url = "http://localhost:51777/api/edificios";
            HttpResponseMessage res = await Client.PutAsync(new Uri(string.Format(url, string.Empty)),
                new StringContent(JsonConvert.SerializeObject(list), Encoding.UTF8, "application/json"));
            return  res.IsSuccessStatusCode ? "OK" : "ERROR";
        }

    }
}
