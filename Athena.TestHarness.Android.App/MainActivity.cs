using System;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Athena.TestHarness.Pcl.Views;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

namespace Athena.TestHarness.Android.App
{
	[Activity (Label = "Athena.TestHarness.Android.App", MainLauncher = true, Icon = "@drawable/icon")]
	public class MainActivity : AndroidActivity
	{
		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);

			Forms.Init (this, bundle);

			SetPage (new NavigationPage(new TestHarnessPage ()));
		}
	}
}


