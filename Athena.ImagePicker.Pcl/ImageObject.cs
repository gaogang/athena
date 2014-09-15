using System;
using Xamarin.Forms;

namespace Athena.ImagePicker.Pcl
{
	public class ImageObject
	{
		private readonly ImageSource _source;
		private readonly double _w;
		private readonly double _h;

		public ImageObject (ImageSource source, double w, double h)
		{
			_source = source;
			_w = w;
			_h = h;
		}

		public ImageSource Source {
			get {
				return _source;
			}
		}

		public double Width {
			get {
				return _w;
			}
		}

		public double Height {
			get {
				return _h;
			}
		}
	}
}

