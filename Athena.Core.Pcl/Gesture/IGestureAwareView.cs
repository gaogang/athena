using System;
using System.Windows.Input;

namespace Athena.Core.Pcl.Gesture
{
	public interface IGestureAwareView
	{
		ICommand LongPress {
			get;
			set;
		}

		ICommand Pan {
			get;
			set;
		}

		ICommand Pinch {
			get;
			set;
		}

		ICommand Rotate {
			get;
			set;
		}

		ICommand Swipe {
			get;
			set;
		}
	}
}

