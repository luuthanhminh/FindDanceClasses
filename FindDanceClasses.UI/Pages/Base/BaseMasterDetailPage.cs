using System;
using MvvmCross;
using MvvmCross.Forms.Views;
using MvvmCross.ViewModels;

namespace FindDanceClasses.UI.Pages
{
    public abstract class BaseMasterDetailPage<TViewModel> : MvxMasterDetailPage<TViewModel> where TViewModel : MvxViewModel
    {
        public BaseMasterDetailPage()
        {
            Xamarin.Forms.NavigationPage.SetHasNavigationBar(this, false);

        }

    }
}
