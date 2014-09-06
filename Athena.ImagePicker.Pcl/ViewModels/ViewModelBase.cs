using System;
using System.ComponentModel;

namespace Athena.ImagePicker.Pcl.ViewModels
{
	public class ViewModelBase : INotifyPropertyChanged
	{
		public ViewModelBase ()
		{
		}

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

