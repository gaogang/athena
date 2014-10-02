using System;
using Android.Graphics;
using Athena.Core.Pcl.Controls;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using Athena.Core.Android;

[assembly: ExportRenderer (typeof(CircleView), typeof(CircleViewRenderer))]
namespace Athena.Core.Android
{
	public class CircleViewRenderer : BoxRenderer
	{
		public override void Draw (Canvas canvas)
		{
			base.Draw (canvas);

			var element = Element as CircleView;
			var paint = new Paint ();

			paint.SetStyle (Paint.Style.FillAndStroke);
			paint.SetPathEffect(new DashPathEffect
				(new float[] {element.StrokeDash, element.StrokeDash}, 0.0f));

			using (var rect = new RectF (Left, Top, Right, Bottom)) {
				canvas.DrawOval (new RectF (Left, Top, Right, Bottom), paint);
			}
		}
	}
}

