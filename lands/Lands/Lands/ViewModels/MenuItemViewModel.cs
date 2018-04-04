using GalaSoft.MvvmLight.Command;
using Lands.Views;
using System;
using System.Windows.Input;
using Xamarin.Forms;
using Lands.Helpers;

namespace Lands.ViewModels
{
	public class MenuItemViewModel 
	{
        #region propiedades
        public string Icon { get; set; }
        public string Title { get; set; }
        public string PageName { get; set; }

        #endregion
        #region Commandos
        public ICommand NavigateCommand {
            get { return new RelayCommand(Navigate); }
        }

        private void Navigate() {
            if (this.PageName=="LoginPage") {
                Settings.Token = string.Empty;
                Settings.Token = string.Empty;
                var mainViewModel = MainViewModel.GetInstance();
                mainViewModel.Token = string.Empty;
                mainViewModel.TokenType = string.Empty;

                Application.Current.MainPage = new NavigationPage(new LoginPage());

            }else if(this.PageName== "MyProfilePage") {
               // MainViewModel.GetInstance().MyProfile = new MyProfileViewModel();
                App.Navigator.PushAsync(new MyProfilePage());
            }
        }

        #endregion
    }
}