using System;
using System.Windows.Input;
using Athena.Core.Pcl.Controls;
using Athena.Core.Pcl.Gesture;
using MonoTouch.UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;
using Athena.ImagePicker.iOS;

[assembly: ExportRenderer (typeof(GestureAwareContentView), typeof(GestureAwareContentViewRenderer))]
namespace Athena.ImagePicker.iOS
{
	public class GestureAwareContentViewRenderer : ViewRenderer<GestureAwareContentView, UIView>
	{
		private UILongPressGestureRecognizer _longPressGestureRecognizer;
		private UIPinchGestureRecognizer _pinchGestureRecognizer;
		private UIPanGestureRecognizer _panGestureRecognizer;
		private UISwipeGestureRecognizer _swipeGestureRecognizer;
		private UIRotationGestureRecognizer _rotationGestureRecognizer;

		protected override void OnElementChanged (ElementChangedEventArgs<GestureAwareContentView> e)
		{
			base.OnElementChanged (e);

			if (e.NewElement == null) {
				RemoveGestureRecognizer ();
			}

			if (e.OldElement == null) {
				var gestureView = e.NewElement;

				_longPressGestureRecognizer = new UILongPressGestureRecognizer (
					sender => {
						var offset = sender.LocationInView(NativeView);

						ExecuteCommand(gestureView.LongPress, 
							new GestureOffset(sender.State.ToGestureState(), offset.X, offset.Y));
					});

				_pinchGestureRecognizer = new UIPinchGestureRecognizer (
					sender => {
						var scale = sender.Scale;

						ExecuteCommand(gestureView.Pinch, 
							new GestureScale(sender.State.ToGestureState(), scale));
					});

				_panGestureRecognizer = new UIPanGestureRecognizer (
					sender => {
						var offset = sender.TranslationInView(NativeView);

						ExecuteCommand(gestureView.Pan, 
							new GestureOffset(sender.State.ToGestureState(), offset.X, offset.Y));
					});

				_swipeGestureRecognizer = new UISwipeGestureRecognizer (
					sender => {
						var offset = sender.LocationInView(NativeView);

						ExecuteCommand(gestureView.Swipe, 
							new GestureOffset(sender.State.ToGestureState(), offset.X, offset.Y));
					});

				_rotationGestureRecognizer = new UIRotationGestureRecognizer (
					sender => {
						ExecuteCommand (gestureView.Rotate);
					});

				AddGestureRecognizer (_longPressGestureRecognizer);
				AddGestureRecognizer (_pinchGestureRecognizer);
				AddGestureRecognizer (_panGestureRecognizer);
				AddGestureRecognizer (_swipeGestureRecognizer);
				AddGestureRecognizer (_rotationGestureRecognizer);
			}
		}

		private static void ExecuteCommand(ICommand command, GestureArgs parameter = null) 
		{
			if (command != null &&
				command.CanExecute (parameter)) {
				command.Execute (parameter);
			}
		}

		protected override void Dispose (bool disposing)
		{
			base.Dispose (disposing);

			if (!disposing) {
				return;
			}

			RemoveGestureRecognizer ();
		}

		private void RemoveGestureRecognizer() 
		{
			if (_longPressGestureRecognizer != null) {
				RemoveGestureRecognizer (_longPressGestureRecognizer);

				_longPressGestureRecognizer.Dispose ();
				_longPressGestureRecognizer = null;
			}
			if (_pinchGestureRecognizer != null) {
				RemoveGestureRecognizer (_pinchGestureRecognizer);

				_pinchGestureRecognizer.Dispose ();
				_pinchGestureRecognizer = null;
			}
			if (_panGestureRecognizer != null) {
				RemoveGestureRecognizer (_panGestureRecognizer);

				_panGestureRecognizer.Dispose ();
				_panGestureRecognizer = null;
			}
			if (_swipeGestureRecognizer != null) {
				RemoveGestureRecognizer (_swipeGestureRecognizer);

				_swipeGestureRecognizer.Dispose ();
				_swipeGestureRecognizer = null;
			}
			if (_rotationGestureRecognizer != null) {
				RemoveGestureRecognizer (_rotationGestureRecognizer);

				_rotationGestureRecognizer.Dispose ();
				_rotationGestureRecognizer = null;
			}
		}
	}
}

