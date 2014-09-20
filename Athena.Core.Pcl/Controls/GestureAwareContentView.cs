using System;
using System.Windows.Input;
using Xamarin.Forms;

namespace Athena.Core.Pcl.Controls
{
	public class GestureAwareContentView : ContentView
	{
		public static BindableProperty LongPressProperty = BindableProperty.Create(
			"LongPress", 
			typeof(ICommand), 
			typeof(GestureAwareContentView), 
			null);

		public static BindableProperty PanProperty = BindableProperty.Create(
			"Pan", 
			typeof(ICommand), 
			typeof(GestureAwareContentView), 
			null);

		public static BindableProperty PinchProperty = BindableProperty.Create(
			"Pinch", 
			typeof(ICommand), 
			typeof(GestureAwareContentView), 
			null);

		public static BindableProperty RotateProperty = BindableProperty.Create(
			"Rotate", 
			typeof(ICommand), 
			typeof(GestureAwareContentView), 
			null);

		public static BindableProperty SwipeProperty = BindableProperty.Create(
			"Swipe", 
			typeof(ICommand), 
			typeof(GestureAwareContentView), 
			null);

		public ICommand LongPress
		{
			get {
				return GetValue (LongPressProperty) as ICommand;
			}

			set {
				SetValue (LongPressProperty, value);
			}
		}

		public ICommand Pan
		{
			get {
				return GetValue (PanProperty) as ICommand;
			}

			set {
				SetValue (PanProperty, value);
			}
		}

		public ICommand Pinch
		{
			get {
				return GetValue (PinchProperty) as ICommand;
			}

			set {
				SetValue (PinchProperty, value);
			}
		}

		public ICommand Rotate
		{
			get {
				return GetValue (RotateProperty) as ICommand;
			}

			set {
				SetValue (RotateProperty, value);
			}
		}

		public ICommand Swipe
		{
			get {
				return GetValue (SwipeProperty) as ICommand;
			}

			set {
				SetValue (SwipeProperty, value);
			}
		}
	}
}

