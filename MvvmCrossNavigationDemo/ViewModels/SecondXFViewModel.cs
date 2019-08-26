using System;
using MvvmCross.Commands;
using MvvmCross.Navigation;
using MvvmCross.Presenters.Hints;
using MvvmCross.ViewModels;

namespace MvvmCrossNavigationDemo.Core.ViewModels
{
	public class SecondXFViewModel : MvxViewModel
	{
        private readonly IMvxNavigationService _navigationService;

        public SecondXFViewModel(IMvxNavigationService navigationService)
        {
            _navigationService = navigationService;
        }

        public string PageContent { 
			get {
				return "This is a Xamarin Forms Page, 2 of 3";
			}
		}

		public MvxCommand MoveToNext
		{
			get {
				return new MvxCommand (()=>{
                    _navigationService.Navigate<ThirdNativeViewModel>();
				});
			}
		}

		public MvxCommand MoveToFront
		{
			get {
				return new MvxCommand (()=>{
                    _navigationService.ChangePresentation(new MvxClosePresentationHint(this));
				});
			}
		}
	}
}

