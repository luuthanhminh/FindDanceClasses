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


    public class CheckinViewModel : BaseWithObjectViewModel<int>
    {
        readonly IApiService _apiService;

        readonly IMvxMessenger _messenger;

        int _eventId;


        #region Constructors

        public CheckinViewModel(IMvxNavigationService navigationService, IDialogService dialogService, IMvxLogProvider logProvider,
            IApiService apiService, IMvxMessenger messenger) : base(navigationService, dialogService, logProvider)
        {
            _apiService = apiService;
            _messenger = messenger;



        }

        #endregion

        #region Life cycle

        public override void Prepare(int parameter)
        {
            _eventId = parameter;
        }

        public override async Task Initialize()
        {
            await base.Initialize();

            LoadData();
        }


        #endregion

        #region Properties

        private ObservableCollection<TicketItemViewModel> _tickets = new ObservableCollection<TicketItemViewModel>();
        public ObservableCollection<TicketItemViewModel> Tickets
        {
            get
            {
                return _tickets;
            }
            set
            {
                SetProperty(ref _tickets, value);
            }
        }

        #endregion

        #region Commands

        public IMvxAsyncCommand OpenMenuCommand => new MvxAsyncCommand(OpenMenu);

        private async Task OpenMenu()
        {

            _messenger.Publish(new MenuActionMessage(this, true));
        }

        public IMvxAsyncCommand ScanCommand => new MvxAsyncCommand(Scan);

        private async Task Scan()
        {

            await this.NavigationService.Navigate<ScanViewModel>();
        }

        #endregion


        #region Methods

        async void LoadData()
        {
            try
            {
                ShowLoading();

                var result = await _apiService.GetTickets(2669, _eventId);

                if (result.Err != null)
                {
                    await DialogService.ShowMessage(result.Err.Message);
                }
                else
                {
                    Tickets = new ObservableCollection<TicketItemViewModel>(result.Result.Select(t => new TicketItemViewModel()
                    {
                        QrCode = t.QrCode,
                        IsCheckedIn = t.IsCheckedIn,
                        IsNotCheckedIn = !t.IsCheckedIn,
                        Name = t.Name,
                        FullName = $"{t.LastName} {t.FirstName}"
                    }));
                }
            }
            catch (Exception ex)
            {

            }
            finally
            {
                HideLoading();
            }
        }

        #endregion
    }
}
