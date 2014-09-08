using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace Athena.ImagePicker.Pcl.Views
{	
	public partial class ImageView : ContentPageBase
	{	
		public ImageView ()
		{
			InitializeComponent ();

			ViewModel.View = this;
		}
	}
}

