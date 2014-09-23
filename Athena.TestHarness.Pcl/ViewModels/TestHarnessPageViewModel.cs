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

		public TestHarnessPageViewModel ()
		{
			_gestureAwareContentViewCommand = new Command (GestureAwareContentViewCommandExecute);
		}

		public ICommand GestureAwareContentViewCommand
		{
			get {
				return _gestureAwareContentViewCommand;
			}
		}

		private void GestureAwareContentViewCommandExecute(object args)
		{
			View.NavigateTo (new GestureAwareContentViewDemoPage ());
		}
	}
}

