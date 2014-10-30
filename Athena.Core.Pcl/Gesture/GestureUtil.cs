using System;
using System.Windows.Input;

namespace Athena.Core.Pcl.Gesture
{
	public static class GestureUtil
	{
		public static void ExecuteCommand(
			ICommand command, 
			GestureArgs parameter = null) 
		{
			if (command != null &&
				command.CanExecute (parameter)) {
				command.Execute (parameter);
			}
		}
	}
}

