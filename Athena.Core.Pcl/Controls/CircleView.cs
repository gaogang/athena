using System;
using Xamarin.Forms;

namespace Athena.Core.Pcl.Controls
{
	public class CircleView : BoxView
	{
		public static readonly BindableProperty StrokeColorProperty = BindableProperty.Create (
			                                                            "StrokeColor", 
			                                                            typeof(Color), 
			                                                            typeof(CircleView), 
			                                                            new Color (0, 0, 0));

		public static readonly BindableProperty StrokeWidthProperty = BindableProperty.Create (
			                                                            "StrokeWidth", 
			                                                            typeof(int),
			                                                            typeof(CircleView),
			                                                            1);

		public static readonly BindableProperty StrokeDashProperty = BindableProperty.Create (
			                                                            "StrokeDash",
			                                                            typeof(float),
			                                                            typeof(CircleView),
			                                                            1.0f);
		public Color StrokeColor 
		{
			get {
				return (Color)GetValue (StrokeColorProperty);
			}

			set {
				SetValue (StrokeColorProperty, value);
			}
		}

		public int StrokeWidth
		{
			get {
				return (int)GetValue (StrokeWidthProperty);
			}

			set {
				SetValue (StrokeColorProperty, value);
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

