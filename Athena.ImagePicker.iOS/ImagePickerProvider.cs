using System;
using System.Reactive.Linq;
using Athena.ImagePicker.Pcl;
using MonoTouch.Foundation;
using MonoTouch.UIKit;
using Xamarin.Forms;

namespace Athena.ImagePicker.iOS
{
	public class ImagePickerProvider : IImagePickerProvider, IDisposable
	{
		private readonly UIImagePickerController _imagePicker;
		private readonly UIViewController _viewController;

		private IDisposable _imagePickedEventSubscription;
		private IDisposable _cancelEventSubscription;

		private bool _disposed = false;

		public ImagePickerProvider (UIViewController viewController)
		{
			_viewController = viewController;

			_imagePicker = new UIImagePickerController ();
			_imagePicker.SourceType = UIImagePickerControllerSourceType.PhotoLibrary;
			_imagePicker.MediaTypes = UIImagePickerController.AvailableMediaTypes (UIImagePickerControllerSourceType.PhotoLibrary);
		}

		#region IImagePickerProvider implementation

		public void PickImage (Action<ImageObject> action)
		{
			Unsubscribe ();

			Subscribe (action);

			_viewController.PresentViewController (_imagePicker, true, null);
		}

		#endregion

		#region IDisposable implementation

		public void Dispose ()
		{
			Dispose (true);
			GC.SuppressFinalize (this);
		}

		#endregion

		private void Subscribe(Action<ImageObject> handler)
		{
			if (_imagePickedEventSubscription != null) {
				throw new InvalidOperationException ("_imagePickedEventSubscription should have been disposed");
			}

			if (_cancelEventSubscription != null) {
				throw new InvalidOperationException ("_cancelEventSubscription should have been disposed");
			}

			_imagePickedEventSubscription = Observable.FromEventPattern<UIImagePickerMediaPickedEventArgs> (
				ev => _imagePicker.FinishedPickingMedia += ev,
				ev => _imagePicker.FinishedPickingMedia -= ev
			).Subscribe (
					pattern => 
					{
						if(pattern.EventArgs.Info[UIImagePickerController.MediaType].ToString() != "public.image")
						{
							return;
						}
						
						var uiImage = pattern.EventArgs.Info[UIImagePickerController.OriginalImage] as UIImage;

					    handler(new ImageObject(
												ImageSource.FromStream(()=> uiImage.AsPNG().AsStream()), 
												uiImage.Size.Width, 
												uiImage.Size.Height));

						_viewController.DismissViewController(true, null);
					});

			_cancelEventSubscription = Observable.FromEventPattern (
				ev => _imagePicker.Canceled += ev,
				ev => _imagePicker.Canceled -= ev).Subscribe (
				pattern => {

						handler(null);

						_viewController.DismissViewController(true, null);
				});
		}

		private void Unsubscribe() 
		{
			if (_imagePickedEventSubscription != null) {
				_imagePickedEventSubscription.Dispose ();
				_imagePickedEventSubscription = null;
			}

			if (_cancelEventSubscription != null) {
				_cancelEventSubscription.Dispose ();
				_cancelEventSubscription = null;
			}
		}

		private void Dispose(bool disposing)
		{
			if (!disposing) {
				return;
			}

			if (_disposed) {
				return;
			}

			Unsubscribe ();

			_disposed = true;
		}
	}
}

