﻿using System;
using MvvmCross.Forms.Views;
using FindDanceClasses.Core.ViewModels;
using Xamarin.Forms;
using MvvmCross.ViewModels;
using MvvmCross;
using FindDanceClasses.UI.Services;

namespace FindDanceClasses.UI.Pages
{
    public class BasePage<TViewModel> : MvxContentPage<TViewModel> where TViewModel : MvxViewModel
    {
        public BasePage()
        {
            NavigationPage.SetHasNavigationBar(this, false);

        }
    }
}
