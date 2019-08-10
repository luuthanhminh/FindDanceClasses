using System;
using FindDanceClasses.Core.Services;
using MvvmCross.Logging;
using MvvmCross.Navigation;

namespace FindDanceClasses.Core.ViewModels
{
    public interface IAppBrowserView
    {
        void LoadUrl(string url);
    }

    public class AppBrowserViewModel : BaseWithObjectViewModel<string>
    {
        public IAppBrowserView View { get; set; }

        private string _url;

        public AppBrowserViewModel(IMvxNavigationService navigationService, IDialogService dialogService, IMvxLogProvider logProvider) : base(navigationService, dialogService, logProvider)
        {
        }

        public override void Prepare(string url)
        {
            _url = url;
        }

        public override void ViewAppeared()
        {
            base.ViewAppeared();

            Load();
        }

        async void Load()
        {
            ShowLoading();

            try
            {


                View?.LoadUrl(_url);

            }

            catch (Exception ex)
            {

            }
            finally
            {
                HideLoading();
            }
        }
    }
}
