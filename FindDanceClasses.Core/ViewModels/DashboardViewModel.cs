using System;
using System.Threading.Tasks;
using FindDanceClasses.Core.Services;
using MvvmCross.Commands;
using MvvmCross.Logging;
using MvvmCross.Navigation;
using MvvmCross.ViewModels;
using MvvmCross.Plugin.Messenger;
using FindDanceClasses.Core.Messages;

namespace FindDanceClasses.Core.ViewModels
{
    public interface IDashboardView
    {
        void HideMenu();
        void ShowMenu();
        string CurrentDetailViewModel();
    }

    public class DashboardViewModel : BaseViewModel
    {
        private bool IsFirstLoad;

        public IDashboardView View { get; set; }



        private readonly MvxSubscriptionToken _token;

        public DashboardViewModel(IMvxNavigationService navigationService, IDialogService dialogService, IMvxLogProvider logProvider, IMvxMessenger messenger) : base(navigationService, dialogService, logProvider)
        {
            _token = messenger.Subscribe<MenuActionMessage>(MenuAction);
        }



        private void MenuAction(MenuActionMessage mes)
        {
            if (mes.IsOpen)
            {
                View?.ShowMenu();
            }
            else
            {
                View?.HideMenu();
            }
        }


        public override void ViewAppeared()
        {

            if (!IsFirstLoad)
            {
                MvxNotifyTask.Create(async () =>
                {
                    await ShowInitialViewModel();
                    await ShowDetailViewModel();
                });

                IsFirstLoad = true;
            }
        }

        private async Task ShowInitialViewModel()
        {
            await NavigationService.Navigate<MenuViewModel>();
        }

        private async Task ShowDetailViewModel()
        {
            await NavigationService.Navigate<HomeViewModel>();
        }

        #region Commands

        #region ShowMenuCommand

        public IMvxCommand ShowMenuCommand => new MvxCommand(ShowMenu);

        private void ShowMenu()
        {
            this.View?.ShowMenu();
        }

        #endregion

        #endregion
    }
}
