using System;

namespace Athena.TestHarness.Pcl.Models
{
	public class Email
	{
		public string From { get; set; }

		public string Subject { get; set; }

		/// <summary>
		/// I am going to make it simple here. The string will be something like
		/// Yesterday, Today
		/// </summary>
		/// <value>The receive at.</value>
		public string ReceiveAt { get; set; }
	}
}

