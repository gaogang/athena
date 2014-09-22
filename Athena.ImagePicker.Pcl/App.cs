using System;
using Microsoft.Practices.Unity;
using Xamarin.Forms;
using Athena.ImagePicker.Pcl.Views;

namespace Athena.ImagePicker.Pcl
{
	public class App
	{
		private static IUnityContainer _unityContainer;

		public static IUnityContainer Container
		{
			get 
			{
				if (_unityContainer == null) {
					_unityContainer = new UnityContainer ();
				}

				return _unityContainer;
			}

			// Allow unit tests to inject the testing unity container
			internal set {
				_unityContainer = value;
			}
		}

		public static void Intitialise()
		{
			Container.RegisterType<IImagePicker, ImagePicker> (new ContainerControlledLifetimeManager());

			Container.RegisterType<IImageService, ImageService> (new ContainerControlledLifetimeManager ());
		}

		public static void Register<T>(T instance, LifetimeManager lifetimeManager)
		{
			Container.RegisterInstance<T> (instance, lifetimeManager);
		}
	}
}

