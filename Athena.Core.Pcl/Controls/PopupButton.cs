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

		public static readonly BindableProperty IsExpandedProperty = BindableProperty.Create (
			                                                             "IsExpanded",
			                                                             typeof(bool),
			                                                             typeof(PopupButton), 
			                                                             false, 
			                                                             BindingMode.TwoWay, 
			                                                             null, 
			                                                             (bindable, oldValue, newValue) => OnIsExpandedPropertyChanged (bindable, oldValue, newValue));

		private readonly IGestureRecognizer _tapRecognizer;

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
				return (bool)GetValue (IsExpandedProperty);
			}

			private set {
				SetValue (IsExpandedProperty, value);
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

			ExpandOrCollapse (
				master, 
				(child, bound, opacity) => MoveTo (child, bound, opacity));
		}

		private static void OnIsExpandedPropertyChanged(
			BindableObject sender, 
			object oldValue, 
			object newValue)
		{
			var bindable = sender as PopupButton;

			bindable.ExpandOrCollapse ();
		}

		private void OnTapped(View v)
		{
			IsExpanded = !IsExpanded;

			ExpandOrCollapse ();
		}

		private void ExpandOrCollapse()
		{
			var master = Children.FirstOrDefault ();

			if (master == null) {
				return;
			}

			ExpandOrCollapse (
				master, 
				(child, bound, opacity) => AnimateTo(child, bound, opacity));
		}

		private void ExpandOrCollapse(View master, Action<View, Rectangle, double> move)
		{
			int counter = 0;
			var startAngel = StartAngel;
			var interval = Interval;

			foreach (var child in Children.Skip(1)) {
				if (IsExpanded) {
					var angle = startAngel + counter * interval;

					move (
						child, 
						RelativeLayoutCalculator.GetRelativePositionByRadian (
							master, 
							WidthRequest * 2.0, 
							angle),
						0.8);	
				} else {
					move (child, master.Bounds, 0.0);	
				}

				counter++;
			}
		}

		private void MoveTo(View child, Rectangle bound, double opacity)
		{
			LayoutChildIntoBoundingRegion (child, bound);

			child.Opacity = opacity;
		}

		private void AnimateTo(View child, Rectangle bound, double opacity)
		{
			child.LayoutTo (
				bound,
				100, 
				Easing.SinIn);

			child.FadeTo (
				opacity, 
				100,
				Easing.SinIn);
		}
	}
}

