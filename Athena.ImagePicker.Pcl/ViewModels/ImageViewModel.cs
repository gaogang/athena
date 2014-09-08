using System;
using System.Windows.Input;
using Microsoft.Practices.Unity;
using Xamarin.Forms;

namespace Athena.ImagePicker.Pcl.ViewModels
{
	internal class ImageViewModel : ViewModelBase
	{
		private readonly ICommand _backCommand;

		public ImageViewModel ()
		{
			_backCommand = new Command (BackCommandExecute);
		}

		public ICommand BackCommand 
		{
			get {
				return _backCommand;
			}
		}

		private IImageService ImageService
		{
			get {
				return App.Container.Resolve<IImageService> ();
			}
		}

		public ImageSource Image
		{
			get {
				return ImageService.SelectedImage;
			}
		}

		private void BackCommandExecute(object args)
		{
			View.NavigateBack ();
		}
	}
}

