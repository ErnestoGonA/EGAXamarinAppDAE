using EGAXamarinAppDAE.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EGAXamarinAppDAE.Interfaces.CatGenerales
{
    public interface IFicSrvCatEdificiosInsert
    {
        Task<string> Insert_eva_cat_edificios(eva_cat_edificios eva_cat_edificios);
    }
}
