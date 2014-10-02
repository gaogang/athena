using System;
using System.Windows.Input;
using Athena.Core.Pcl.ViewModels;
using Xamarin.Forms;

namespace Athena.TestHarness.Pcl.ViewModels
{
	public class AnimationDemoPageViewModel : ViewModelBase
	{
		private readonly ICommand _backCommand;

		public AnimationDemoPageViewModel ()
		{
			_backCommand = new Command(BackCommandExecute);	
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

