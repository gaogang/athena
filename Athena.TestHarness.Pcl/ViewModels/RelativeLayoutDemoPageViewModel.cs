using System;
using System.Windows.Input;
using Xamarin.Forms;

namespace Athena.TestHarness.Pcl.ViewModels
{
	public class RelativeLayoutDemoPageViewModel
	{
		private readonly ICommand _backCommand;

		public RelativeLayoutDemoPageViewModel ()
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
		}


	}
}

