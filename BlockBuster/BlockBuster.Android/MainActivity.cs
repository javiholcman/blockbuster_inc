using System;
using Xamarin.Forms;
using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;

[assembly: UsesFeature("android.hardware.camera", Required = false)]
[assembly: UsesFeature("android.hardware.camera.autofocus", Required = false)]


namespace BlockBuster.Droid
{

    [Activity(Label = "BlockBuster", Icon = "@drawable/icon", Theme = "@style/MyTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(bundle);

            ConfigDatabase();
            LoadLibs();
            global::Xamarin.Forms.Forms.Init(this, bundle);

            LoadApplication(new App());
        }

        void ConfigDatabase()
        {
            BlockBuster.DBContext.DBPath = global::System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
            BlockBuster.DBContext.SQLitePlatform = new SQLite.Net.Platform.XamarinAndroid.SQLitePlatformAndroid();
        }

        void LoadLibs()
        {
            Acr.UserDialogs.UserDialogs.Init(this);
            ZXing.Mobile.MobileBarcodeScanner.Initialize(Application);
            global::ZXing.Net.Mobile.Forms.Android.Platform.Init();
            Microsoft.WindowsAzure.MobileServices.CurrentPlatform.Init();
        }

        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, Permission[] grantResults)
        {
            global::ZXing.Net.Mobile.Forms.Android.PermissionsHandler.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }
}
