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
	public class CircleViewRenderer : ViewRenderer
	{
		public override void Draw (System.Drawing.RectangleF rect)
		{
			var element = Element as CircleView;

			if (Element == null) {
				return;
			}

			var rectInner = new RectangleF (
				                (float)element.X, 
				                (float)element.Y, 
				                (float)element.WidthRequest, 
				                (float)element.HeightRequest);

			//get graphics context
			using(CGContext g = UIGraphics.GetCurrentContext ()){

				//set up drawing attributes
				g.SetLineWidth(1);

				element.BackgroundColor.ToUIColor ().SetFill ();
				element.StrokeColor.ToUIColor ().SetStroke ();

				//create geometry
				var path = new CGPath ();

				path.AddEllipseInRect (rectInner);

				path.CloseSubpath();

				//add geometry to graphics context and draw it
				g.AddPath(path);
				g.DrawPath(CGPathDrawingMode.FillStroke);
			}
		}
	}
}

