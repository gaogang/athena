using System;
using System.Collections.Generic;
using System.Windows.Input;
using Athena.Core.Pcl.ViewModels;

using Xamarin.Forms;
using Athena.TestHarness.Pcl.Models;

namespace Athena.TestHarness.Pcl.ViewModels
{
	public class DetailPageViewModel : ViewModelBase
	{
		private IEnumerable<Email> _emails;

		private readonly ICommand _menuCommand;

		public DetailPageViewModel ()
		{
			InitialiseEmails ();

			_menuCommand = new Command (MenuCommandExecute);
		}

		public IEnumerable<Email> Emails
		{
			get {
				return _emails;
			}
		}

		public ICommand MenuCommand 
		{
			get {
				return _menuCommand;
			}
		}

		private void MenuCommandExecute(object args)
		{
			MessagingCenter.Send<DetailPageViewModel> (this, "Pop");
		}

		private void InitialiseEmails()
		{
			_emails = new List<Email> {
				new Email
				{
					From = "Code Project",
					Subject = "Windows 10 to have enterprise...",
					ReceiveAt = "Today"
				},
				new Email
				{
					From = "ParentMail",
					Subject = "You have been sent a new message",
					ReceiveAt = "Today"
				},
				new Email
				{
					From = "WordPress.com",
					Subject = "[C.D.D] You liked you own post: eh....",
					ReceiveAt = "Today"
				},
				new Email
				{
					From = "inbox@google.com",
					Subject = "Re: I would like an invitation to Inbox",
					ReceiveAt = "Today"
				},
				new Email
				{
					From = "Simon Cowell",
					Subject = "You are definitely my X-Factor",
					ReceiveAt = "Today"
				},
				new Email
				{
					From = "Code Project",
					Subject = "Windows 10 to have enterprise...",
					ReceiveAt = "Today"
				},
				new Email
				{
					From = "DPD",
					Subject = "Great news, your Amazon parcel has...",
					ReceiveAt = "Yesterday"
				},
				new Email
				{
					From = "Xamarin",
					Subject = "Join Xamarin in London at Future Decode",
					ReceiveAt = "Yesterday"
				}
			};
		}
	}
}

