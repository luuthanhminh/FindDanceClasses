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

        public IMvxAsyncCommand GoToSettingsCommand => new MvxAsyncCommand(GoToSettings);

        private async Task GoToSettings()
        {
            _messenger.Publish<MenuActionMessage>(new MenuActionMessage(this, false));
            await Task.Delay(DELAY_MENU_TIME);
            await ClearStackAndNavigateToPage<SettingsViewModel>();
        }

        public IMvxAsyncCommand GoToEventSetupCommand => new MvxAsyncCommand(GoToEventSetup);

        private async Task GoToEventSetup()
        {
            _messenger.Publish<MenuActionMessage>(new MenuActionMessage(this, false));
            await Task.Delay(DELAY_MENU_TIME);
            await ClearStackAndNavigateToPage<EventSetupViewModel>();
        }

        public IMvxAsyncCommand GoToCheckinCommand => new MvxAsyncCommand(GoToCheckin);

        private async Task GoToCheckin()
        {
            _messenger.Publish<MenuActionMessage>(new MenuActionMessage(this, false));
            await Task.Delay(DELAY_MENU_TIME);
            await ClearStackAndNavigateToPage<CheckinViewModel>();
        }

        public IMvxAsyncCommand GoToTutorialCommand => new MvxAsyncCommand(GoToTutorial);

        private async Task GoToTutorial()
        {
            _messenger.Publish<MenuActionMessage>(new MenuActionMessage(this, false));
            await Task.Delay(DELAY_MENU_TIME);
            await ClearStackAndNavigateToPage<TutorialViewModel>();
        }

        public IMvxAsyncCommand GoToHomeCommand => new MvxAsyncCommand(GoToHome);

        private async Task GoToHome()
        {
            _messenger.Publish<MenuActionMessage>(new MenuActionMessage(this, false));
            await Task.Delay(DELAY_MENU_TIME);
            await ClearStackAndNavigateToPage<EventsViewModel>();
        }
        #endregion
    }
}
