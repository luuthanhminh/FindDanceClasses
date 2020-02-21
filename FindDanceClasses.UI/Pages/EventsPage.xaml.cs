using System;
using System.Collections.Generic;
using FindDanceClasses.Core.ViewModels;
using FindDanceClasses.Core.ViewModels.Items;
using MvvmCross.Forms.Presenters.Attributes;
using Xamarin.Forms;

namespace FindDanceClasses.UI.Pages
{
    [MvxMasterDetailPagePresentation]
    public partial class EventsPage : BasePage<EventsViewModel>, IEventsView
    {
        public EventsPage()
        {
            InitializeComponent();

        }

        protected override void OnViewModelSet()
        {
            base.OnViewModelSet();
            this.ViewModel.View = this;
        }

        public EventItemViewModel GetTappedItem(object selectedObj)
        {
            if ((selectedObj as Syncfusion.ListView.XForms.ItemTappedEventArgs).ItemData is EventItemViewModel eventItemViewModel)
            {
                return eventItemViewModel;
            }

            return null;
        }
    }
}
