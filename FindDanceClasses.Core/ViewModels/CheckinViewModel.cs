using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using FindDanceClasses.Core.Commands;
using FindDanceClasses.Core.Messages;
using FindDanceClasses.Core.Models;
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

        IList<Ticket> _allTickets = new List<Ticket>();

        CancellationTokenSource cancellationTokenSource = new CancellationTokenSource();

        CancellationToken token;


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

            await LoadData();
        }


        #endregion

        #region Properties

        private string _keyWord;
        public string KeyWord
        {
            get
            {
                return _keyWord;
            }
            set
            {
                SetProperty(ref _keyWord, value);
                DoSearch();
            }
        }

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

        public IMvxCommand OpenMenuCommand => new MvxCommand(OpenMenu);

        private void OpenMenu()
        {

            _messenger.Publish(new MenuActionMessage(this, true));
        }

        public IMvxAsyncCommand ScanCommand => new MvxAsyncCommand(Scan);

        private async Task Scan()
        {
            var result = await this.NavigationService.Navigate<ScanViewModel, int, string>(_eventId);
            if (!String.IsNullOrEmpty(result))
            {
                await LoadData();
            }
        }

        #endregion


        #region Methods

        async Task DoSearch()
        {
            if (cancellationTokenSource != null)
            {
                cancellationTokenSource.Cancel();
                cancellationTokenSource = null;
                cancellationTokenSource = new CancellationTokenSource();
            }

            if (String.IsNullOrEmpty(this.KeyWord))
            {
                await LoadData();

                Debug.WriteLine($"Reload all ticket");
                return;
            }

            token = cancellationTokenSource.Token;



            await Task.Run(async () =>
            {
                bool isCanceled = false;
                token.Register(() =>
                {

                    _allTickets = new List<Ticket>();
                    Debug.WriteLine($"Cancel {KeyWord}");
                    isCanceled = true;
                });

                await Task.Delay(1000);

                Debug.WriteLine($"{KeyWord} : {isCanceled}");

                if (!isCanceled)
                {
                    Debug.WriteLine($"Started search api: {KeyWord}");

                    ShowLoading();

                    var result = await _apiService.SearchTickets(2669, _eventId, KeyWord);

                    Debug.WriteLine($"Ended search api: {KeyWord}");

                    if (result.Result != null)
                    {
                        _allTickets = result.Result;
                    }
                    else
                    {
                        Debug.WriteLine($"Error {result.Err.Message}");
                    }
                }

            }, token);

            Debug.WriteLine($"{KeyWord} {_allTickets.Count}");

            Tickets = new ObservableCollection<TicketItemViewModel>(_allTickets.Select(t => new TicketItemViewModel()
            {
                QrCode = t.QrCode,
                IsCheckedIn = t.IsCheckedIn,
                IsNotCheckedIn = !t.IsCheckedIn,
                Name = t.Name,
                SingleChargeItemID = t.SingleChargeItemID,
                FullName = $"{t.FirstName} {t.LastName} - Order #{t.SingleChargeItemID}"
            }));

            HideLoading();
        }

        async Task LoadData()
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
                    _allTickets = result.Result;
                    Tickets = new ObservableCollection<TicketItemViewModel>(_allTickets.Select(t => new TicketItemViewModel()
                    {
                        QrCode = t.QrCode,
                        IsCheckedIn = t.IsCheckedIn,
                        IsNotCheckedIn = !t.IsCheckedIn,
                        Name = t.Name,
                        SingleChargeItemID = t.SingleChargeItemID,
                        FullName = $"{t.FirstName} {t.LastName} - Order #{t.SingleChargeItemID}"
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
