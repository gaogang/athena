using System;
using Xamarin.Forms;
using Athena.ImagePicker.Pcl.ViewModels;

namespace Athena.ImagePicker.Pcl.Views
{
	public class ContentPageBase : ContentPage, IContentPageBase
    {
		public ContentPageBase() 
			: base()
		{
			NavigationPage.SetHasNavigationBar (this, false);
		}

		internal IViewModel ViewModel
		{
			get {
				return BindingContext as IViewModel;
			}
		}

		public async void NavigateTo(IContentPageBase page)
		{
			await Navigation.PushAsync ((Page)page);
		}

		public async void NavigateBack() {
			await Navigation.PopAsync ();
		}
	}
}

