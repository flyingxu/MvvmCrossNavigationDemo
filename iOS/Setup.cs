using MvvmCross.Platforms.Ios.Core;
using MvvmCross.Platforms.Ios.Presenters;
using MvvmCross.ViewModels;
using MvvmCrossNavigationDemo.Core;
using Xamarin.Forms;

namespace MvvmCrossNavigationDemo.iOS
{
    public class Setup : MvxIosSetup<App>
    {
        protected override IMvxApplication CreateApp()
        {
            return new Core.App();
        }

        protected override IMvxIosViewPresenter CreateViewPresenter()
        {
            Forms.Init();
            return new MvxFormsTouchPagePresenter(ApplicationDelegate, Window);
        }
    }
}