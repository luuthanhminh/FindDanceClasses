using System;
using Android.Graphics;
using Android.Util;
using Android.Views;
using Android.Widget;
using FindDanceClasses.UI.Services;
using Android.App;
namespace FindDanceClasses.Droid.Services
{
    public class PlatformService : IPlatformService
    {
        public bool GetHasHardwareKeys()
        {
            //int id = Android.App.Application.Context.Resources.GetIdentifier("config_showNavigationBar", "bool", "android");
            //return id > 0 && Android.App.Application.Context.Resources.GetBoolean(id);

            //Force padding for testing
            return !ViewConfiguration.Get(Android.App.Application.Context).HasPermanentMenuKey;

            //bool hasBackKey = KeyCharacterMap.DeviceHasKey(Keycode.Back);
            //bool hasHomeKey = KeyCharacterMap.DeviceHasKey(Keycode.Home);

            //return (!(hasBackKey && hasHomeKey));

        }

        private Typeface textTypeface;

        //public static Xamarin.Forms.Size MeasureTextSize(string text, double width, double fontSize, string fontName = null)
        public double GetLines(string text, double width, double fontSize, string fontName = null)
        {
            var textView = new TextView(global::Android.App.Application.Context);
            textView.Typeface = GetTypeface(fontName);
            textView.SetText(text, TextView.BufferType.Normal);
            textView.SetTextSize(ComplexUnitType.Px, (float)fontSize);

            int widthMeasureSpec = Android.Views.View.MeasureSpec.MakeMeasureSpec(
                (int)width, MeasureSpecMode.AtMost);
            int heightMeasureSpec = Android.Views.View.MeasureSpec.MakeMeasureSpec(
                0, MeasureSpecMode.Unspecified);

            textView.Measure(widthMeasureSpec, heightMeasureSpec);



            //return new Xamarin.Forms.Size((double)textView.MeasuredWidth, (double)textView.MeasuredHeight);
            return (double)textView.LineCount - 1;
        }

        private Typeface GetTypeface(string fontName)
        {
            if (fontName == null)
            {
                return Typeface.Default;
            }

            if (textTypeface == null)
            {
                textTypeface = Typeface.Create(fontName, TypefaceStyle.Normal);
            }

            return textTypeface;
        }
    }
}
