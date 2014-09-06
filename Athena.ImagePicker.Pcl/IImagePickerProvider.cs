using System;
using Xamarin.Forms;

namespace Athena.ImagePicker
{
	public interface IImagePickerProvider
	{
		void PickImage(Action<ImageSource> handler);
	}
}

