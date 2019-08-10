using System;
using FindDanceClasses.Core.Services;
using MvvmCross.Logging;
using MvvmCross.Navigation;
using MvvmCross.Commands;
using System.Threading.Tasks;
using MvvmCross.Plugin.Messenger;
using FindDanceClasses.Core.Messages;
using FindDanceClasses.Core.Helpers;


namespace FindDanceClasses.Core.ViewModels
{
    public class MenuViewModel : BaseViewModel
    {

        readonly IMvxMessenger _messenger;

        private const int DELAY_MENU_TIME = 200;

        bool needToCreateHomePage = false;


        public MenuViewModel(IMvxNavigationService navigationService, IDialogService dialogService, IMvxLogProvider logProvider, IMvxMessenger messenger) : base(navigationService, dialogService, logProvider)
        {
            _messenger = messenger;
        }

        #region Commands



        #endregion
    }
}
