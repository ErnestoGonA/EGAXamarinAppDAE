using EGAXamarinAppDAE.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EGAXamarinAppDAE.Interfaces.CatGenerales
{
    public interface IFicSrvCatEdificiosList
    {
        Task<IEnumerable<eva_cat_edificios>> FicMetGetListInventarios();
        Task<string> Remove_eva_cat_edificios(eva_cat_edificios eva_cat_edificios);
        //Metodos para realizar crud
    }
}
