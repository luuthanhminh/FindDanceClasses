using System;
using System.Collections.Generic;
using FindDanceClasses.Core.ViewModels;
using MvvmCross.Forms.Presenters.Attributes;
using Xamarin.Forms;
using System.Threading.Tasks;

namespace FindDanceClasses.UI.Pages
{
    public partial class LoginPage : BasePage<LoginViewModel>
    {

        public LoginPage()
        {

            InitializeComponent();
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            //await Task.Delay(3000);
            //await this.Navigation.PushAsync(new MyPage());
        }
    }
}
