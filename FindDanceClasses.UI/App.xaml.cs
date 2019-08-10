using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace FindDanceClasses.UI
{
    public partial class App : Application
    {

        public App()
        {

            Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("OTAzNzZAMzEzNzJlMzEyZTMwUHc5WGEvdmFCc1dJT2psS1pDczBYUjJBMlVNaW1YOFBtUlJaSkhqTk1QVT0=");
            InitializeComponent();
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
