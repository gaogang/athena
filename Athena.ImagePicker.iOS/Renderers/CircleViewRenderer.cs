using System;
using System.Drawing;
using Athena.Core.Pcl.Controls;
using MonoTouch.CoreGraphics;
using MonoTouch.UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;
using Athena.ImagePicker.iOS.Renderers;

[assembly: ExportRenderer (typeof(CircleView), typeof(CircleViewRenderer))]
namespace Athena.ImagePicker.iOS.Renderers
{
	public class CircleViewRenderer : BoxRenderer
	{
		public override void Draw (RectangleF rect)
		{
			var element = Element as CircleView;

			if (element == null) {
				throw new InvalidOperationException ("Element must be a Circle View type");
			}

			//get graphics context
			using(CGContext context = UIGraphics.GetCurrentContext ()){

				context.SetFillColor(element.FillColor.ToCGColor());
				context.SetStrokeColor(element.StrokeColor.ToCGColor());
				context.SetLineWidth(element.StrokeThickness);

				if (element.StrokeDash > 1.0f) {
						context.SetLineDash (
						0, 
						new float[] { element.StrokeDash, element.StrokeDash });
				}

				//create geometry
				var path = new CGPath ();

				path.AddEllipseInRect (rect);

				path.CloseSubpath();

				//add geometry to graphics context and draw it
				context.AddPath(path);
				context.DrawPath(CGPathDrawingMode.FillStroke);
			}
		}
	}
}

