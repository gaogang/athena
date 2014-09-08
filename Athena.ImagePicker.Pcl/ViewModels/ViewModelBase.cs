using System;
using System.ComponentModel;
using Athena.ImagePicker.Pcl.Views;

namespace Athena.ImagePicker.Pcl.ViewModels
{
	internal class ViewModelBase : IViewModel, INotifyPropertyChanged
	{
		public ViewModelBase ()
		{
		}

		#region IViewModel implementation

		public IContentPageBase View {
			get;
			set;
		}

		#endregion

		#region INotifyPropertyChanged implementation

		public event PropertyChangedEventHandler PropertyChanged;

		#endregion

		protected void OnPropertyChanged(string propertyName)
		{
			if (PropertyChanged == null) 
			{
				return;
			}

			PropertyChanged (this, new PropertyChangedEventArgs (propertyName));
		}
	}
}

