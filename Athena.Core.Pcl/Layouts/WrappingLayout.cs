using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Xamarin.Forms;

namespace Athena.Core.Pcl.Layouts
{
	internal class ViewCell
	{
		private readonly View _view;
		private readonly Size _size;

		public ViewCell(View view, Size size)
		{
			_view = view;
			_size = size;
		}

		public View View
		{
			get {
				return _view;
			}
		}

		public Size Size
		{
			get {
				return _size;
			}
		}
	}

	internal class ViewRow
	{
		private readonly double _offsetY;

		public ViewRow(double offsetY)
		{
			_offsetY = offsetY;

			Cells = new Collection<ViewCell> ();
		}

		public double OffsetY {
			get {
				return _offsetY;
			}
		}

		public double Height {
			get {
				if (!Cells.Any ()) {
					return 0.0;
				}

				return Cells.Max (c => c.Size.Height);
			}
		}

		public double Width 
		{
			get {
				if (!Cells.Any ()) {
					return 0.0;
				}

				return Cells.Sum (c => c.Size.Width);
			}
		}

		public ICollection<ViewCell> Cells { get; set; }
	}

	internal class ViewTable 
	{
		public ViewTable() 
		{
			Rows = new Collection<ViewRow> ();
		}

		public ICollection<ViewRow> Rows { get; set; }

		public double Height 
		{
			get {
				if (!Rows.Any ()) {
					return 0.0;
				}

				return Rows.Sum (r => r.Height);
			}
		}

		public double Width
		{
			get {
				if (!Rows.Any ()) {
					return 0.0;
				}

				return Rows.Max (r => r.Width);
			}
		}
	}

	public class WrappingLayout : Layout<View>
	{
		public static readonly BindableProperty HorizontalSpacingProperty = BindableProperty.Create(
			"HorizontalSpacing", 
			typeof(double),
			typeof(WrappingLayout),
			5.0);

		public static readonly BindableProperty VerticalSpacingProperty = BindableProperty.Create(
			"VerticalSpacing", 
			typeof(double),
			typeof(WrappingLayout),
			0.0);

		public double HorizontalSpacing
		{
			get {
				return (double)GetValue (HorizontalSpacingProperty);
			}

			set {
				SetValue (HorizontalSpacingProperty, value);
			}
		}

		public double VerticalSpacing
		{
			get {
				return (double)GetValue (VerticalSpacingProperty);
			}

			set {
				SetValue (VerticalSpacingProperty, value);
			}
		}

		protected override void LayoutChildren (double x, double y, double width, double height)
		{
			var viewTable = GetViewTable (width, height);

			// Layout
			foreach(var r in viewTable.Rows) {
				var offsetX = x;

				foreach (var c in r.Cells) {
					var cellRegion = new Rectangle (offsetX, r.OffsetY + y, c.Size.Width, r.Height);

					LayoutChildIntoBoundingRegion (c.View, cellRegion);

					offsetX += c.Size.Width;
				}
			}
		}

		protected override SizeRequest OnSizeRequest (double widthConstraint, double heightConstraint)
		{
			if (this.WidthRequest > 0.0) {
				widthConstraint = Math.Min (widthConstraint, WidthRequest);
			}

			if (this.HeightRequest > 0.0) {
				heightConstraint = Math.Min (heightConstraint, HeightRequest);
			}

			return CalculateSizeRequests(
				double.IsPositiveInfinity(widthConstraint) ? double.PositiveInfinity : Math.Max(0.0, widthConstraint), 
				double.IsPositiveInfinity(heightConstraint) ? double.PositiveInfinity : Math.Max(0.0, heightConstraint));
		}

		private SizeRequest CalculateSizeRequests(
			double widthConstraint, 
			double heightConstraint)
		{
			var viewTable = GetViewTable (widthConstraint, heightConstraint);


			return new SizeRequest {
				Request = new Size (viewTable.Width, viewTable.Height),
				Minimum = new Size (viewTable.Width, viewTable.Height)
			};
		}

		private ViewTable GetViewTable(double widthConstraint, double heightConstraint)
		{
			var viewTable = new ViewTable ();
			var row = new ViewRow (0.0);

			foreach (var child in Children) {
				if (!child.IsVisible) {
					continue;
				}

				var sizeRequest = child.GetSizeRequest (widthConstraint, heightConstraint);

				double viewWidth = Math.Max (
					sizeRequest.Request.Width, 
					sizeRequest.Minimum.Width);

				double viewHeight = Math.Max (
					sizeRequest.Request.Height, 
					sizeRequest.Minimum.Height);

				var offsetX = row.Cells.Any() ? 
					row.Cells.Sum (c => c.Size.Width) : 0.0;

				if (offsetX + viewWidth > widthConstraint) {
					viewTable.Rows.Add (row);

					var offsetY = row.OffsetY + row.Height + VerticalSpacing;

					row = new ViewRow (offsetY);
				}

				row.Cells.Add (
					new ViewCell (
						child, 
						new Size(viewWidth + HorizontalSpacing, viewHeight + VerticalSpacing)));
			}

			viewTable.Rows.Add (row);

			return viewTable;
		}
	}
}

