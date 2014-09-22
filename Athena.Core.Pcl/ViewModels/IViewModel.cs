using System;
using Athena.Core.Pcl.Views;

namespace Athena.Core.Pcl.ViewModels
{
	public interface IViewModel
	{
		IContentPageBase View { get; set; }
	}
}

