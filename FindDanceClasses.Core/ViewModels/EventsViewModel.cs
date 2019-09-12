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
    public enum TabIndex
    {
        Live = 0,
        Past = 1,
        Draft = 2
    }

    public class EventsViewModel : BaseViewModel
    {
        readonly IApiService _apiService;

        readonly IMvxMessenger _messenger;

        #region Constructors

        public EventsViewModel(IMvxNavigationService navigationService, IDialogService dialogService, IMvxLogProvider logProvider,
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

            LoadData();
        }


        #endregion

        #region Fields

        List<EventItemViewModel> _allEvents = new List<EventItemViewModel>();

        #endregion

        #region Properties




        private ObservableCollection<EventItemViewModel> _liveEvents = new ObservableCollection<EventItemViewModel>();
        public ObservableCollection<EventItemViewModel> LiveEvents
        {
            get
            {
                return _liveEvents;
            }
            set
            {
                SetProperty(ref _liveEvents, value);
            }
        }

        private ObservableCollection<EventItemViewModel> _draftEvents = new ObservableCollection<EventItemViewModel>();
        public ObservableCollection<EventItemViewModel> DraftEvents
        {
            get
            {
                return _draftEvents;
            }
            set
            {
                SetProperty(ref _draftEvents, value);
            }
        }

        private int _tabIndex = 0;
        public int TabIndex
        {
            get
            {
                return _tabIndex;
            }
            set
            {
                SetProperty(ref _tabIndex, value);
            }
        }

        #region Tab properties

        private string _liveBgColor = "#14458E";
        public string LiveBgColor
        {
            get
            {
                return _liveBgColor;
            }
            set
            {
                SetProperty(ref _liveBgColor, value);
            }
        }

        private string _liveTextColor = "#ffffff";
        public string LiveTextColor
        {
            get
            {
                return _liveTextColor;
            }
            set
            {
                SetProperty(ref _liveTextColor, value);
            }
        }

        private string _pastBgColor = "#ffffff";
        public string PastBgColor
        {
            get
            {
                return _pastBgColor;
            }
            set
            {
                SetProperty(ref _pastBgColor, value);
            }
        }

        private string _pastTextColor = "#14458E";
        public string PastTextColor
        {
            get
            {
                return _pastTextColor;
            }
            set
            {
                SetProperty(ref _pastTextColor, value);
            }
        }

        private string _draftBgColor = "#ffffff";
        public string DraftBgColor
        {
            get
            {
                return _draftBgColor;
            }
            set
            {
                SetProperty(ref _draftBgColor, value);
            }
        }

        private string _draftTextColor = "#14458E";
        public string DraftTextColor
        {
            get
            {
                return _draftTextColor;
            }
            set
            {
                SetProperty(ref _draftTextColor, value);
            }
        }

        #endregion

        #endregion

        #region Commands

        public IMvxAsyncCommand OpenMenuCommand => new MvxAsyncCommand(OpenMenu);

        private async Task OpenMenu()
        {

            _messenger.Publish(new MenuActionMessage(this, true));
        }

        public IMvxAsyncCommand<TabIndex> SelectTabCommand => new MvxAsyncCommand<TabIndex>(SelectTab);

        private async Task SelectTab(TabIndex index)
        {
            TabIndex = (int)index;

            switch (index)
            {
                case ViewModels.TabIndex.Live:
                    LiveBgColor = "#14458E";
                    LiveTextColor = "#ffffff";
                    PastBgColor = "#fffffff";
                    PastTextColor = "#14458E";
                    DraftBgColor = "#fffffff";
                    DraftTextColor = "#14458E";
                    break;
                case ViewModels.TabIndex.Draft:
                    DraftBgColor = "#14458E";
                    DraftTextColor = "#ffffff";
                    PastBgColor = "#fffffff";
                    PastTextColor = "#14458E";
                    LiveBgColor = "#fffffff";
                    LiveTextColor = "#14458E";
                    break;
                default:
                    PastBgColor = "#14458E";
                    PastTextColor = "#ffffff";
                    DraftBgColor = "#fffffff";
                    DraftTextColor = "#14458E";
                    LiveBgColor = "#fffffff";
                    LiveTextColor = "#14458E";
                    break;
            }
        }

        #endregion


        #region Methods

        async void LoadData()
        {
            try
            {
                ShowLoading();

                var result = await _apiService.GetEvents(2669);
                if (result.Err != null)
                {
                    await DialogService.ShowMessage(result.Err.Message);
                }
                else
                {
                    _allEvents = result.Result.Select(t => new EventItemViewModel()
                    {
                        Name = t.Name,
                        ClassID = t.ClassID,
                        IsClassLive = t.IsClassLive,
                        VenueAddress = t.VenueAddress
                    }).ToList();

                    LiveEvents = new ObservableCollection<EventItemViewModel>(_allEvents.Where(e => e.IsClassLive));
                    DraftEvents = new ObservableCollection<EventItemViewModel>(_allEvents.Where(e => !e.IsClassLive));
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
