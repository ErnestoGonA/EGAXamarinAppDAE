using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

using Foundation;
using UIKit;

using Xamarin.Forms;

using EGAXamarinAppDAE.Interfaces.SQLite;
using EGAXamarinAppDAE.iOS.SQLite;

[assembly: Dependency(typeof(ConfigSQLite))]
namespace EGAXamarinAppDAE.iOS.SQLite
{
    class ConfigSQliteiOs : ConfigSQLite
    {
        public string EGAGetDataBasePath()
        {
            string docFolder = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            string libFolder = Path.Combine(docFolder, "..", "Library", "Databases");

            if (!Directory.Exists(libFolder))
            {
                Directory.CreateDirectory(libFolder);
            }

            return Path.Combine(libFolder,AppSettings.EGADataBaseName);
            //Traer la ruta especifica donde se guarda la BD

        }
    }
}