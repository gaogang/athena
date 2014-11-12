using System;
using System.ComponentModel;
using System.Windows.Input;
using Android.Views;
using Athena.Core.Pcl.Controls;
using Athena.Core.Pcl.Gesture;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using Athena.Core.Android.Renderers;
using Athena.ImagePicker.Android.Gesture;

[assembly: ExportRenderer (typeof(GestureAwareContentView), typeof(GestureAwareContentViewRenderer))]
namespace Athena.Core.Android.Renderers
{
	public class GestureAwareContentViewRenderer : 
			FrameRenderer
	{
		private GestureDetector _gestureDetector;

		private ScaleGestureDetector _scaleGestureDetector;

		public GestureAwareContentViewRenderer ()
		{
		}

		protected override void OnElementChanged (ElementChangedEventArgs<Frame> e)
		{
			base.OnElementChanged (e);

			if (e.NewElement == null) {
				if (_gestureDetector != null) {
					_gestureDetector.Dispose ();
					_gestureDetector = null;
				}

				return;
			}

			IGestureAwareView view = e.NewElement as IGestureAwareView;

			if (view == null) {
				throw new InvalidOperationException ();
			}

			if (_gestureDetector == null) {
				_gestureDetector = new GestureDetector (
					new GestureDetectorListener (view));
			}
		}

		public override bool OnTouchEvent (MotionEvent e)
		{
			_gestureDetector.OnTouchEvent (e);

			return false;
		}
	}
}

