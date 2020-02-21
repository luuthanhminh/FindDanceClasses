using System;
using System.Collections.Generic;
using System.Linq;
using FindDanceClasses.UI;
using Foundation;
using MvvmCross.Forms.Platforms.Ios.Core;
using Syncfusion.ListView.XForms.iOS;
using Syncfusion.SfBusyIndicator.XForms.iOS;
using Syncfusion.SfCarousel.XForms.iOS;
using Syncfusion.SfRating.XForms.iOS;
using Syncfusion.XForms.iOS.EffectsView;
using UIKit;

namespace FindDanceClasses.iOS
{
    // The UIApplicationDelegate for the application. This class is responsible for launching the 
    // User Interface of the application, as well as listening (and optionally responding) to 
    // application events from iOS.
    [Register("AppDelegate")]
    public partial class AppDelegate : MvxFormsApplicationDelegate<Setup, CoreApp, App>
    {
        //
        // This method is invoked when the application has loaded and is ready to run. In this 
        // method you should instantiate the window, load the UI into it and then make the window
        // visible.
        //
        // You have 17 seconds to return from this method, or iOS will terminate your application.
        //
        public override bool FinishedLaunching(UIApplication app, NSDictionary options)
        {
            UINavigationBar.Appearance.BarTintColor = UIColor.FromRGB(65, 105, 225);
            UINavigationBar.Appearance.TintColor = UIColor.FromRGB(255, 255, 255);

            SfListViewRenderer.Init();
            new SfCarouselRenderer();
            new SfBusyIndicatorRenderer();
            SfEffectsViewRenderer.Init();
            Syncfusion.SfDataGrid.XForms.iOS.SfDataGridRenderer.Init();
            FFImageLoading.Forms.Platform.CachedImageRenderer.Init();
            Syncfusion.XForms.iOS.TabView.SfTabViewRenderer.Init();
            new SfRatingRenderer();
            Syncfusion.XForms.iOS.Accordion.SfAccordionRenderer.Init();
            AiForms.Renderers.iOS.SettingsViewInit.Init();
            ZXing.Net.Mobile.Forms.iOS.Platform.Init();

            return base.FinishedLaunching(app, options);
        }
    }
}
