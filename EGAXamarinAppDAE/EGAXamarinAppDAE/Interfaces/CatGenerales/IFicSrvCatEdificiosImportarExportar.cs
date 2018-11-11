using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EGAXamarinAppDAE.Interfaces.CatGenerales
{
    public interface IFicSrvCatEdificiosImportarExportar
    {
        Task<string> Importar_eva_cat_edificios();
        Task<string> Exportar_eva_cat_edificios();
    }
}
