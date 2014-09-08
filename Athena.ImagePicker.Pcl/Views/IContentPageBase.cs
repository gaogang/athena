using System;

namespace Athena.ImagePicker.Pcl.Views
{
	public interface IContentPageBase
	{
		void NavigateTo(IContentPageBase page);

		void NavigateBack();
	}
}

