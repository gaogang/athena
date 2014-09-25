using System;
using System.Windows.Input;
using Athena.Core.Pcl.ViewModels;
using Xamarin.Forms;
using Athena.Core.Pcl.Gesture;

namespace Athena.TestHarness.Pcl.ViewModels
{
	public class GestureAwareContentViewDemoPageViewModel : ViewModelBase
	{
		private static readonly string Default = " -- ";

		private readonly ICommand _backCommand;

		private readonly ICommand _panCommand;
		private readonly ICommand _pinchCommand;
		private readonly ICommand _swipeCommand;

		private string _gesture;
		private string _output;

		public GestureAwareContentViewDemoPageViewModel ()
		{
			_backCommand = new Command (BackCommandExecute);

			_panCommand = new Command (PanCommandExecute);
			_pinchCommand = new Command (PinchCommandExecute);
			_swipeCommand = new Command (SwipeCommandExecute);

			_gesture = Default;
			_output = Default;
		}

		public ICommand BackCommand 
		{
			get {
				return _backCommand;
			}
		}

		public ICommand PanCommand
		{
			get {
				return _panCommand;
			}
		}

		public ICommand PinchCommand
		{
			get {
				return _pinchCommand;
			}
		}

		public ICommand SwipeCommand
		{
			get {
				return _swipeCommand;
			}
		}

		public string Gesture 
		{
			get {
				return _gesture;
			}
		}

		public string Output 
		{
			get {
				return _output;
			}
		}

		private void BackCommandExecute(object args)
		{
			View.NavigateBack ();
		}

		private void PanCommandExecute(object args)
		{
			var gesture = (GestureOffset)args;

			_gesture = "Pan";
			_output = string.Format ("{0:F2} {1:F2}", gesture.X, gesture.Y);

			OnPropertyChanged (() => Gesture);
			OnPropertyChanged (() => Output);
		}

		private void PinchCommandExecute(object args)
		{
			var gesture = (GestureScale)args;

			_gesture = "Pinch";
			_output = string.Format ("{0:F2}", gesture.Scale);

			OnPropertyChanged (() => Gesture);
			OnPropertyChanged (() => Output);
		}

		private void SwipeCommandExecute(object args)
		{
			var gesture = (GestureOffset)args;

			_gesture = "Swipe";
			_output = string.Format ("{0:F2} {1:F2}", gesture.X, gesture.Y);

			OnPropertyChanged (() => Gesture);
			OnPropertyChanged (() => Output);
		}
	}
}

