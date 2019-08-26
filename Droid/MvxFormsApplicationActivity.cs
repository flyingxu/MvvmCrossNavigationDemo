
using Android.App;
using Android.OS;
using MvvmCross;
using MvvmCross.Platforms.Android.Core;
using MvvmCross.Platforms.Android.Views;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

namespace MvvmCrossNavigationDemo.Droid
{
    [Activity (Label = "XamarinForm", Theme = "@android:style/Theme.Holo.Light", NoHistory = false)]
    public class MvxFormsApplicationActivity : FormsApplicationActivity
    {
        public static Page CurrentPage;

        protected override void OnCreate (Bundle savedInstanceState)
        {
            base.OnCreate (savedInstanceState);

            Forms.Init (this, savedInstanceState);

            if (Xamarin.Forms.Application.Current == null)
            {
                LoadApplication(new Xamarin.Forms.Application()
                {
                    MainPage = CurrentPage
                });
            }
            else
            {
                Xamarin.Forms.Application.Current.MainPage = CurrentPage;
            }

            var lifetimeMonitor = Mvx.IoCProvider.Resolve<IMvxAndroidActivityLifetimeListener>() as MvxAndroidLifetimeMonitor;
            lifetimeMonitor.OnCreate(this, savedInstanceState);
        }

        protected override void OnStart ()
        {
            base.OnStart ();
            var lifetimeMonitor = Mvx.IoCProvider.Resolve<IMvxAndroidActivityLifetimeListener> () as MvxAndroidLifetimeMonitor;
            lifetimeMonitor.OnStart (this);
        }

        protected override void OnRestart ()
        {
            base.OnRestart ();
            var lifetimeMonitor = Mvx.IoCProvider.Resolve<IMvxAndroidActivityLifetimeListener> () as MvxAndroidLifetimeMonitor;
            lifetimeMonitor.OnRestart (this);
        }

        protected override void OnResume ()
        {
            base.OnResume ();
            var lifetimeMonitor = Mvx.IoCProvider.Resolve<IMvxAndroidActivityLifetimeListener> () as MvxAndroidLifetimeMonitor;
            lifetimeMonitor.OnResume (this);
        }

        protected override void OnDestroy ()
        {
            base.OnDestroy ();
            var lifetimeMonitor = Mvx.IoCProvider.Resolve<IMvxAndroidActivityLifetimeListener> () as MvxAndroidLifetimeMonitor;
            lifetimeMonitor.OnDestroy (this);
        }
    }
}

