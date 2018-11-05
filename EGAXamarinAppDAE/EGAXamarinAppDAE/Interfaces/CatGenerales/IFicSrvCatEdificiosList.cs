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
        //Metodos para realizar crud
    }
}
