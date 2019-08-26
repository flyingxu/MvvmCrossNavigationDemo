
using Android.App;
using Android.OS;
using MvvmCross.Platforms.Android.Views;

namespace MvvmCrossNavigationDemo.Droid
{
    [Activity (Label = "ThirdNativeView", Theme="@android:style/Theme.Light.NoTitleBar")]			
	public class ThirdNativeView : MvxActivity
	{
		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);

			SetContentView(Resource.Layout.ThirdNativeView);
		}
	}
}

