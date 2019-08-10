using System;
using System.Collections.Generic;
using System.Diagnostics;
using FindDanceClasses.Core.ViewModels;
using MvvmCross.Forms.Presenters.Attributes;
using Xamarin.Forms;

namespace FindDanceClasses.UI.Pages
{
    [MvxMasterDetailPagePresentation(MasterDetailPosition.Root)]
    public partial class DashboardPage : BaseMasterDetailPage<DashboardViewModel>, IDashboardView
    {
        public DashboardPage()
        {
            InitializeComponent();
        }


        protected override void OnViewModelSet()
        {
            base.OnViewModelSet();

            this.ViewModel.View = this;
        }

        #region Implements

        public void HideMenu()
        {
            IsPresented = false;
        }

        public void ShowMenu()
        {
            IsPresented = true;
        }

        public string CurrentDetailViewModel()
        {
            var result = String.Empty;
            if (this.Detail is NavigationPage nav)
            {
                result = nav.CurrentPage.BindingContext.GetType().Name;
            }
            else if (this.Detail is ContentPage ctPage)
            {
                result = ctPage.BindingContext.GetType().Name;
            }
            Debug.WriteLine("Current Detail ViewModel: " + result);

            return result;
        }

        #endregion
    }
}
