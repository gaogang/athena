using System;
using System.Windows.Input;
using Athena.Core.Pcl.ViewModels;
using Xamarin.Forms;

namespace Athena.TestHarness.Pcl.ViewModels
{
	public class CircleViewDemoPageViewModel : ViewModelBase
	{
		private readonly ICommand _backCommand;

		public CircleViewDemoPageViewModel ()
		{
			_backCommand = new Command (BackCommandExecute);
		}

		public ICommand BackCommand 
		{
			get {
				return _backCommand;
			}
		}

		private void BackCommandExecute(object args)
		{
			View.NavigateBack ();
		}
	}
}

