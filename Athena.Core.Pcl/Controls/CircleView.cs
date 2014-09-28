using System;
using Xamarin.Forms;

namespace Athena.Core.Pcl.Controls
{
	public class CircleView : BoxView
	{
		public static readonly BindableProperty FillColorProperty = BindableProperty.Create (
			                                                            "FillColor", 
			                                                            typeof(Color), 
			                                                            typeof(CircleView), 
			                                                            Color.Transparent);

		public static readonly BindableProperty StrokeColorProperty = BindableProperty.Create (
			                                                              "StrokeColor", 
			                                                              typeof(Color), 
			                                                              typeof(CircleView), 
			                                                              Color.Transparent);

		public static readonly BindableProperty StrokeThicknessProperty = BindableProperty.Create (
			                                                                  "StrokeThickness", 
			                                                                  typeof(float),
			                                                                  typeof(CircleView),
			                                                                  1.0f);

		public static readonly BindableProperty StrokeDashProperty = BindableProperty.Create (
			                                                            "StrokeDash",
			                                                            typeof(float),
			                                                            typeof(CircleView),
			                                                            1.0f);


		public Color FillColor 
		{
			get {
				return (Color)GetValue (FillColorProperty);
			}

			set {
				SetValue (FillColorProperty, value);
			}
		}

		public Color StrokeColor 
		{
			get {
				return (Color)GetValue (StrokeColorProperty);
			}

			set {
				SetValue (StrokeColorProperty, value);
			}
		}

		public float StrokeThickness
		{
			get {
				return (float)GetValue (StrokeThicknessProperty);
			}

			set {
				SetValue (StrokeThicknessProperty, value);
			}
		}

		public float StrokeDash
		{
			get {
				return (float)GetValue (StrokeDashProperty);
			}

			set {
				SetValue (StrokeDashProperty, value);
			}
		}
	}
}

