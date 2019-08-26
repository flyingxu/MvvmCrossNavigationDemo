using MvvmCross.Platforms.Android.Core;
using MvvmCross.Platforms.Android.Presenters;
using MvvmCross.ViewModels;
using MvvmCrossNavigationDemo.Core;

namespace MvvmCrossNavigationDemo.Droid
{
    public class Setup : MvxAndroidSetup<App>
    {
		protected override IMvxAndroidViewPresenter CreateViewPresenter ()
		{
            return new MvxFormsDroidPagePresenter (AndroidViewAssemblies);
		}          
    }
}