using System;
using System.ComponentModel;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using FindDanceClasses.Droid.Renderers;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using ZXing.Mobile;
using ZXing.Net.Mobile.Forms;

[assembly: ExportRenderer(typeof(ZXingScannerView), typeof(AppZXingScannerViewRenderer))]
namespace FindDanceClasses.Droid.Renderers
{
    [Preserve(AllMembers = true)]
    public class AppZXingScannerViewRenderer : ViewRenderer<ZXingScannerView, ZXing.Mobile.ZXingSurfaceView>
    {
        private Context appContext;

        public AppZXingScannerViewRenderer() : base() { }

        public AppZXingScannerViewRenderer(Context context) : base(context)
        {
            appContext = context;
        }

        public static void Init()
        {
            // Keep linker from stripping empty method
            var temp = DateTime.Now;
        }

        protected ZXingScannerView formsView;

        protected ZXingSurfaceView zxingSurface;

        protected override async void OnElementChanged(ElementChangedEventArgs<ZXingScannerView> e)
        {
            base.OnElementChanged(e);

            formsView = Element;

            if (zxingSurface == null)
            {

                // Process requests for autofocus
                formsView.AutoFocusRequested += (x, y) =>
                {
                    if (zxingSurface != null)
                    {
                        if (x < 0 && y < 0)
                            zxingSurface.AutoFocus();
                        else
                            zxingSurface.AutoFocus(x, y);
                    }
                };

                var activity = appContext as Activity;
                if (activity != null)
                    await ZXing.Net.Mobile.Android.PermissionsHandler.RequestPermissionsAsync(activity);

                zxingSurface = new ZXingSurfaceView(appContext, formsView.Options)
                {
                    LayoutParameters = new LayoutParams(LayoutParams.MatchParent, LayoutParams.MatchParent)
                };

                base.SetNativeControl(zxingSurface);

                if (formsView.IsScanning)
                    zxingSurface.StartScanning(formsView.RaiseScanResult, formsView.Options);

                if (!formsView.IsAnalyzing)
                    zxingSurface.PauseAnalysis();

                if (formsView.IsTorchOn)
                    zxingSurface.Torch(true);
            }
        }

        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);

            if (zxingSurface == null)
                return;

            switch (e.PropertyName)
            {
                case nameof(ZXingScannerView.IsTorchOn):
                    zxingSurface.Torch(formsView.IsTorchOn);
                    break;
                case nameof(ZXingScannerView.IsScanning):
                    if (formsView.IsScanning)
                        zxingSurface.StartScanning(formsView.RaiseScanResult, formsView.Options);
                    else
                        zxingSurface.StopScanning();
                    break;
                case nameof(ZXingScannerView.IsAnalyzing):
                    if (formsView.IsAnalyzing)
                        zxingSurface.ResumeAnalysis();
                    else
                        zxingSurface.PauseAnalysis();
                    break;
            }
        }

        public override bool OnTouchEvent(MotionEvent e)
        {
            var x = e.GetX();
            var y = e.GetY();

            if (zxingSurface != null)
            {
                zxingSurface.AutoFocus((int)x, (int)y);
                System.Diagnostics.Debug.WriteLine("Touch: x={0}, y={1}", x, y);
            }
            return base.OnTouchEvent(e);
        }
    }
}
