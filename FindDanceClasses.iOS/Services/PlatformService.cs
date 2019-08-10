using System;
using System.Drawing;
using FindDanceClasses.UI.Services;
using Foundation;
using UIKit;

namespace FindDanceClasses.iOS.Services
{
    public class PlatformService : IPlatformService
    {
        public bool GetHasHardwareKeys()
        {
            return false;
        }

        public double GetLines(string text, double width, double fontSize, string fontName = null)
        {
            var nsText = new NSString(text);
            var boundSize = new SizeF((float)width, float.MaxValue);
            var options = NSStringDrawingOptions.UsesFontLeading | NSStringDrawingOptions.UsesLineFragmentOrigin;

            if (fontName == null)
            {
                fontName = "HelveticaNeue";
            }

            var attributes = new UIStringAttributes
            {
                Font = UIFont.FromName(fontName, (float)fontSize)
            };

            var sizeF = nsText.GetBoundingRect(boundSize, options, attributes, null).Size;

            //return new Xamarin.Forms.Size((double)sizeF.Width, (double)sizeF.Height);


            return ((double)sizeF.Height + 5) / UIFont.FromName(fontName, (float)fontSize).LineHeight;

        }
    }
}
