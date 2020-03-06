using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MvvmCross.Commands;
using MvvmCross.Navigation;
using MvvmCross.Presenters.Hints;
using MvvmCross.ViewModels;
using FindDanceClasses.Core.Services;
using MvvmCross.Logging;

namespace FindDanceClasses.Core.ViewModels
{
    public abstract class BaseWithObjectAndReturnViewModel<TObject, TResult> : MvxNavigationViewModel<TObject, TResult>
    {
        protected readonly IDialogService DialogService;

        #region Constructors

        public BaseWithObjectAndReturnViewModel(IMvxNavigationService navigationService, IDialogService dialogService, IMvxLogProvider logProvider) : base(logProvider, navigationService)
        {
            DialogService = dialogService;
        }

        #endregion


        #region Binding Properties

        #region IsLoading

        private bool _isLoading;



        public bool IsLoading
        {
            get
            {
                return _isLoading;
            }
            set
            {

                SetProperty(ref _isLoading, value);
            }
        }

        #endregion

        #endregion

        #region Methods

        protected void PopToPage<TViewModel>() where TViewModel : MvxViewModel
        {
            var hint = new MvxPopPresentationHint(typeof(TViewModel));
            NavigationService.ChangePresentation(hint);
        }

        protected async Task ClearStackAndNavigateToPage<TViewModel>() where TViewModel : MvxViewModel
        {
            var presentation = new MvxBundle(new Dictionary<string, string> { { PresentationConstant.CLEAR_STACK_AND_SHOW_PAGE, "" } });

            await NavigationService.Navigate<TViewModel>(presentationBundle: presentation);
        }

        protected void ShowLoading()
        {
            IsLoading = true;
        }

        protected void HideLoading()
        {
            IsLoading = false;
        }

        #endregion

        #region Commands

        public IMvxAsyncCommand CloseCommand => new MvxAsyncCommand(ClosePage);

        protected virtual async Task ClosePage()
        {
            await NavigationService.Close(this);
        }



        #endregion

    }
}
