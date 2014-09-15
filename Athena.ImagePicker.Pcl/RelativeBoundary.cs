using System;

namespace Athena.ImagePicker.Pcl
{
	public class RelativeBoundary
	{
		private double _x;
		private double _y;
		private double _width;
		private double _height;

		public RelativeBoundary() :
				this(0.0, 0.0, 1.0, 1.0)
		{
		}

		public RelativeBoundary (double x, double y, double width, double height)
		{
			_x = x;
			_y = y;
			_width = width;
			_height = height;
		}

		public double X 
		{
			get {
				return _x;
			}

			set { 
				_x = value;
			}
		}

		public double Y 
		{
			get {
				return _y;
			}

			set {
				_y = value;
			}
		}

		public double Width 
		{
			get {
				return _width;
			}

			set {
				_width = value;
			}
		}

		public double Height 
		{
			get {
				return _height;
			}

			set {
				_height = value;
			}
		}
	}
}

