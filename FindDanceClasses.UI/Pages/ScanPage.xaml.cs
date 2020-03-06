using System;
using System.Collections.Generic;

using Xamarin.Forms;
using FindDanceClasses.Core.ViewModels;
using FFImageLoading.Cache;
using MvvmCross.Forms.Presenters.Attributes;
using Syncfusion.ListView.XForms;
using FindDanceClasses.Core.ViewModels.Items;
using System.Threading.Tasks;
using Syncfusion.ListView.XForms.Control.Helpers;
using Syncfusion.GridCommon.ScrollAxis;
using System.Diagnostics;
using ZXing;

namespace FindDanceClasses.UI.Pages
{
    public partial class ScanPage : BasePage<ScanViewModel>, IScanView
    {
        public ScanPage()
        {
            InitializeComponent();


        }

        protected override void OnViewModelSet()
        {
            base.OnViewModelSet();
            this.ViewModel.View = this;
        }

        public void Handle_OnScanResult(Result result)
        {
            Device.BeginInvokeOnMainThread(async () =>
            {
                this.ViewModel.CheckIn(result.Text);
            });
        }

        public void StartScanning()
        {
            _scanView.IsScanning = true;
        }

        public void StopScanning()
        {
            _scanView.IsScanning = false;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();


        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();


        }


    }
}
