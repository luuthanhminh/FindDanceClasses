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
    public interface IScanView
    {
        void StartScanning();
        void StopScanning();
    }

    public class ScanViewModel : BaseWithObjectAndReturnViewModel<int, string>
    {
        readonly IApiService _apiService;

        readonly IMvxMessenger _messenger;

        int _classId;

        #region Constructors

        public ScanViewModel(IMvxNavigationService navigationService, IDialogService dialogService, IMvxLogProvider logProvider,
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

        public override void Prepare(int parameter)
        {
            _classId = parameter;
        }

        protected override async Task ClosePage()
        {
            await this.NavigationService.Close(this, String.Empty);
        }


        #endregion

        #region Properties

        public IScanView View { get; set; }

        private bool _isScanning = true;
        public bool IsScanning
        {
            get
            {
                return _isScanning;
            }
            set
            {
                SetProperty(ref _isScanning, value);
            }
        }

        #endregion

        #region Commands



        #endregion


        #region Methods

        bool isChecking = false;
        public async void CheckIn(string qrCode)
        {
            try
            {
                ShowLoading();

                if (!isChecking)
                {
                    isChecking = true;
                    var result = await this._apiService.CheckInQrCode(2669, _classId, qrCode, true);

                    if (result.Err != null)
                    {
                        await DialogService.ShowMessage(result.Err.Message);
                    }
                    else
                    {
                        await this.NavigationService.Close(this, qrCode);
                        //await DialogService.ShowMessage("Checkin", "Success", "OK");

                    }
                }




            }
            catch (Exception ex)
            {
                await DialogService.ShowMessage("Error", ex.Message, "OK");
            }
            finally
            {
                HideLoading();

                isChecking = false;
            }
        }

        #endregion
    }
}
