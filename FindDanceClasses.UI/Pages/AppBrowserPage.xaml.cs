using System;
using System.Collections.Generic;

using Xamarin.Forms;
using FindDanceClasses.Core.ViewModels;

namespace FindDanceClasses.UI.Pages
{
    public partial class AppBrowserPage : BasePage<AppBrowserViewModel>, IAppBrowserView
    {
        public AppBrowserPage()
        {
            InitializeComponent();
        }

        public void LoadUrl(string url)
        {

            var urlSource = new UrlWebViewSource();
            urlSource.Url = url;
            webView.Source = urlSource;
        }

        protected override void OnViewModelSet()
        {
            base.OnViewModelSet();

            ViewModel.View = this;
        }
    }
}
