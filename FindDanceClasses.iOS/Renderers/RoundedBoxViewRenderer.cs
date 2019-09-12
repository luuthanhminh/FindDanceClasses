using System;
using CoreGraphics;
using FindDanceClasses.iOS.Renderers;
using FindDanceClasses.UI.Controls;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(RoundedBoxView), typeof(RoundedBoxViewRenderer))]
namespace FindDanceClasses.iOS.Renderers
{
    public class RoundedBoxViewRenderer : BoxRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<BoxView> e)
        {
            base.OnElementChanged(e);
            if (Element == null) return;
            Layer.MasksToBounds = true;
            Layer.BorderColor = ((RoundedBoxView)this.Element).BorderColor.ToCGColor();
            Layer.BorderWidth = (System.nfloat)((RoundedBoxView)this.Element).BorderWidth;
            Layer.CornerRadius = (float)((RoundedBoxView)this.Element).CustomCornerRadius / 2.0f;
        }
    }
}
