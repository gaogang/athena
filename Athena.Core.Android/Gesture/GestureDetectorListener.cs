using System;
using Android.Views;
using Athena.Core.Pcl.Gesture;
using Athena.ImagePicker.Android.Extension;
using Xamarin.Forms;

namespace Athena.ImagePicker.Android.Gesture
{
	public class GestureDetectorListener : 
		GestureDetectorListenerBase, GestureDetector.IOnGestureListener
	{
		public GestureDetectorListener (IGestureAwareView view) :
			base(view)
		{
		}

		#region IOnGestureListener implementation

		public bool OnDown (MotionEvent e)
		{
			return false;
		}

		public bool OnFling (MotionEvent e1, MotionEvent e2, float velocityX, float velocityY)
		{
			return false;
		}

		public void OnLongPress (MotionEvent e)
		{
			GestureUtil.ExecuteCommand(View.LongPress, 
				new GestureOffset(e.Action.ToGestureState(), e.GetX(), e.GetY()));
		}

		public bool OnScroll (MotionEvent e1, MotionEvent e2, float distanceX, float distanceY)
		{
			return false;
		}

		public void OnShowPress (MotionEvent e)
		{
		}

		public bool OnSingleTapUp (MotionEvent e)
		{
			return false;
		}

		#endregion

		#region IDisposable implementation

		public void Dispose ()
		{
		}

		#endregion

		#region IJavaObject implementation

		public IntPtr Handle {
			get {
				return IntPtr.Zero;
			}
		}

		#endregion
	}
}

