using System;

namespace Athena.Core.Pcl.Views
{
	public interface IContentPageBase
	{
		void NavigateTo(IContentPageBase page);

		void NavigateBack();
	}
}

