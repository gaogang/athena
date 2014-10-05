using System;
using Xamarin.Forms;

namespace Athena.Core.Pcl.Internal
{
	internal class RelativeLayoutCalculator
	{
		public static Rectangle GetRelativePositionByRadian(
			View master,
			double r, 
			double degree, 
			double widthFactor = 1.0, 
			double heightFactor = 1.0)
		{
			var x = Math.Cos (degree * Math.PI / 180.0) * r;
			var y = Math.Sin (degree * Math.PI / 180.0) * r;

			var width = master.Width * widthFactor;
			var height = master.Height * heightFactor;

			var offsetX = -width / 2;
			var offsetY = -height / 2;

			return new Rectangle (
				master.Bounds.Center.X + x + offsetX,
				master.Bounds.Center.Y + y + offsetY,
				width,
				height);
		}
	}
}

