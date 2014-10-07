using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Reactive.Linq;
using System.Reflection;
using System.Windows.Input;
using Xamarin.Forms;

namespace Athena.Core.Pcl.Event
{
	public class EventToCommand
	{
		public static readonly BindableProperty ToCommandProperty = 
			BindableProperty.CreateAttached<EventToCommand, ICommand>(
				bindable => EventToCommand.GetToCommand(bindable),
				null,
				BindingMode.OneWay, 
				null,
				(bindable, oldValue, newValue) => EventToCommand.OnCommandChanged(bindable, oldValue, newValue),
				null, 
				null);

		public static readonly BindableProperty FromEventProperty = 
			BindableProperty.CreateAttached<EventToCommand, string>(
				bindable => EventToCommand.GetFromEvent(bindable),
				null,
				BindingMode.OneWay);

		public static ICommand GetToCommand(BindableObject obj) 
		{
			return (ICommand)obj.GetValue(EventToCommand.ToCommandProperty);
		}

		public static void SetToCommand(BindableObject obj, ICommand value)
		{
			obj.SetValue(EventToCommand.ToCommandProperty, value);
		}

		public static string GetFromEvent(BindableObject obj) 
		{
			return (string)obj.GetValue(EventToCommand.FromEventProperty);
		}

		public static void SetFromEvent(BindableObject obj, string value)
		{
			obj.SetValue(EventToCommand.FromEventProperty, value);
		}

		private static void OnCommandChanged(BindableObject obj, ICommand oldValue, ICommand newValue)
		{
			var eventName = GetFromEvent (obj);

			if (string.IsNullOrEmpty (eventName)) {
				throw new InvalidOperationException ("FromEvent property is null or empty");
			}

			Observable.FromEventPattern (obj, eventName).Subscribe (p => {
				var command = GetToCommand(obj);

				if (command != null && 
					command.CanExecute(p.EventArgs)) {
					command.Execute(p.EventArgs);
				}
			});
		}
	}
}

