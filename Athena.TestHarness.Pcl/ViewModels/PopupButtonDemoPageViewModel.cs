using System;
using System.Windows.Input;
using Athena.Core.Pcl.ViewModels;
using Xamarin.Forms;

namespace Athena.TestHarness.Pcl.ViewModels
{
	public class PopupButtonDemoPageViewModel : ViewModelBase
	{
		private readonly ICommand _backCommand;

		private bool _isUpperPopupExpanded;
		private bool _isLowerPopupExpanded;

		public PopupButtonDemoPageViewModel ()
		{
			_backCommand = new Command(BackCommandExecute);	
		}

		public ICommand BackCommand 
		{
			get {
				return _backCommand;
			}
		}

		public bool IsUpperPopupExpanded
		{
			get {
				return _isUpperPopupExpanded;
			}

			set {
				if (_isUpperPopupExpanded == value) {
					return;
				}

				_isUpperPopupExpanded = value;

				if (_isUpperPopupExpanded) {
					IsLowerPopupExpanded = false;
				}

				OnPropertyChanged (() => this.IsUpperPopupExpanded);
			}
		}

		public bool IsLowerPopupExpanded
		{
			get {
				return _isLowerPopupExpanded;
			}

			set {
				if (_isLowerPopupExpanded == value) {
					return;
				}

				_isLowerPopupExpanded = value;

				if (_isLowerPopupExpanded) {
					IsUpperPopupExpanded = false;
				}

				OnPropertyChanged (() => this.IsLowerPopupExpanded);
			}
		}

		private void BackCommandExecute(object args) 
		{
			View.NavigateBack ();
		}
	}
}

