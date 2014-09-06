using System;
using System.Threading.Tasks;
using Xamarin.Forms;
using Athena.ImagePicker.Pcl;

namespace Athena.ImagePicker
{
	public class ImagePicker : IImagePicker
	{
		private readonly IImagePickerProvider _imagePickerProvider;

		public ImagePicker (IImagePickerProvider imagePickerProvider)
		{
			_imagePickerProvider = imagePickerProvider;
		}

		#region IImagePicker implementation

		public Task<ImageSource> PickImageAsync ()
		{
			var tcs = new TaskCompletionSource<ImageSource> ();

			_imagePickerProvider.PickImage (i => {
				tcs.SetResult(i);
			});

			return tcs.Task;
		}

		#endregion
	}
}

