using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using FindDanceClasses.Core.Commands;
using FindDanceClasses.Core.Messages;
using FindDanceClasses.Core.Services;
using FindDanceClasses.Core.ViewModels.Items;
using MvvmCross.Commands;
using MvvmCross.Logging;
using MvvmCross.Navigation;
using MvvmCross.Plugin.Messenger;

namespace FindDanceClasses.Core.ViewModels
{


    public class CheckinViewModel : BaseViewModel
    {
        readonly IApiService _apiService;

        readonly IMvxMessenger _messenger;





        #region Constructors

        public CheckinViewModel(IMvxNavigationService navigationService, IDialogService dialogService, IMvxLogProvider logProvider,
            IApiService apiService, IMvxMessenger messenger) : base(navigationService, dialogService, logProvider)
        {
            _apiService = apiService;
            _messenger = messenger;



        }

        #endregion

        #region Life cycle

        public override async Task Initialize()
        {
            await base.Initialize();


        }


        #endregion

        #region Commands

        public IMvxAsyncCommand OpenMenuCommand => new MvxAsyncCommand(OpenMenu);

        private async Task OpenMenu()
        {

            _messenger.Publish(new MenuActionMessage(this, true));
        }

        #endregion



    }
}
