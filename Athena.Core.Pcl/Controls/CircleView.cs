using System;
using Xamarin.Forms;

namespace Athena.Core.Pcl.Controls
{
	public class CircleView : View
	{
		public static readonly BindableObject StrokeColorProperty = BindableProperty.Create (
			                                                            "StrokeColor", 
			                                                            typeof(Color), 
			                                                            typeof(CircleView), 
			                                                            new Color (0, 0, 0));

		public Color StrokeColor 
		{
			get {
				return (Color)GetValue (StrokeColorProperty);
			}

			set {
				SetValue (StrokeColorProperty, value);
			}
		}
	}
}

