using System;
using Athena.Core.Pcl.Gesture;

namespace Athena.ImagePicker.Android
{
	public class GestureDetectorListenerBase
	{
		public GestureDetectorListenerBase(IGestureAwareView view)
		{
			View = view;
		}

		public IGestureAwareView View {
			get;
			private set;
		}
	}
}

