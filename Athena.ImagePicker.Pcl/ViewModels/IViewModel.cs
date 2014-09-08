using System;
using Athena.ImagePicker.Pcl.Views;

namespace Athena.ImagePicker.Pcl.ViewModels
{
	internal interface IViewModel
	{
		IContentPageBase View { get; set; }
	}
}

