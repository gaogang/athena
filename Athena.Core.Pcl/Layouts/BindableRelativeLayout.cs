using System;
using System.Collections.Generic;
using System.Linq;
using Xamarin.Forms;
using Athena.Core.Pcl.Internal;

namespace Athena.Core.Pcl.Layouts
{
	public class BindableRelativeLayout : Layout<View>
	{
		public static BindableProperty ElementNameProperty = BindableProperty.CreateAttached<BindableRelativeLayout, string>(
			bindable => GetElementName(bindable),
			string.Empty);

		public static BindableProperty ModeProperty = BindableProperty.CreateAttached<BindableRelativeLayout, RelativeLayoutMode>(
			bindable => GetMode(bindable),
			RelativeLayoutMode.Offset);

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

		public static BindableProperty DegreeProperty = BindableProperty.CreateAttached<BindableRelativeLayout, double>(
			bindable => GetDegree(bindable),
			0.0, 
			BindingMode.OneWay, 
			null, 
			(bindable, oldValue, newValue) => OnLayoutChanged(bindable, oldValue, newValue), 
			null, 
			null);

		public static BindableProperty RProperty = BindableProperty.CreateAttached<BindableRelativeLayout, double>(
			bindable => GetR(bindable),
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

		public static RelativeLayoutMode GetMode(BindableObject obj) 
		{
			return (RelativeLayoutMode)obj.GetValue (ModeProperty);
		}

		public static void SetMode(BindableObject obj, RelativeLayoutMode value)
		{
			obj.SetValue (ModeProperty, value);
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

		public static double GetDegree(BindableObject obj) 
		{
			return (double)obj.GetValue (DegreeProperty);
		}

		public static void SetDegree(BindableObject obj, double value)
		{
			obj.SetValue (DegreeProperty, value);
		}

		public static double GetR(BindableObject obj) 
		{
			return (double)obj.GetValue (RProperty);
		}

		public static void SetR(BindableObject obj, double value)
		{
			obj.SetValue (RProperty, value);
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
				var mode = GetMode (dependency);

				var master = dependency.FindByName<View> (elementName);

				Rectangle region;

				switch (mode) {
				case RelativeLayoutMode.Offset:
					region = GetBoundByOffset (dependency, master);
					break;
				case RelativeLayoutMode.Radian:
					region = GetBoundByRadian (dependency, master);
					break;
				default:
					throw new NotSupportedException ();
				}

				LayoutChildIntoBoundingRegion (dependency, region);
			}
		}

		#endregion

		private static Rectangle GetBoundByOffset(View dependency, View master)
		{
			var xFactor = GetXFactor (dependency);
			var yFactor = GetYFactor (dependency);

			var weigthFactor = GetWidthFactor (dependency);
			var heightFactor = GetHeightFactor (dependency);

			return new Rectangle (
				master.X + xFactor * master.Width,
				master.Y + yFactor * master.Height,
				master.Width * weigthFactor,
				master.Height * heightFactor);
		}

		private static Rectangle GetBoundByRadian(View dependency, View master)
		{
			var widthFactor = GetWidthFactor (dependency);
			var heightFactor = GetHeightFactor (dependency);

			var r = GetR (dependency);
			var degree = GetDegree (dependency);

			return RelativeLayoutCalculator.GetRelativePositionByRadian (
				master, 
				r,
				degree,
				widthFactor,
				heightFactor);
		}
	}
}

