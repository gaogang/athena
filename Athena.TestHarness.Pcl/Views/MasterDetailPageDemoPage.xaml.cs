using System;
using System.Collections.Generic;
using Athena.Core.Pcl.Views;
using Xamarin.Forms;
using Athena.TestHarness.Pcl.ViewModels;

namespace Athena.TestHarness.Pcl
{	
	public partial class MasterDetailPageDemoPage : MasterDetailPage, IContentPageBase
	{	
		public MasterDetailPageDemoPage ()
		{
			InitializeComponent ();

			NavigationPage.SetHasNavigationBar (this, false);

			MessagingCenter.Subscribe<DetailPageViewModel> (
				this, 
				"Pop", 
				sender => Pop(sender));
		}

		public async void NavigateTo(IContentPageBase page)
		{
			await Navigation.PushAsync ((Page)page);
		}

		public async void NavigateBack() {
			await Navigation.PopAsync ();
		}

		private void Pop(DetailPageViewModel sender)
		{
			IsPresented = !IsPresented;
		}
	}
}

