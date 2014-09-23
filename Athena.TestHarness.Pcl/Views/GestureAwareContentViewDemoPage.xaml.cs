using System;
using System.Collections.Generic;
using Athena.Core.Pcl.Views;
using Xamarin.Forms;

namespace Athena.TestHarness.Pcl.Views
{	
	public partial class GestureAwareContentViewDemoPage : ContentPageBase
	{	
		public GestureAwareContentViewDemoPage ()
		{
			InitializeComponent ();

			ViewModel.View = this;
		}
	}
}

