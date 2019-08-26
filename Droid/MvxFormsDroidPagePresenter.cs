using System.Collections.Generic;
using System.Reflection;
using System.Threading.Tasks;
using Android.App;
using MvvmCross.Platforms.Android.Presenters;
using MvvmCross.Presenters.Hints;
using MvvmCross.ViewModels;
using MvvmCross.Views;
using MvvmCrossNavigationDemo.Core;

namespace MvvmCrossNavigationDemo.Droid
{
    public class MvxFormsDroidPagePresenter : MvxAndroidViewPresenter, IMvxAndroidViewPresenter
    {
        public MvxFormsDroidPagePresenter (IEnumerable<Assembly> androidViewAssemblies) : base(androidViewAssemblies)
        {
        }

        public override Task<bool> ChangePresentation(MvxPresentationHint hint)
        {
            if (hint is MvxClosePresentationHint)
            {
                var viewModel = (hint as MvxClosePresentationHint).ViewModelToClose;

                Activity activity = this.CurrentActivity;

                IMvxView mvxView = activity as IMvxView;

                activity.Finish();
            }

            return Task.FromResult(true);
        }

        public override Task<bool> Show (MvxViewModelRequest request)
        {
            //detect if we want a Forms View 
            if (request.ViewModelType.FullName.Contains ("XFViewModel")) {
                //get the Forms page from the request 
                var contentPage = MvxPresenterHelpers.CreatePage (request);

                //set DataContext of page to LoadViewModel
                var viewModel = MvxPresenterHelpers.LoadViewModel (request);

                //set the binding context of the content page
                contentPage.BindingContext = viewModel;

                //set the current page of the activity 
                MvxFormsApplicationActivity.CurrentPage = contentPage;

                //Start the Xamarin.Forms Activity
                CurrentActivity.StartActivity (typeof(MvxFormsApplicationActivity));
                return Task.FromResult(true);

            } else {
                return base.Show (request);
            }
        }
    }

}

