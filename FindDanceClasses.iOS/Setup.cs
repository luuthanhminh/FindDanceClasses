using System;
using FindDanceClasses.UI;
using MvvmCross.Forms.Platforms.Ios.Core;
using MvvmCross.Platforms.Ios.Core;
using MvvmCross.Platforms.Ios.Presenters;
using FindDanceClasses.iOS.Presenter;
using MvvmCross;
using MvvmCross.Forms.Presenters;
using Xamarin.Forms.Internals;
using FindDanceClasses.UI.Services;
using FindDanceClasses.iOS.Services;

namespace FindDanceClasses.iOS
{
    public class Setup : MvxFormsIosSetup<CoreApp, App>
    {
        protected override IMvxIosViewPresenter CreateViewPresenter()
        {
            var presenter = new IosCustomPresenter(this.ApplicationDelegate, this.Window, this.FormsApplication);
            Mvx.IoCProvider.RegisterSingleton<IMvxFormsViewPresenter>(presenter);
            return presenter;
        }

        protected override void InitializeIoC()
        {
            base.InitializeIoC();

            Mvx.IoCProvider.RegisterType<IPlatformService, PlatformService>();
        }

    }
}
