using System;
using Athena.Core.Pcl.Layouts;
using Xamarin.Forms;

namespace Athena.ImagePicker.Pcl
{
	internal class ImageMask
	{
		private Rectangle _roi;

		private Rectangle _leftMask;
		private Rectangle _rightMask;
		private Rectangle _topMask;
		private Rectangle _bottomMask;

		public ImageMask() :
			this(new Rectangle(0,0,0,0))
		{
		}

		public ImageMask (Rectangle roi)
		{
			_roi = roi;

			InitialiseMasks ();

			SetupMasks ();
		}

		public Rectangle Roi 
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

		public Rectangle Left 
		{
			get {
				return _leftMask;
			}
		}

		public Rectangle Right 
		{
			get {
				return _rightMask;
			}
		}

		public Rectangle Top 
		{
			get {
				return _topMask;
			}
		}

		public Rectangle Bottom 
		{
			get {
				return _bottomMask;
			}
		}

		private void InitialiseMasks()
		{
			if (_leftMask == null) {
				_leftMask = new Rectangle ();
			}

			if (_rightMask == null) {
				_rightMask = new Rectangle ();
			}

			if (_topMask == null) {
				_topMask = new Rectangle ();
			}

			if (_bottomMask == null) {
				_bottomMask = new Rectangle ();
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

