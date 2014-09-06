using System;
using System.Threading.Tasks;
using Xamarin.Forms;
using Athena.ImagePicker.Pcl;

namespace Athena.ImagePicker
{
	public interface IImagePicker
	{
		Task<ImageSource> PickImageAsync();
	} 
}

