using System;
using Android.Content;
using Android.Graphics;
using Android.Util;
using FindDanceClasses.Droid.Renderers;
using FindDanceClasses.UI.Controls;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(RoundedBoxView), typeof(RoundedBoxViewRenderer))]
namespace FindDanceClasses.Droid.Renderers
{
    public class RoundedBoxViewRenderer : BoxRenderer
    {
        private float _cornerRadius;
        private RectF _bounds;
        private Path _path;

        public RoundedBoxViewRenderer(Context context) : base(context)
        {
        }

        protected override void OnElementChanged(ElementChangedEventArgs<BoxView> e)
        {
            base.OnElementChanged(e);
            if (Element == null)
            {
                return;
            }
            var element = (RoundedBoxView)Element;
            _cornerRadius = TypedValue.ApplyDimension(ComplexUnitType.Dip, (float)element.CustomCornerRadius, Context.Resources.DisplayMetrics);
        }
        protected override void OnSizeChanged(int w, int h, int oldw, int oldh)
        {
            base.OnSizeChanged(w, h, oldw, oldh);
            if (w != oldw && h != oldh)
            {
                _bounds = new RectF(0, 0, w, h);
            }
            _path = new Path();
            _path.Reset();
            _path.AddRoundRect(_bounds, _cornerRadius, _cornerRadius, Path.Direction.Cw);
            _path.Close();
        }
        public override void Draw(Canvas canvas)
        {
            canvas.Save();
            canvas.ClipPath(_path);

            base.Draw(canvas);
            canvas.Restore();
            Paint mStrokePaint = new Paint();
            mStrokePaint.SetStyle(Paint.Style.Stroke);
            mStrokePaint.AntiAlias = true;
            mStrokePaint.Color = ((RoundedBoxView)Element).BorderColor.ToAndroid();
            mStrokePaint.StrokeWidth = (float)((RoundedBoxView)Element).BorderWidth;
            canvas.DrawPath(_path, mStrokePaint);
        }
    }
}
