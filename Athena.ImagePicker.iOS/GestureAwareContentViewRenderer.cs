using System;
using System.Windows.Input;
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
				var view = e.NewElement;

				_longPressGestureRecognizer = new UILongPressGestureRecognizer (
					() => {
						ExecuteCommand(view.LongPress);
					});

				_pinchGestureRecognizer = new UIPinchGestureRecognizer (
					() => {
						ExecuteCommand(view.Pinch);
					});

				_panGestureRecognizer = new UIPanGestureRecognizer (
					() => {
						ExecuteCommand(view.Pan);
					});

				_swipeGestureRecognizer = new UISwipeGestureRecognizer (
					() => {
						ExecuteCommand(view.Swipe);
					});

				_rotationGestureRecognizer = new UIRotationGestureRecognizer (
					() => {
						ExecuteCommand (view.Rotate);
					});

				AddGestureRecognizer (_longPressGestureRecognizer);
				AddGestureRecognizer (_pinchGestureRecognizer);
				AddGestureRecognizer (_panGestureRecognizer);
				AddGestureRecognizer (_swipeGestureRecognizer);
				AddGestureRecognizer (_rotationGestureRecognizer);
			}
		}

		private static void ExecuteCommand(ICommand command) 
		{
			if (command != null &&
				command.CanExecute (null)) {
				command.Execute (null);
			}
		}
	}
}

