using System;
using System.Windows.Input;
using Athena.Core.Pcl.ViewModels;
using Athena.TestHarness.Pcl.Views;
using Xamarin.Forms;

namespace Athena.TestHarness.Pcl.ViewModels
{
	public class TestHarnessPageViewModel : ViewModelBase
	{
		private readonly ICommand _gestureAwareContentViewCommand;
		private readonly ICommand _circleViewCommand;

		private readonly ICommand _relativeLayoutCommand;


		public TestHarnessPageViewModel ()
		{
			_relativeLayoutCommand = new Command(RelativeLayoutCommandExecute);
			_gestureAwareContentViewCommand = new Command (GestureAwareContentViewCommandExecute);
			_circleViewCommand = new Command (CircleViewCommandExecute);
		}

		public ICommand GestureAwareContentViewCommand
		{
			get {
				return _gestureAwareContentViewCommand;
			}
		}

		public ICommand CircleViewCommand
		{
			get {
				return _circleViewCommand;
			}
		}

		public ICommand RelativeLayoutCommand 
		{
			get {
				return _relativeLayoutCommand;
			}
		}

		private void RelativeLayoutCommandExecute(object args) 
		{
			View.NavigateTo (new RelatieLayoutDemoPage ());
		}

		private void GestureAwareContentViewCommandExecute(object args)
		{
			View.NavigateTo (new GestureAwareContentViewDemoPage ());
		}

		private void CircleViewCommandExecute(object args)
		{
			View.NavigateTo (new CircleViewDemoPage ());
		}
	}
}

