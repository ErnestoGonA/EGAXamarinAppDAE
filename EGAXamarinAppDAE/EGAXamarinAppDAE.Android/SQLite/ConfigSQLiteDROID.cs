using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

using EGAXamarinAppDAE.Interfaces.SQLite;
using EGAXamarinAppDAE.Droid.SQLite;
using Xamarin.Forms;

[assembly: Dependency(typeof(ConfigSQLiteDROID))]
namespace EGAXamarinAppDAE.Droid.SQLite
{
    class ConfigSQLiteDROID : ConfigSQLite
    {

        public string EGAGetDataBasePath()
        {
            var EGAPathFile = Android.OS.Environment.GetExternalStoragePublicDirectory(Android.OS.Environment.DirectoryDownloads);
            var EGADirectorioDB = EGAPathFile.Path;
            EGADirectorioDB = EGADirectorioDB + "/DBDAE/";
            string EGAPathDB = Path.Combine(EGADirectorioDB, AppSettings.EGADataBaseName);
            return EGAPathDB;

        }
    
    }
}
