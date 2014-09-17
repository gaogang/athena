using System;
using System.Windows.Input;
using Microsoft.Practices.Unity;
using Xamarin.Forms;

namespace Athena.ImagePicker.Pcl.ViewModels
{
	internal class ImageViewModel : ViewModelBase
	{
		private readonly ICommand _backCommand;
		private readonly ICommand _confirmCommand;

		private int _imageHeight;
		private int _imageWidth;

		private RelativeBoundary _leftMask;
		private RelativeBoundary _rightMask;
		private RelativeBoundary _topMask;
		private RelativeBoundary _bottomMask;

		public ImageViewModel ()
		{
			_backCommand = new Command (BackCommandExecute);
			_confirmCommand = new Command (ConfirmCommandExecute);

			InitialiseMasks ();
		}

		public ICommand BackCommand 
		{
			get {
				return _backCommand;
			}
		}

		public ICommand ConfirmCommand 
		{
			get {
				return _confirmCommand;
			}
		}

		private IImageService ImageService
		{
			get {
				return App.Container.Resolve<IImageService> ();
			}
		}

		public ImageSource Image
		{
			get {
				return ImageService.SelectedImage;
			}
		}

		public double LeftMaskWidthFactor 
		{
			get {
				return _leftMask.Width;
			}

			set {
				if (_leftMask.Width == value) {
					return;
				}

				_leftMask.Width = value;
				OnPropertyChanged ("LeftMaskWidthFactor");
			}
		}

		public double RightMaskWidthFactor 
		{
			get {
				return _rightMask.Width;
			}

			set {
				if (_rightMask.Width == value) {
					return;
				}

				_rightMask.Width = value;
				OnPropertyChanged ("RightMaskWidthFactor");
			}
		}

		public double RightMaskXFactor 
		{
			get {
				return _rightMask.X;
			}

			set {
				if (_rightMask.X == value) {
					return;
				}

				_rightMask.X = value;
				OnPropertyChanged ("RightMaskXFactor");
			}
		}

		public double TopMaskXFactor 
		{
			get {
				return _topMask.X;
			}

			set {
				if (_topMask.X == value) {
					return;
				}

				_topMask.X = value;
				OnPropertyChanged ("TopMaskXFactor");
			}
		}

		public double TopMaskWidthFactor 
		{
			get {
				return _topMask.Width;
			}

			set {
				if (_topMask.Width == value) {
					return;
				}

				_topMask.Width = value;
				OnPropertyChanged ("TopMaskWidthFactor");
			}
		}

		public double TopMaskHeightFactor 
		{
			get {
				return _topMask.Height;
			}

			set {
				if (_topMask.Height == value) {
					return;
				}

				_topMask.Height = value;
				OnPropertyChanged ("TopMaskHeightFactor");
			}
		}

		public double BottomMaskXFactor 
		{
			get {
				return _bottomMask.X;
			}

			set {
				if (_bottomMask.X == value) {
					return;
				}

				_bottomMask.X = value;
				OnPropertyChanged ("BottomMaskXFactor");
			}
		}

		public double BottomMaskYFactor 
		{
			get {
				return _bottomMask.Y;
			}

			set {
				if (_bottomMask.Y == value) {
					return;
				}

				_bottomMask.Y = value;
				OnPropertyChanged ("BottomMaskYFactor");
			}
		}

		public double BottomMaskWidthFactor 
		{
			get {
				return _bottomMask.Width;
			}

			set {
				if (_bottomMask.Width == value) {
					return;
				}

				_bottomMask.Width = value;
				OnPropertyChanged ("BottomMaskWidthFactor");
			}
		}

		public double BottomMaskHeightFactor 
		{
			get {
				return _bottomMask.Height;
			}

			set {
				if (_bottomMask.Height == value) {
					return;
				}

				_bottomMask.Height = value;
				OnPropertyChanged ("BottomMaskHeightFactor");
			}
		}

		public int ImageWidth {
			get {
				return _imageWidth;
			}

			set {
				_imageWidth = value;

				OnPropertyChanged ("Imagewidth");
				OnPropertyChanged ("LeftMaskConstraint");
			}
		}

		public int ImageHeight {
			get {
				return _imageHeight;
			}

			set {
				_imageHeight = value;

				OnPropertyChanged ("ImageHeight");
				OnPropertyChanged ("LeftMaskConstraint");
			}
		}

		private void InitialiseMasks()
		{
			_leftMask = new RelativeBoundary (
				0.0, 
				0.0, 
				0.2, 
				1.0);

			_rightMask = new RelativeBoundary (
				0.8, 
				0.0, 
				0.2, 
				1.0);

			_topMask = new RelativeBoundary (
				0.2, 
				0.0, 
				0.6, 
				0.2);

			_bottomMask = new RelativeBoundary (
				0.2, 
				0.8, 
				0.6, 
				0.2);
		}

		private void BackCommandExecute(object args)
		{
			View.NavigateBack ();
		}

		private void ConfirmCommandExecute(object args) 
		{
		}
	}
}

