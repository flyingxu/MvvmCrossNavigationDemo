
using System.Threading.Tasks;
using MvvmCross.Platforms.Ios.Presenters;
using MvvmCross.Platforms.Ios.Presenters.Attributes;
using MvvmCross.ViewModels;
using MvvmCrossNavigationDemo.Core;
using UIKit;
using Xamarin.Forms;

namespace MvvmCrossNavigationDemo.iOS
{
    public class MvxFormsTouchPagePresenter : MvxIosViewPresenter
    {
    	public MvxFormsTouchPagePresenter (IUIApplicationDelegate applicationDelegate, UIWindow window) : base (applicationDelegate, window)
    	{
    	}

    	public override Task<bool> ChangePresentation (MvxPresentationHint hint)
    	{
            this.MasterNavigationController.PopViewController (true);
            return Task.FromResult(true);
    	}

    	public override async Task<bool> Show (MvxViewModelRequest request)
    	{
            // XFViewModel means we need a Forms View
            if (request.ViewModelType.FullName.Contains ("XFViewModel")) 
            {
                //get the xamarin.forms page from the ViewModel
                var contentPage = MvxPresenterHelpers.CreatePage (request); 

                //MvvmCross call to create the view model with DI etc
                var viewModel = MvxPresenterHelpers.LoadViewModel (request); 

                //Assign it to the Forms Binding Content
                contentPage.BindingContext = viewModel;				

                //Creating the view controller from the content page
                var viewController = contentPage.CreateViewController ();
				viewController.Title = contentPage.Title;

                if (this.MasterNavigationController == null) 
                {
                    // If it's the first view
                    MvxRootPresentationAttribute attribute = new MvxRootPresentationAttribute()
                    {
                        AnimationDuration = MvxRootPresentationAttribute.DefaultAnimationDuration,
                        AnimationOptions = MvxRootPresentationAttribute.DefaultAnimationOptions,
                        ViewModelType = request.ViewModelType
                    };

                    return await this.ShowRootViewController(viewController, attribute, request);
                } 
                else 
                {
                    // If it's already in the stack
                    this.MasterNavigationController.PushViewController(viewController, true);
                    return await Task.FromResult(true);
                }

            } 
            else 
            {
                //Using a normal MvvmCross View
                return await base.Show (request);
            }
    	}
    }
}

