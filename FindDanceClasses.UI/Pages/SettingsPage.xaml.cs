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

namespace FindDanceClasses.UI.Pages
{
    [MvxMasterDetailPagePresentation]
    public partial class SettingsPage : BasePage<SettingsViewModel>
    {
        public SettingsPage()
        {
            InitializeComponent();


        }


    }
}
