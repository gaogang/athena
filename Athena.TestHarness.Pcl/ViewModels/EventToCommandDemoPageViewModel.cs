using System;
using System.Windows.Input;
using Athena.Core.Pcl.ViewModels;
using Xamarin.Forms;

namespace Athena.TestHarness.Pcl.ViewModels
{
	public class EventToCommandDemoPageViewModel : ViewModelBase
	{
		private readonly ICommand _backCommand;
		private readonly ICommand _textChangedCommand;

		private int _counter = 0;

		public EventToCommandDemoPageViewModel ()
		{
			_backCommand = new Command (BackCommandExecute);
			_textChangedCommand = new Command(TextChangedCommandExecute);
		}

		public ICommand BackCommand 
		{
			get {
				return _backCommand;
			}
		}

		public ICommand TextChangedCommand 
		{
			get {
				return _textChangedCommand;
			}
		}

		public int Counter
		{
			get {
				return _counter;
			}

			set {
				if (_counter == value) {
					return;
				}

				_counter = value;
				OnPropertyChanged (() => this.Counter);
			}
		}

		private void BackCommandExecute(object args)
		{
			View.NavigateBack ();
		}

		private void TextChangedCommandExecute(object args) 
		{
			var eventArgs = args as TextChangedEventArgs;

			if (eventArgs == null) {
				throw new ArgumentException ("args is not a TextChangedEventArgs");
			}

			Counter = eventArgs.NewTextValue.Length;
		}
	}
}

