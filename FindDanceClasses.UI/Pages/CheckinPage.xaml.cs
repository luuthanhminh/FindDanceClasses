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
using FindDanceClasses.UI.Controls.Popups;
using Rg.Plugins.Popup.Pages;
using Rg.Plugins.Popup.Services;
using Switch = Xamarin.Forms.Switch;

namespace FindDanceClasses.UI.Pages
{
    public partial class CheckinPage : BasePage<CheckinViewModel>, ICheckinView
    {
        public CheckinPage()
        {
            InitializeComponent();



        }



        protected override void OnViewModelSet()
        {
            base.OnViewModelSet();
            this.ViewModel.View = this;
        }

        public async void ShowScanDiaglog()
        {
            var ticketDialog = new TicketCheckinPopup(this.ViewModel);

            await PopupNavigation.Instance.PushAsync(ticketDialog);
        }
    }
}
