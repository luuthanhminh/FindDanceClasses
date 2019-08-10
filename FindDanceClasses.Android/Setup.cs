using System;
using MvvmCross.Forms.Platforms.Android.Core;
using MvvmCross.Platforms.Android.Presenters;
using FindDanceClasses.Droid.Presenter;
using MvvmCross;
using MvvmCross.Forms.Presenters;
using FindDanceClasses.UI;
using FindDanceClasses.UI.Services;
using FindDanceClasses.Droid.Services;

namespace FindDanceClasses.Droid
{
    public class Setup : MvxFormsAndroidSetup<CoreApp, App>
    {
        protected override IMvxAndroidViewPresenter CreateViewPresenter()
        {
            var presenter = new AndroidCustomPresenter(this.GetViewAssemblies(), this.FormsApplication);
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
