using System;
using Xamarin.Forms;

namespace Athena.Core.Pcl.Gesture
{
	public class GestureScale : GestureArgs
	{
		private readonly double _scale;

		public GestureScale (GestureState state, double scale) :
				base (state)
		{
			_scale = scale;
		}

		public double Scale 
		{
			get {
				return _scale;
			}
		}
	}
}

