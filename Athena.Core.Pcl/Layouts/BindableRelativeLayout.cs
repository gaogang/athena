using System;
using System.Collections.Generic;
using System.Linq;
using Xamarin.Forms;

namespace Athena.Core.Pcl.Layouts
{
	public class BindableRelativeLayout : Layout<View>
	{
		public static BindableProperty ElementNameProperty = BindableProperty.CreateAttached<BindableRelativeLayout, string>(
			bindable => GetElementName(bindable),
			string.Empty);

		public static BindableProperty XProperty = BindableProperty.CreateAttached<BindableRelativeLayout, double>(
			bindable => GetX(bindable),
			0.0, 
			BindingMode.OneWay, 
			null, 
			(bindable, oldValue, newValue) => OnLayoutChanged(bindable, oldValue, newValue), 
			null, 
			null);

		public static BindableProperty YProperty = BindableProperty.CreateAttached<BindableRelativeLayout, double>(
			bindable => GetY(bindable),
			0.0, 
			BindingMode.OneWay, 
			null, 
			(bindable, oldValue, newValue) => OnLayoutChanged(bindable, oldValue, newValue), 
			null, 
			null);

		public static BindableProperty WidthProperty = BindableProperty.CreateAttached<BindableRelativeLayout, double>(
			bindable => GetWidth(bindable),
			1.0, 
			BindingMode.OneWay, 
			null, 
			(bindable, oldValue, newValue) => OnLayoutChanged(bindable, oldValue, newValue), 
			null, 
			null);

		public static BindableProperty HeightProperty = BindableProperty.CreateAttached<BindableRelativeLayout, double>(
			bindable => GetHeight(bindable),
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

		public static double GetX(BindableObject obj) 
		{
			return (double)obj.GetValue (XProperty);
		}

		public static void SetX(BindableObject obj, double value)
		{
			obj.SetValue (XProperty, value);
		}

		public static double GetY(BindableObject obj) 
		{
			return (double)obj.GetValue (YProperty);
		}

		public static void SetY(BindableObject obj, double value)
		{
			obj.SetValue (YProperty, value);
		}

		public static double GetWidth(BindableObject obj) 
		{
			return (double)obj.GetValue (WidthProperty);
		}

		public static void SetWidth(BindableObject obj, double value)
		{
			obj.SetValue (WidthProperty, value);
		}

		public static double GetHeight(BindableObject obj) 
		{
			return (double)obj.GetValue (HeightProperty);
		}

		public static void SetHeight(BindableObject obj, double value)
		{
			obj.SetValue (HeightProperty, value);
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

				var xFactor = GetX (dependency);
				var yFactor = GetY (dependency);
				var weigthFactor = GetWidth (dependency);
				var heightFactor = GetHeight (dependency);

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

