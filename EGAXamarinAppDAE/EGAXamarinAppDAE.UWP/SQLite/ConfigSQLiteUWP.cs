using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

using Windows.Storage;
using Xamarin.Forms;

using EGAXamarinAppDAE.Interfaces.SQLite;
using EGAXamarinAppDAE.UWP.SQLite;

[assembly: Dependency(typeof(ConfigSQliteUWP))]
namespace EGAXamarinAppDAE.UWP.SQLite
{
    class ConfigSQliteUWP : ConfigSQLite
    {
        public string EGAGetDataBasePath()
        {
            return Path.Combine(ApplicationData.Current.LocalFolder.Path, AppSettings.EGADataBaseName);
        }

    }
}
