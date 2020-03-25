using System;
using System.Collections.Generic;
using FindDanceClasses.Core.ViewModels;
using FindDanceClasses.Core.ViewModels.Items;
using Rg.Plugins.Popup.Pages;
using Rg.Plugins.Popup.Services;
using Syncfusion.ListView.XForms;
using Xamarin.Forms;

namespace FindDanceClasses.UI.Controls.Popups
{
    public partial class TicketCheckinPopup : PopupPage
    {
        public TicketCheckinPopup(CheckinViewModel vm)
        {
            InitializeComponent();
            this.BindingContext = vm;
            PopupNavigation.Instance.Popped += Instance_Popped;

        }





        private void Instance_Popped(object sender, Rg.Plugins.Popup.Events.PopupNavigationEventArgs e)
        {
            if (this.BindingContext != null && this.BindingContext is CheckinViewModel vm)
            {
                vm.Refresh();
            }
        }

        private async void Close_Popup(object sender, EventArgs e)
        {
            await PopupNavigation.Instance.PopAsync();
        }
    }
}
