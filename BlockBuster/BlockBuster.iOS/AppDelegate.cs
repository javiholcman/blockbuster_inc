using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

using Foundation;
using UIKit;

namespace BlockBuster.iOS
{
    [Register("AppDelegate")]
    public partial class AppDelegate : global::Xamarin.Forms.Platform.iOS.FormsApplicationDelegate
    {
        public override bool FinishedLaunching(UIApplication app, NSDictionary options)
        {
            global::Xamarin.Forms.Forms.Init();

            ConfigDatabase();
            LoadLibs();
            LoadApplication(new App());

            return base.FinishedLaunching(app, options);
        }

        void ConfigDatabase()
        {
            var documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal); // Documents folder
            var path = Path.Combine(documentsPath, "../Library/"); // Library folder

            BlockBuster.DBContext.DBPath = path;
            BlockBuster.DBContext.SQLitePlatform = new SQLite.Net.Platform.XamarinIOS.SQLitePlatformIOS();
        }

        void LoadLibs()
        {
            global::ZXing.Net.Mobile.Forms.iOS.Platform.Init();
            Microsoft.WindowsAzure.MobileServices.CurrentPlatform.Init();
        }

    }
}
