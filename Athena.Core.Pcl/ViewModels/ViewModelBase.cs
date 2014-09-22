using System;
using System.ComponentModel;
using System.Linq.Expressions;
using Athena.Core.Pcl.Views;

namespace Athena.Core.Pcl.ViewModels
{
	public class ViewModelBase : IViewModel, INotifyPropertyChanged
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

		protected void OnPropertyChanged(Expression<Func<object>> expression)
		{
			var body = expression.Body as MemberExpression;

			if (body == null) {
				var ubody = (UnaryExpression)expression.Body;
				body = ubody.Operand as MemberExpression;
			}

			OnPropertyChanged(body.Member.Name);
		}

		private void OnPropertyChanged(string propertyName)
		{
			if (PropertyChanged == null) 
			{
				return;
			}

			PropertyChanged (this, new PropertyChangedEventArgs (propertyName));
		}
	}
}

