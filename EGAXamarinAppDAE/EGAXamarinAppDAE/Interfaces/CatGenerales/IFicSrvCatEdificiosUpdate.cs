using EGAXamarinAppDAE.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EGAXamarinAppDAE.Interfaces.CatGenerales
{
    public interface IFicSrvCatEdificiosUpdate
    {
        Task<string> Update_eva_cat_edificios(eva_cat_edificios eva_cat_edificios);
    }
}
