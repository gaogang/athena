using System;
using System.ComponentModel;
using System.Windows.Input;
using Android.Views;
using Athena.Core.Pcl.Controls;
using Athena.Core.Pcl.Gesture;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using Athena.Core.Android.Renderers;

[assembly: ExportRenderer (typeof(GestureAwareContentView), typeof(GestureAwareContentViewRenderer))]
namespace Athena.Core.Android.Renderers
{
	public class GestureAwareContentViewRenderer : 
			VisualElementRenderer<GestureAwareContentView>, 
			GestureDetector.IOnGestureListener
	{
		private GestureDetector _gestureDetector;

		public GestureAwareContentViewRenderer ()
		{
		}

		private GestureAwareContentView View {
			get;
			set;
		}

		protected override void OnElementChanged (ElementChangedEventArgs<GestureAwareContentView> e)
		{
			base.OnElementChanged (e);

			_gestureDetector = new GestureDetector (this);

			View = e.NewElement;
		}

		public bool OnDown(MotionEvent e)
		{
			return true;
		}

		public bool OnFling(MotionEvent e1, MotionEvent e2, float velocityX, float velocityY)
		{
			return true;
		}

		public void OnLongPress(MotionEvent e) 
		{
			if (View == null) {
				return;
			}

			GestureUtil.ExecuteCommand(View.LongPress, 
				new GestureOffset(GestureState.Began, e.GetX(), e.GetY()));
		}

		public bool OnScroll(MotionEvent e1, MotionEvent e2, float distanceX, float distanceY)
		{
			return true;
		}

		public void OnShowPress(MotionEvent e) 
		{
		}

		public bool OnSingleTapUp(MotionEvent e)
		{
			return false;
		}
	}
}

