using System;
using Xamarin.Forms;

namespace Athena.ImagePicker.Pcl
{
	internal interface IImageService
	{
		ImageSource SelectedImage { get; set; }

		double Width { get; }
		double Height { get; }
	}
}

