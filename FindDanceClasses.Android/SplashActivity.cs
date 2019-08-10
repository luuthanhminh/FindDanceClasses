using System;
using System.Threading.Tasks;
using Android.App;
using Android.Content.PM;
using Android.OS;
using Android.Views;
using FindDanceClasses.UI;
using MvvmCross.Forms.Platforms.Android.Views;

namespace FindDanceClasses.Droid
{
    [Activity(
        Label = "FindDanceClasses"
        , MainLauncher = true
        , Icon = "@mipmap/icon"
        , Theme = "@style/MainTheme"
        , NoHistory = true
        , ScreenOrientation = ScreenOrientation.Portrait)]
    public class SplashActivity : MvxFormsSplashScreenAppCompatActivity<Setup, CoreApp, App>
    {
        public SplashActivity() : base(Resource.Layout.SplashScreen)
        {

        }

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            Window.AddFlags(WindowManagerFlags.Fullscreen);
        }

        protected override Task RunAppStartAsync(Bundle bundle)
        {
            StartActivity(typeof(MainActivity));
            return Task.CompletedTask;
        }
    }
}
