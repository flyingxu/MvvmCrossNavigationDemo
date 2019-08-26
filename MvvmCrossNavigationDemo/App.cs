using MvvmCross;
using MvvmCross.IoC;
using MvvmCross.ViewModels;

namespace MvvmCrossNavigationDemo.Core
{
	public class App : MvxApplication
    {
        public override void Initialize()
        {
            CreatableTypes()
                .EndingWith("Service")
                .AsInterfaces()
                .RegisterAsLazySingleton();
				
            RegisterAppStart<ViewModels.FirstNativeViewModel>();
        }
    }
}