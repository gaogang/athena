using System;
using Athena.Core.Pcl.Views;

namespace Athena.Core.Pcl.ViewModels
{
	internal interface IViewModel
	{
		IContentPageBase View { get; set; }
	}
}

