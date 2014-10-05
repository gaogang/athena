using System;
using System.Collections.Generic;
using System.Linq;
using Xamarin.Forms;
using Athena.Core.Pcl.Internal;

namespace Athena.Core.Pcl.Controls
{
	public class PopupButton : Layout<View>
	{
		public static readonly BindableProperty StartAngleProperty = BindableProperty.Create(
			"StartAngle",
			typeof(double),
			typeof(PopupButton), 
			-90.0);

		public static readonly BindableProperty IntervalProperty = BindableProperty.Create(
			"Interval",
			typeof(double),
			typeof(PopupButton), 
			30.0);

		private readonly IGestureRecognizer _tapRecognizer;

		private bool _expanded = false;

		public PopupButton ()
		{	
			_tapRecognizer = new TapGestureRecognizer (v => OnTapped(v));
		}

		public double StartAngel
		{
			get {
				return (double)GetValue (StartAngleProperty);
			}

			set {
				SetValue (StartAngleProperty, value);
			}
		}

		public double Interval
		{
			get {
				return (double)GetValue (IntervalProperty);
			}

			set {
				SetValue (IntervalProperty, value);
			}
		}

		public bool IsExpanded 
		{
			get {
				return _expanded;
			}

			private set {
				_expanded = value;
			}
		}

		protected override void OnAdded (View view)
		{
			base.OnAdded (view);

			view.GestureRecognizers.Add (_tapRecognizer);
		}

		protected override void LayoutChildren (double x, double y, double width, double height)
		{
			if (!Children.Any ()) {
				return;
			}

			var master = Children.First ();

			LayoutChildIntoBoundingRegion (
				master, 
				new Rectangle (x, y, WidthRequest, HeightRequest));

			var counter = 0;
			var startAngel = StartAngel;
			var interval = Interval;

			foreach (var child in Children.Skip(1)) {
				var angle = startAngel + counter * interval;

				if (IsExpanded) {
					LayoutChildIntoBoundingRegion(
						child,
						RelativeLayoutCalculator.GetRelativePositionByRadian(
							master, 
							WidthRequest * 2.0, 
							angle));
				} else {
					LayoutChildIntoBoundingRegion (
						child, 
						new Rectangle (x, y, WidthRequest, HeightRequest));
				}

				counter++;
			}
		}

		private void OnTapped(View v)
		{
			IsExpanded = !IsExpanded;

			ForceLayout ();
		}
	}
}

