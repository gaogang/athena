using System;

namespace Athena.ImagePicker.Pcl
{
	internal class ImageMask
	{
		private RelativeBoundary _roi;

		private RelativeBoundary _leftMask;
		private RelativeBoundary _rightMask;
		private RelativeBoundary _topMask;
		private RelativeBoundary _bottomMask;

		public ImageMask() :
			this(null)
		{
		}

		public ImageMask (RelativeBoundary roi)
		{
			_roi = roi;

			InitialiseMasks ();

			SetupMasks ();
		}

		public RelativeBoundary Roi 
		{
			get {
				return _roi;
			}

			set {
				if (_roi == value) {
					return;
				}

				_roi = value;
				SetupMasks ();
			}
		}

		public RelativeBoundary Left 
		{
			get {
				return _leftMask;
			}
		}

		public RelativeBoundary Right 
		{
			get {
				return _rightMask;
			}
		}

		public RelativeBoundary Top 
		{
			get {
				return _topMask;
			}
		}

		public RelativeBoundary Bottom 
		{
			get {
				return _bottomMask;
			}
		}

		private void InitialiseMasks()
		{
			if (_leftMask == null) {
				_leftMask = new RelativeBoundary ();
			}

			if (_rightMask == null) {
				_rightMask = new RelativeBoundary ();
			}

			if (_topMask == null) {
				_topMask = new RelativeBoundary ();
			}

			if (_bottomMask == null) {
				_bottomMask = new RelativeBoundary ();
			}
		}

		private void SetupMasks() 
		{
			if (Roi == null) {
				return;
			}

			SetupLeftMask ();
			SetupRightMask ();
			SetupTopMask ();
			SetupBottomMask ();
		}

		private void SetupLeftMask() 
		{
			_leftMask.X = 0.0;
			_leftMask.Y = 0.0;
			_leftMask.Width = _roi.X;
			_leftMask.Height = 1.0;
		}

		private void SetupRightMask() 
		{
			_rightMask.X = _roi.X + _roi.Width;
			_rightMask.Y = 0.0;
			_rightMask.Width = 1.0 - _roi.X - _roi.Width;
			_rightMask.Height = 1.0;
		}

		private void SetupTopMask() 
		{
			_topMask.X = _roi.X;
			_topMask.Y = 0.0;
			_topMask.Width = _roi.Width;
			_topMask.Height = _roi.Y;
		}

		private void SetupBottomMask() 
		{
			_bottomMask.X = _roi.X;
			_bottomMask.Y = _roi.Y + _roi.Height;
			_bottomMask.Width = _roi.Width;
			_bottomMask.Height = 1.0 - _roi.Y - _roi.Height;
		}
	}
}

