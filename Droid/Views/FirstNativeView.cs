
using Android.App;
using Android.OS;
using MvvmCross.Platforms.Android.Views;

namespace MvvmCrossNavigationDemo.Droid
{
    [Activity (Label = "FirstNativeView", Theme="@android:style/Theme.Light.NoTitleBar")]			
	public class FirstNativeView : MvxActivity
	{
		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);

			SetContentView(Resource.Layout.FirstNativeView);
		}
	}
}

