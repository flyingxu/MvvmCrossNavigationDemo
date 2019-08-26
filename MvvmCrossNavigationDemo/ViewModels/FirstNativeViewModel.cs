using System;
using MvvmCross.Commands;
using MvvmCross.Navigation;
using MvvmCross.Presenters.Hints;
using MvvmCross.ViewModels;

namespace MvvmCrossNavigationDemo.Core.ViewModels
{
	public class FirstNativeViewModel: MvxViewModel
	{
        private readonly IMvxNavigationService _navigationService;

        public FirstNativeViewModel (IMvxNavigationService navigationService)
		{
            _navigationService = navigationService;
        }

		public string PageContent { 
			get {
				return "This is a Native Page, 1 of 3";
			}
		}

        public MvxCommand MoveToFront {
            get {

                return new MvxCommand (() => {
                    _navigationService.ChangePresentation(new MvxClosePresentationHint(this));
                });
            }
        } 

		public MvxCommand MoveToNext
		{
			get {
				return new MvxCommand (()=>{
                    _navigationService.Navigate<SecondXFViewModel>();
				});
			}
		}
	}
}

