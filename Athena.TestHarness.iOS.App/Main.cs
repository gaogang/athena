using System;
using System.Collections.Generic;
using System.Linq;

using Athena.Core.Pcl;
using MonoTouch.Foundation;
using MonoTouch.UIKit;

namespace Athena.TestHarness.iOS.App
{
	public class Application
	{
		#pragma warning disable 0219, 0649

		private static bool falseFlag = false;

		// This is the main entry point of the application.
		static void Main (string[] args)
		{
			if (falseFlag) {
				new CoreFalseFlag ();
			}
			// if you want to use a different Application Delegate class from "AppDelegate"
			// you can specify it here.
			UIApplication.Main (args, null, "AppDelegate");
		}

		#pragma warning restore 0219, 0649
	}
}
