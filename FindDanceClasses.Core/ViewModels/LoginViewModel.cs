using System;
using FindDanceClasses.Core.Services;
using MvvmCross.Navigation;
using MvvmCross.Commands;
using System.Threading.Tasks;
using FindDanceClasses.Core.Commands;
using FindDanceClasses.Core.Helpers;
using MvvmCross.Logging;

namespace FindDanceClasses.Core.ViewModels
{
    public class LoginViewModel : BaseViewModel
    {
        readonly ILoginApiService _loginApiService;

        public LoginViewModel(ILoginApiService loginApiService, IMvxNavigationService navigationService, IDialogService dialogService, IMvxLogProvider logProvider) : base(navigationService, dialogService, logProvider)
        {
            _loginApiService = loginApiService;
        }

        #region Properties

        #region Email

        private string _email;
        public string Email
        {
            get
            {
                return _email;
            }
            set
            {
                SetProperty(ref _email, value);
            }
        }

        #endregion

        #region Password

        private string _password;



        public string Password
        {
            get
            {
                return _password;
            }
            set
            {
                SetProperty(ref _password, value);
            }
        }

        #endregion

        #endregion

        #region Commands

        #region LoginCommand

        public IMvxAsyncCommand LoginCommand => new MvxAsyncCommand(Login);

        private async Task Login()
        {
            try
            {
                ShowLoading();

                await Task.Delay(2000);

                await ClearStackAndNavigateToPage<DashboardViewModel>();
            }
            catch (Exception ex)
            {
                await DialogService.ShowMessage("Error", ex.Message, "OK");
            }
            finally
            {
                HideLoading();
            }
        }

        #endregion

        #endregion
    }
}
