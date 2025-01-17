﻿using System;
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
using MvvmCross.ViewModels;

namespace FindDanceClasses.Core.ViewModels
{
    public interface ICheckinView
    {
        void ShowScanDiaglog();
    }

    public class CheckinViewModel : BaseWithObjectViewModel<int>
    {
        readonly IApiService _apiService;

        readonly IMvxMessenger _messenger;

        public ICheckinView View { get; set; }

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

        private ObservableCollection<TicketItemViewModel> _scanTickets = new ObservableCollection<TicketItemViewModel>();
        public ObservableCollection<TicketItemViewModel> ScanTickets
        {
            get
            {
                return _scanTickets;
            }
            set
            {
                SetProperty(ref _scanTickets, value);
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
                var tickets = this.Tickets.Where(t => t.QrCode.Equals(result));
                if (tickets.Count() == 0)
                {
                    await this.DialogService.ShowMessage("Ticket not found");
                    return;
                }
                else
                {
                    if (tickets.Count(t => t.IsCheckedIn) == tickets.Count())
                    {
                        await DialogService.ShowMessage("App", "Attendee is already checked in", "OK");
                    }
                    else if (tickets.Count() == 1)
                    {
                        var ticket = tickets.First();
                        var checkInResult = await this._apiService.CheckInQrCode(2669, _eventId, result, true, ticket.Index);

                        if (checkInResult.Err != null)
                        {
                            await DialogService.ShowMessage(checkInResult.Err.Message);
                        }
                        else
                        {

                            await DialogService.ShowMessage("Success", $"{ticket.FullName} -  Checked in", "OK");
                            await LoadData();
                        }
                    }
                    else
                    {
                        var popupTickets = tickets.ToList();
                        popupTickets.ForEach(t => t.IsInPopup = true);
                        ScanTickets = new ObservableCollection<TicketItemViewModel>(popupTickets);
                        View?.ShowScanDiaglog();
                    }


                }


            }
        }

        #endregion


        #region Methods

        public async void Refresh()
        {
            await LoadData();
        }

        public async Task<bool> ToggleChanged(TicketItemViewModel ticket)
        {
            bool isSuccess = false;
            try
            {
                ShowLoading();

                var checkInResult = await this._apiService.CheckInQrCode(2669, _eventId, ticket.QrCode, ticket.IsCheckedIn, ticket.Index);

                if (checkInResult.Err != null)
                {
                    await DialogService.ShowMessage(checkInResult.Err.Message);
                }
                else
                {
                    var msg = ticket.IsCheckedIn ? "Checked in" : "Checked out";
                    await DialogService.ShowMessage("Success", $"{ticket.FullName} -  {msg}", "OK");
                    isSuccess = true;

                }
            }
            catch (Exception ex)
            {
                await DialogService.ShowMessage(ex.Message);
            }
            finally
            {
                HideLoading();
                //if (!ticket.IsInPopup && isSuccess) 
            }

            return isSuccess;

        }

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
                Index = t.Index,
                SingleChargeItemID = t.SingleChargeItemID,
                OrderId = t.OrderId,
                DisplayName = $"{t.FirstName} {t.LastName} - Order #{t.OrderId}",
                FullName = $"{t.FirstName} {t.LastName}",
                ParentViewModel = this
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
                        OrderId = t.OrderId,
                        Index = t.Index,
                        DisplayName = $"{t.FirstName} {t.LastName} - Order #{t.OrderId}",
                        FullName = $"{t.FirstName} {t.LastName}",
                        ParentViewModel = this
                    }));
                }
            }
            catch (Exception ex)
            {
                await DialogService.ShowMessage(ex.Message);
            }
            finally
            {
                HideLoading();
            }
        }

        #endregion
    }
}
