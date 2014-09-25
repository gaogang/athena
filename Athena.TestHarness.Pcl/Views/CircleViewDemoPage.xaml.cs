using System;
using System.Collections.Generic;
using Athena.Core.Pcl.Views;
using Xamarin.Forms;

namespace Athena.TestHarness.Pcl.ViewModels
{	
	public partial class CircleViewDemoPage : ContentPageBase
	{	
		public CircleViewDemoPage ()
		{
			InitializeComponent ();

			ViewModel.View = this;
		}
	}
}

