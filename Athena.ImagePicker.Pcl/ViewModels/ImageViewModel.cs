using System;
using System.Windows.Input;
using Athena.Core.Pcl.Gesture;
using Microsoft.Practices.Unity;
using Xamarin.Forms;

namespace Athena.ImagePicker.Pcl.ViewModels
{
	internal class ImageViewModel : ViewModelBase
	{
		private readonly ICommand _backCommand;
		private readonly ICommand _confirmCommand;

		private readonly ICommand _panCommand;

		private readonly ImageMask _mask;

		private int _imageHeight;
		private int _imageWidth;

		private RelativeBoundary _roiCache;

		public ImageViewModel ()
		{
			_backCommand = new Command (BackCommandExecute);
			_confirmCommand = new Command (ConfirmCommandExecute);

			_panCommand = new Command (PanCommandExecute);

			_mask = new ImageMask (new RelativeBoundary (
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

		public RelativeBoundary Roi 
		{
			get {
				return _mask.Roi;
			}

			set {
				_mask.Roi = value;
			}
		}

		public double LeftMaskWidthFactor 
		{
			get {
				return _mask.Left.Width;
			}
		}

		public double RightMaskWidthFactor 
		{
			get {
				return _mask.Right.Width;
			}
		}

		public double RightMaskXFactor 
		{
			get {
				return _mask.Right.X;
			}
		}

		public double TopMaskXFactor 
		{
			get {
				return _mask.Top.X;
			}
		}

		public double TopMaskWidthFactor 
		{
			get {
				return _mask.Top.Width;
			}
		}

		public double TopMaskHeightFactor 
		{
			get {
				return _mask.Top.Height;
			}
		}

		public double BottomMaskXFactor 
		{
			get {
				return _mask.Bottom.X;
			}
		}

		public double BottomMaskYFactor 
		{
			get {
				return _mask.Bottom.Y;
			}
		}

		public double BottomMaskWidthFactor 
		{
			get {
				return _mask.Bottom.Width;
			}
		}

		public double BottomMaskHeightFactor 
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
			var gestureArgs = args as GestureArgs;

			if (gestureArgs == null) {
				throw new ArgumentException ("the args is not a type of GestureArgs");
			}

			if (gestureArgs.State == GestureState.Began) {
				// Take a snapshot of the current ROI
				_roiCache = Roi;
			}

			var xfactor = gestureArgs.X / _imageWidth;
			var yfactor = gestureArgs.Y / _imageHeight;

			var roi = new RelativeBoundary (
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

			Roi = roi;

			OnPropertyChanged (() => LeftMaskWidthFactor);
			OnPropertyChanged (() => RightMaskWidthFactor);
			OnPropertyChanged (() => RightMaskXFactor);
			OnPropertyChanged (() => TopMaskXFactor);
			OnPropertyChanged (() => TopMaskWidthFactor);
			OnPropertyChanged (() => TopMaskHeightFactor);
			OnPropertyChanged (() => BottomMaskXFactor);
			OnPropertyChanged (() => BottomMaskYFactor);
			OnPropertyChanged (() => BottomMaskWidthFactor);
			OnPropertyChanged (() => BottomMaskHeightFactor);
		}
	}
}

