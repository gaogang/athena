using System;
using Xamarin.Forms;
using Athena.ImagePicker.Pcl;

namespace Athena.ImagePicker
{
	public interface IImagePickerProvider
	{
		void PickImage(Action<ImageObject> handler);
	}
}

