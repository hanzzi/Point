using System;

using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
//using Point.Droid.Services.Location.Models;
//using Point.Droid.Services;
using Android.Content;

namespace Point.Droid
{
    [Activity(Label = "Point", Icon = "@mipmap/icon", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {

        //LocationServiceBinder _binder;
        //LocationServiceConnection _locationServiceConnection;
        //Intent _locationServiceIntent;
        //public static MainActivity Instance;
        //private LocationServiceReciever _reciever;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            //Instance = this;
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(savedInstanceState);

            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            global::Xamarin.Forms.Forms.Init(this, savedInstanceState);
            LoadApplication(new App());
        }

        //private void RegisterService()
        //{
        //    _locationServiceConnection = new LocationServiceConnection(_binder);
        //    _locationServiceIntent = new Intent(Android.App.Application.Context, typeof(LocationService));
        //    BindService(_locationServiceIntent, _locationServiceConnection, Bind.AutoCreate);

        //}

        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }

        //[BroadcastReceiver]
        //internal class LocationServiceReciever : BroadcastReceiver
        //{
        //    public static readonly string LOCATION_UPDATED = "LOCATION_UPDATED";
        //    public override void OnReceive(Context context, Intent intent)
        //    {
        //        if (intent.Action.Equals(LOCATION_UPDATED))
        //        {
        //            //MainActivity.Instance.UpdateUI(intent);
        //        }
        //    }
        //}
    }
}