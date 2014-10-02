using System;
using Xamarin.Forms;

namespace Athena.Core.Pcl.Gesture
{
	public class GestureArgs
	{
		private readonly GestureState _state;

		public GestureArgs (GestureState state)
		{
			_state = state;
		}

		public GestureState State 
		{
			get {
				return _state;
			}
		}
	}
}

