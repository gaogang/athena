using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Input;
using Athena.Core.Pcl.Gesture;
using Athena.Core.Pcl.Layouts;
using Athena.Core.Pcl.ViewModels;
using Microsoft.Practices.Unity;
using Xamarin.Forms;

namespace Athena.ImagePicker.Pcl.ViewModels
{
	internal class ImageViewModel : ViewModelBase
	{
		private readonly ICommand _backCommand;
		private readonly ICommand _confirmCommand;

		private readonly ICommand _panCommand;
		private readonly ICommand _pinchCommand;

		private readonly ImageMask _mask;

		private int _imageHeight;
		private int _imageWidth;

		private Rectangle _roiCache;

		public ImageViewModel ()
		{
			_backCommand = new Command (BackCommandExecute);
			_confirmCommand = new Command (ConfirmCommandExecute);

			_panCommand = new Command (PanCommandExecute);
			_pinchCommand = new Command (PinchCommandExecute);

			_mask = new ImageMask (new Rectangle (
				0.2, 
				0.2, 
				0.6, 
				0.6));
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

		public ICommand PanCommand 
		{
			get {
				return _panCommand;
			}
		}

		public ICommand PinchCommand 
		{
			get {
				return _pinchCommand;
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

		public Rectangle Roi 
		{
			get {
				return _mask.Roi;
			}

			set {
				_mask.Roi = value;
			}
		}

		public double LeftMaskWidth
		{
			get {
				return _mask.Left.Width;
			}
		}

		public double RightMaskWidth
		{
			get {
				return _mask.Right.Width;
			}
		}

		public double RightMaskX
		{
			get {
				return _mask.Right.X;
			}
		}

		public double TopMaskX
		{
			get {
				return _mask.Top.X;
			}
		}

		public double TopMaskWidth
		{
			get {
				return _mask.Top.Width;
			}
		}

		public double TopMaskHeight
		{
			get {
				return _mask.Top.Height;
			}
		}

		public double BottomMaskX
		{
			get {
				return _mask.Bottom.X;
			}
		}

		public double BottomMaskY
		{
			get {
				return _mask.Bottom.Y;
			}
		}

		public double BottomMaskWidth
		{
			get {
				return _mask.Bottom.Width;
			}
		}
	
		public double BottomMaskHeight
		{
			get {
				return _mask.Bottom.Height;
			}
		}

		public int ImageWidth {
			get {
				return _imageWidth;
			}

			set {
				_imageWidth = value;

				OnPropertyChanged (() => this.ImageWidth);
			}
		}

		public int ImageHeight {
			get {
				return _imageHeight;
			}

			set {
				_imageHeight = value;

				OnPropertyChanged (() => this.ImageHeight);
			}
		}

		private void BackCommandExecute(object args)
		{
			View.NavigateBack ();
		}

		private void ConfirmCommandExecute(object args) 
		{
		}

		private void PanCommandExecute(object args) 
		{
			var gestureArgs = args as GestureOffset;

			if (gestureArgs == null) {
				throw new ArgumentException ("the args is not a type of GestureArgs");
			}

			if (gestureArgs.State == GestureState.Began) {
				// Take a snapshot of the current ROI
				_roiCache = Roi;
			}

			var xfactor = gestureArgs.X / _imageWidth;
			var yfactor = gestureArgs.Y / _imageHeight;

			var roi = new Rectangle (
				          _roiCache.X + xfactor, 
				          _roiCache.Y + yfactor, 
				          _roiCache.Width,
				          _roiCache.Height);

			if (roi.X < 0.0) {
				roi.X = 0.0;
			}

			if (roi.Y < 0.0) {
				roi.Y = 0.0;
			}

			if (roi.X + roi.Width > 1.0) {
				roi.X = 1.0 - roi.Width;
			}

			if (roi.Y + roi.Height > 1.0) {
				roi.Y = 1.0 - roi.Height;
			}

			UpdateRoiAndNotifyPropertyChanged (roi);
		}

		private void PinchCommandExecute(object args)
		{
			var gestureArgs = args as GestureScale;

			if (gestureArgs == null) {
				throw new ArgumentException ("the args is not a type of GestureArgs");
			}

			if (gestureArgs.State == GestureState.Began) {
				// Take a snapshot of the current ROI
				_roiCache = Roi;
			}

			var scale = gestureArgs.Scale;

			if (scale == 1.0) {
				return;
			}

			var center = new Point (
				             _roiCache.X + _roiCache.Width / 2, 
				             _roiCache.Y + _roiCache.Height / 2);

			if (scale > 1) {

				var maxHoriztonalScale = GetMaxHorizontalScale ();
				var maxVerticalScale = GetMaxVerticalScale ();

				var maxScale = maxHoriztonalScale < maxVerticalScale ? maxHoriztonalScale : maxVerticalScale;

				if (scale > maxScale) {
					scale = maxScale;
				}
			} else if (scale < 1) {
				var smallDimension = _roiCache.Width < _roiCache.Height ? _roiCache.Width : _roiCache.Height;

				var scaledSize = smallDimension * scale;

				if (scaledSize < 0.1) {
					scale = 0.1 / smallDimension;
				}
			}

			var newWidth = scale * _roiCache.Width;
			var newHeight = scale * _roiCache.Height;
			var newX = center.X - newWidth / 2;
			var newY = center.Y - newHeight / 2;

			var roi = new Rectangle (newX, newY, newWidth, newHeight);

			UpdateRoiAndNotifyPropertyChanged (roi);
		}

		private double GetMaxHorizontalScale()
		{
			var left = _roiCache.X;
			var right = 1.0 - _roiCache.X - _roiCache.Width;

			var smallMargin = left < right ? left : right;

			var maxWidth = _roiCache.Width + 2 * smallMargin;

			return maxWidth / _roiCache.Width;
		}

		private double GetMaxVerticalScale()
		{
			var top = _roiCache.Y;
			var bottom = 1.0 - _roiCache.Y - _roiCache.Height;

			var smallMargin = top < bottom ? top : bottom;

			var maxHeight = _roiCache.Height + 2 * smallMargin;

			return maxHeight / _roiCache.Height;
		}

		private void UpdateRoiAndNotifyPropertyChanged(Rectangle roi)
		{
			Roi = roi;

			OnPropertyChanged (() => LeftMaskWidth);

			OnPropertyChanged (() => RightMaskWidth);
			OnPropertyChanged (() => RightMaskX);

			OnPropertyChanged (() => TopMaskX);
			OnPropertyChanged (() => TopMaskWidth);
			OnPropertyChanged (() => TopMaskHeight);

			OnPropertyChanged (() => BottomMaskX);
			OnPropertyChanged (() => BottomMaskY);
			OnPropertyChanged (() => BottomMaskWidth);
			OnPropertyChanged (() => BottomMaskHeight);
		}
	}
}

