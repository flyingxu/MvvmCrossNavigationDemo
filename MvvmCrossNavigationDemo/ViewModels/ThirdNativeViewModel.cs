using System;
using MvvmCross.Commands;
using MvvmCross.Navigation;
using MvvmCross.Presenters.Hints;
using MvvmCross.ViewModels;

namespace MvvmCrossNavigationDemo.Core.ViewModels
{
	public class ThirdNativeViewModel: MvxViewModel
	{
        private readonly IMvxNavigationService _navigationService;

        public ThirdNativeViewModel(IMvxNavigationService navigationService)
        {
            _navigationService = navigationService;
        }

        public string PageContent { 
			get {
				return "This is a Native Page, 3 of 3";
			}
		}


		public MvxCommand MoveToFront {
			get {

				return new MvxCommand (() => {
                    _navigationService.ChangePresentation(new MvxClosePresentationHint(this));
				});
			}
		} 

        public MvxCommand MoveToNext {
            get {

                return new MvxCommand (() => {
                    _navigationService.Navigate<FirstNativeViewModel>();
                });
            }
        } 
	}
}

