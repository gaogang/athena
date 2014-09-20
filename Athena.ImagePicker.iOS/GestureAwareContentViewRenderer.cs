using System;
using System.Windows.Input;
using Athena.Core.Pcl.Gesture;
using Athena.ImagePicker.Pcl.CustomControls;
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
				if (_longPressGestureRecognizer != null) {
					RemoveGestureRecognizer (_longPressGestureRecognizer);
				}
				if (_pinchGestureRecognizer != null) {
					RemoveGestureRecognizer (_pinchGestureRecognizer);
				}
				if (_panGestureRecognizer != null) {
					RemoveGestureRecognizer (_panGestureRecognizer);
				}
				if (_swipeGestureRecognizer != null) {
					RemoveGestureRecognizer (_swipeGestureRecognizer);
				}
				if (_rotationGestureRecognizer != null) {
					RemoveGestureRecognizer (_rotationGestureRecognizer);
				}
			}

			if (e.OldElement == null) {
				var gestureView = e.NewElement;

				_longPressGestureRecognizer = new UILongPressGestureRecognizer (
					() => {
						ExecuteCommand(gestureView.LongPress);
					});

				_pinchGestureRecognizer = new UIPinchGestureRecognizer (
					sender => {
						ExecuteCommand(gestureView.Pinch);
					});

				_panGestureRecognizer = new UIPanGestureRecognizer (
					sender => {
						var offset = sender.TranslationInView(NativeView);

						ExecuteCommand(gestureView.Pan, 
							new GestureArgs(sender.State.ToGestureState(), offset.X, offset.Y));
					});

				_swipeGestureRecognizer = new UISwipeGestureRecognizer (
					() => {
						ExecuteCommand(gestureView.Swipe);
					});

				_rotationGestureRecognizer = new UIRotationGestureRecognizer (
					() => {
						ExecuteCommand (gestureView.Rotate);
					});

				AddGestureRecognizer (_longPressGestureRecognizer);
				AddGestureRecognizer (_pinchGestureRecognizer);
				AddGestureRecognizer (_panGestureRecognizer);
				AddGestureRecognizer (_swipeGestureRecognizer);
				AddGestureRecognizer (_rotationGestureRecognizer);
			}
		}

		private static void ExecuteCommand(ICommand command, object parameter = null) 
		{
			if (command != null &&
				command.CanExecute (parameter)) {
				command.Execute (parameter);
			}
		}
	}
}

