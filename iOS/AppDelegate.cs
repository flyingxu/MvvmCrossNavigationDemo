
using Foundation;
using MvvmCross.Platforms.Ios.Core;
using MvvmCrossNavigationDemo.Core;
using UIKit;
using Xamarin.Forms;

namespace MvvmCrossNavigationDemo.iOS
{
    [Register("AppDelegate")]
	public class AppDelegate : MvxApplicationDelegate<Setup, App>
	{
		public override bool FinishedLaunching(UIApplication application, NSDictionary launchOptions)
		{
            var result = base.FinishedLaunching(application, launchOptions);
            return result;
		}
	}
}

