using System;
using System.Windows.Input;
using Athena.Core.Pcl.ViewModels;
using Athena.TestHarness.Pcl.Views;
using Xamarin.Forms;

namespace Athena.TestHarness.Pcl.ViewModels
{
	public class TestHarnessPageViewModel : ViewModelBase
	{
		private readonly ICommand _gestureAwareContentViewCommand;
		private readonly ICommand _circleViewCommand;
		private readonly ICommand _relativeLayoutCommand;
		private readonly ICommand _animationCommand;
		private readonly ICommand _eventToCommand;
		private readonly ICommand _masterMenuPageCommand;

		public TestHarnessPageViewModel ()
		{
			_relativeLayoutCommand = new Command(RelativeLayoutCommandExecute);
			_gestureAwareContentViewCommand = new Command (GestureAwareContentViewCommandExecute);
			_circleViewCommand = new Command (CircleViewCommandExecute);
			_animationCommand = new Command(AnimationCommandExecute);
			_eventToCommand = new Command(EventToCommandExecute);
			_masterMenuPageCommand = new Command(MasterMenuPageCommandExecute);
		}

		public ICommand MasterMenuPageCommand 
		{
			get {
				return _masterMenuPageCommand;
			}
		}

		public ICommand GestureAwareContentViewCommand
		{
			get {
				return _gestureAwareContentViewCommand;
			}
		}

		public ICommand CircleViewCommand
		{
			get {
				return _circleViewCommand;
			}
		}

		public ICommand RelativeLayoutCommand 
		{
			get {
				return _relativeLayoutCommand;
			}
		}

		public ICommand AnimationCommand 
		{
			get {
				return _animationCommand;
			}
		}

		public ICommand EventToCommand 
		{
			get {
				return _eventToCommand;
			}
		}

		private void RelativeLayoutCommandExecute(object args) 
		{
			View.NavigateTo (new RelatieLayoutDemoPage ());
		}

		private void GestureAwareContentViewCommandExecute(object args)
		{
			View.NavigateTo (new GestureAwareContentViewDemoPage ());
		}

		private void CircleViewCommandExecute(object args)
		{
			View.NavigateTo (new CircleViewDemoPage ());
		}

		private void AnimationCommandExecute(object args) 
		{
			View.NavigateTo (new PopupButtonDemoPage ());
		}

		private void EventToCommandExecute(object args) 
		{
			View.NavigateTo (new EventToCommandDemoPage ());
		}

		private void MasterMenuPageCommandExecute(object args) 
		{
			View.NavigateTo (new MasterDetailPageDemoPage ());
		}
	}
}

