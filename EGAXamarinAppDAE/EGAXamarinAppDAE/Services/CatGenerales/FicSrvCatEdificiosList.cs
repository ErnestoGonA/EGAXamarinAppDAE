using EGAXamarinAppDAE.Interfaces.CatGenerales;
using EGAXamarinAppDAE.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EGAXamarinAppDAE.Services.CatGenerales
{
    class FicSrvCatEdificiosList : IFicSrvCatEdificiosList
    {
        public FicSrvCatEdificiosList()
        {
        }

        public Task<IEnumerable<eva_cat_edificios>> FicMetGetListInventarios()
        {
            //Aqui se hace la consulta a la base de datos
            throw new NotImplementedException();
        }
    }
}
