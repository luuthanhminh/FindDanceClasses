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
    public partial class CheckinPage : BasePage<CheckinViewModel>
    {
        public CheckinPage()
        {
            InitializeComponent();


        }


    }
}
