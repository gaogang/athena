using System;
using System.Collections.Generic;
using System.Linq;
using Xamarin.Forms;

namespace Athena.ImagePicker.Pcl.Layouts
{
	public class BindableRelativeLayout : Layout<View>
	{
		public static BindableProperty ElementNameProperty = BindableProperty.CreateAttached<BindableRelativeLayout, string>(
			bindable => GetElementName(bindable),
			string.Empty, 
			BindingMode.OneWay, 
			null, 
			(bindable, oldValue, newValue) => OnElementNameChanged(bindable, oldValue, newValue), 
			null, 
			null);

		public static BindableProperty XFactorProperty = BindableProperty.CreateAttached<BindableRelativeLayout, double>(
			bindable => GetXFactor(bindable),
			0.0, 
			BindingMode.OneWay, 
			null, 
			(bindable, oldValue, newValue) => OnLayoutChanged(bindable, oldValue, newValue), 
			null, 
			null);

		public static BindableProperty YFactorProperty = BindableProperty.CreateAttached<BindableRelativeLayout, double>(
			bindable => GetYFactor(bindable),
			0.0, 
			BindingMode.OneWay, 
			null, 
			(bindable, oldValue, newValue) => OnLayoutChanged(bindable, oldValue, newValue), 
			null, 
			null);

		public static BindableProperty WidthFactorProperty = BindableProperty.CreateAttached<BindableRelativeLayout, double>(
			bindable => GetWidthFactor(bindable),
			1.0, 
			BindingMode.OneWay, 
			null, 
			(bindable, oldValue, newValue) => OnLayoutChanged(bindable, oldValue, newValue), 
			null, 
			null);

		public static BindableProperty HeightFactorProperty = BindableProperty.CreateAttached<BindableRelativeLayout, double>(
			bindable => GetHeightFactor(bindable),
			1.0, 
			BindingMode.OneWay, 
			null, 
			(bindable, oldValue, newValue) => OnLayoutChanged(bindable, oldValue, newValue), 
			null, 
			null);
	
		public static string GetElementName(BindableObject obj) 
		{
			return obj.GetValue (ElementNameProperty) as string;
		}

		public static void SetElementName(BindableObject obj, string value)
		{
			obj.SetValue (ElementNameProperty, value);
		}

		public static double GetXFactor(BindableObject obj) 
		{
			return (double)obj.GetValue (XFactorProperty);
		}

		public static void SetXFactor(BindableObject obj, double value)
		{
			obj.SetValue (XFactorProperty, value);
		}

		public static double GetYFactor(BindableObject obj) 
		{
			return (double)obj.GetValue (YFactorProperty);
		}

		public static void SetYFactor(BindableObject obj, double value)
		{
			obj.SetValue (YFactorProperty, value);
		}

		public static double GetWidthFactor(BindableObject obj) 
		{
			return (double)obj.GetValue (WidthFactorProperty);
		}

		public static void SetWidthFactor(BindableObject obj, double value)
		{
			obj.SetValue (WidthFactorProperty, value);
		}

		public static double GetHeightFactor(BindableObject obj) 
		{
			return (double)obj.GetValue (HeightFactorProperty);
		}

		public static void SetHeightFactor(BindableObject obj, double value)
		{
			obj.SetValue (HeightFactorProperty, value);
		}

		private static void OnElementNameChanged(BindableObject obj, string oldValue, string newValue)
		{
		}

		private static void OnLayoutChanged(BindableObject obj, double oldValue, double newValue)
		{
			var view = obj as View;

			var parent = view.ParentView as Layout<View>;

			if (parent == null) {
				return;
			}

			parent.ForceLayout ();
		}

		#region implemented abstract members of Layout

		protected override void LayoutChildren (double x, double y, double width, double height)
		{
			var dependencies = new List<View> ();

			foreach (var child in Children) {
				var elementName = GetElementName (child);

				if (string.IsNullOrEmpty (elementName)) {
					LayoutChildIntoBoundingRegion (child, new Rectangle (x, y, Width, Height));
					continue;
				}

				dependencies.Add (child);
			}

			foreach (var dependency in dependencies) {
				var elementName = GetElementName (dependency);

				var xFactor = GetXFactor (dependency);
				var yFactor = GetYFactor (dependency);
				var weigthFactor = GetWidthFactor (dependency);
				var heightFactor = GetHeightFactor (dependency);

				var master = dependency.FindByName<View> (elementName);
				var masterRegion = new Rectangle (
					                   master.X + xFactor * master.Width,
					                   master.Y + yFactor * master.Height,
					                   master.Width * weigthFactor,
					                   master.Height * heightFactor);

				LayoutChildIntoBoundingRegion (dependency, masterRegion);
			}
		}

		#endregion


	}
}

