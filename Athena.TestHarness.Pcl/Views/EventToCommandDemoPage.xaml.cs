using System;
using System.Collections.Generic;
using Xamarin.Forms;
using Athena.Core.Pcl.Views;

namespace Athena.TestHarness.Pcl.Views
{	
	public partial class EventToCommandDemoPage : ContentPageBase
	{	
		public EventToCommandDemoPage ()
		{
			InitializeComponent ();

			ViewModel.View = this;
		}
	}
}

