using System;
using System.Collections.Generic;
using FindDanceClasses.Core.ViewModels;
using MvvmCross.Forms.Presenters.Attributes;
using Xamarin.Forms;

namespace FindDanceClasses.UI.Pages
{
    [MvxMasterDetailPagePresentation]
    public partial class EventsPage : BasePage<EventsViewModel>
    {
        public EventsPage()
        {
            InitializeComponent();

        }
    }
}
