using System;
using Xamarin.Forms;

namespace FindDanceClasses.UI.Controls
{
    public class RoundedBoxView : BoxView
    {
        public static readonly BindableProperty CustomCornerRadiusProperty = BindableProperty.Create(nameof(CustomCornerRadius), typeof(double), typeof(RoundedBoxView), 0.0);
        public double CustomCornerRadius
        {
            get
            {
                return (double)GetValue(CustomCornerRadiusProperty);
            }
            set
            {
                SetValue(CustomCornerRadiusProperty, value);
            }
        }

        public static readonly BindableProperty BorderColorProperty = BindableProperty.Create(nameof(BorderColor), typeof(Color), typeof(RoundedBoxView), Color.Transparent);
        public Color BorderColor
        {
            get
            {
                return (Color)GetValue(BorderColorProperty);
            }
            set
            {
                SetValue(BorderColorProperty, value);
            }
        }

        public static readonly BindableProperty BorderWidthProperty = BindableProperty.Create(nameof(BorderWidth), typeof(double), typeof(RoundedBoxView), 0.0);
        public double BorderWidth
        {
            get
            {
                return (double)GetValue(BorderWidthProperty);
            }
            set
            {
                SetValue(BorderWidthProperty, value);
            }
        }
    }
}
