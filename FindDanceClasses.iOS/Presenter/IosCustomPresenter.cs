using System;
using MvvmCross.Forms.Platforms.Ios.Presenters;
using MvvmCross.Forms.Presenters;
using UIKit;
using Xamarin.Forms;
using FindDanceClasses.UI.Presenter;
using MvvmCross;

namespace FindDanceClasses.iOS.Presenter
{
    public class IosCustomPresenter : MvxFormsIosViewPresenter
    {
        public IosCustomPresenter(IUIApplicationDelegate applicationDelegate, UIWindow window, Xamarin.Forms.Application formsApplication) : base(applicationDelegate, window, formsApplication)
        {
        }

        private IMvxFormsPagePresenter _formsPagePresenter;
        public override IMvxFormsPagePresenter FormsPagePresenter
        {
            get
            {
                if (_formsPagePresenter == null)
                {
                    _formsPagePresenter = new AppCustomPresenter(this);
                    Mvx.IoCProvider.RegisterSingleton(_formsPagePresenter);
                }
                return _formsPagePresenter;
            }
            set
            {
                _formsPagePresenter = value;
            }
        }
    }
}
