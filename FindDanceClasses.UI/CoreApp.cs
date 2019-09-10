using System;
using System.Threading.Tasks;
using MvvmCross.IoC;
using MvvmCross.ViewModels;
using FindDanceClasses.Core.ViewModels;
using MvvmCross;
using FindDanceClasses.Core.Services;
using FindDanceClasses.UI.Services;
using FindDanceClasses.Core.Helpers;

namespace FindDanceClasses.UI
{
    public class CoreApp : MvxApplication
    {
        public override void Initialize()
        {
            CreatableTypes()
                .EndingWith("Service")
                .AsInterfaces()
                .RegisterAsLazySingleton();

            if (String.IsNullOrEmpty(AppSettings.Token))
            {
                RegisterAppStart<LoginViewModel>();
            }
            else
            {
                RegisterAppStart<DashboardViewModel>();
            }


            Mvx.IoCProvider.RegisterType<IDialogService, DialogService>();
            Mvx.IoCProvider.RegisterType<ILoginApiService, LoginApiService>();
            Mvx.IoCProvider.RegisterType<IApiService, ApiService>();
        }

        /// <summary>
        /// Do any UI bound startup actions here
        /// </summary>
        public override Task Startup()
        {
            return base.Startup();
        }


        /// <summary>
        /// If the application is restarted (eg primary activity on Android 
        /// can be restarted) this method will be called before Startup
        /// is called again
        /// </summary>
        public override void Reset()
        {
            base.Reset();
        }
    }
}
