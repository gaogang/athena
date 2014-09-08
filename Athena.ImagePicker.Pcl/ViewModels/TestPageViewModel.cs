using System;
using System.Reactive.Linq;
using System.Windows.Input;
using Microsoft.Practices.Unity;
using Xamarin.Forms;
using Athena.ImagePicker.Pcl.Views;

namespace Athena.ImagePicker.Pcl.ViewModels
{
	internal class TestPageViewModel : ViewModelBase
	{
		private readonly ICommand _selectPhotoCommand;
		private readonly ICommand _gotoImageViewCommand;

		private IImagePicker _imagePicker;
		private string _message;

		public TestPageViewModel () : 
			base ()
		{
			_selectPhotoCommand = new Command (SelectPhotoCommandExecute);
			_gotoImageViewCommand = new Command (GotoImageViewCommandExecute);
		}

		public ICommand SelectPhotoCommand 
		{
			get {
				return _selectPhotoCommand;
			}
		}

		public ICommand GotoImageViewCommand 
		{
			get { 
				return _gotoImageViewCommand;
			}
		}

		public string Message {
			get { 
				return _message;
			}

			set {
				if (_message == value) {
					return;
				}

				_message = value;
				OnPropertyChanged ("Message");
			}
		}

		private IImagePicker ImagePicker
		{
			get {
				if (_imagePicker == null) {
					_imagePicker = App.Container.Resolve<IImagePicker> ();
				}
				return _imagePicker;
			}
		}

		private async void SelectPhotoCommandExecute(object args) 
		{
			var image = await ImagePicker.PickImageAsync ();

			if (image == null) {
				Message = "Cancelled";
			} else {
				Message = "Image Selected";
			}
		}

		private void GotoImageViewCommandExecute(object args)
		{
			View.NavigateTo (new ImageView ());
		}
	}
}

