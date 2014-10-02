using System;
using MonoTouch.UIKit;
using Xamarin.Forms;

namespace Athena.Core.iOS
{
	internal static class UIGestureRecognizerStateExtension
	{
		public static GestureState ToGestureState (this UIGestureRecognizerState state)
		{
			var name = Enum.GetName(typeof(UIGestureRecognizerState), state);

			GestureState result;

			if (Enum.TryParse<GestureState>(name, out result)) {
				return result;
			}

			return GestureState.Possible;
		}
	}
}

