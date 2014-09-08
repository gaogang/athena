using System;
using Xamarin.Forms;

namespace Athena.ImagePicker.Pcl
{
	internal class ImageService : IImageService
	{
		private ImageSource _image;

		public ImageService ()
		{
		}

		public ImageSource SelectedImage {
			get { 
				return ImageSource.FromFile ("piggy_bank.png");
			}

			set {
				_image = value;
			}
		}
	}
}

