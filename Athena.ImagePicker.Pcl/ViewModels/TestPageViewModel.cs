using System;
using System.Reactive.Linq;
using System.Windows.Input;
using Microsoft.Practices.Unity;
using Xamarin.Forms;

namespace Athena.ImagePicker.Pcl.ViewModels
{
	public class TestPageViewModel : ViewModelBase
	{
		private readonly ICommand _selectPhotoCommand;

		private IImagePicker _imagePicker;
		private string _message;

		public TestPageViewModel ()
		{
			_selectPhotoCommand = new Command (SelectPhotoCommandExecute);
		}

		public ICommand SelectPhotoCommand 
		{
			get {
				return _selectPhotoCommand;
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
	}
}

