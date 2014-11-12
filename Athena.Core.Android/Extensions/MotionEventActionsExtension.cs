using System;
using Android.Views;
using Xamarin.Forms;

namespace Athena.ImagePicker.Android.Extension
{
	public static class MotionEventActionsExtension
	{
		public static GestureState ToGestureState (this MotionEventActions action)
		{
			var actionInternal = action & MotionEventActions.Mask;

			GestureState result = GestureState.Possible;

			if (actionInternal == MotionEventActions.Cancel) {
				result = GestureState.Cancelled;
			}

			return result;
		}
	}
}

