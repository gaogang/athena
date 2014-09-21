using System;
using Xamarin.Forms;

namespace Athena.Core.Pcl.Gesture
{
	public sealed class GestureOffset : GestureArgs
	{
		private readonly double _x;
		private readonly double _y;

		public GestureOffset (GestureState state, double x, double y) :
					base(state)
		{
			_x = x;
			_y = y;
		}

		public double X 
		{
			get {
				return _x;
			}
		}

		public double Y 
		{
			get {
				return _y;
			}
		}
	}
}

