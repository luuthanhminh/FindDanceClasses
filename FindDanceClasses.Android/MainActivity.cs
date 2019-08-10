using System;

using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using FindDanceClasses.UI;
using MvvmCross.Forms.Platforms.Android.Views;
using FFImageLoading.Forms.Platform;

namespace FindDanceClasses.Droid
{
    [Activity(Label = "FindDanceClasses",
              Icon = "@mipmap/icon",
              Theme = "@style/MainTheme",
              ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : MvxFormsAppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {

            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(savedInstanceState);

            Window.ClearFlags(WindowManagerFlags.Fullscreen);
            Window.AddFlags(WindowManagerFlags.TranslucentNavigation);
            Window.AddFlags(WindowManagerFlags.TranslucentStatus);


            FFImageLoading.Forms.Platform.CachedImageRenderer.Init(true);

        }
    }
}