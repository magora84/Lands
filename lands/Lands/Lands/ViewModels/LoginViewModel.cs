using System;
using System.Collections.Generic;
using System.Text;


namespace Lands.ViewModels
{
    using GalaSoft.MvvmLight.Command;
    using System.Windows.Input;
    using Xamarin.Forms;

    public class LoginViewModel
    {
        #region Propiedades
        public string Email { get; set; }
        public string Password { get; set; }
        public bool IsRunning { get; set; }
        public bool IsRemembered { get; set; }
        #endregion

        public LoginViewModel() {
            this.IsRemembered = true;

        }
        #region Commandos
        public ICommand LoginCommand {
            get {
                return new RelayCommand(Login);
            }
        }

        private async void Login() {
            if (string.IsNullOrEmpty(this.Email)) {
                await Application.Current.MainPage.DisplayAlert(
                    "Error"
                    , "Debes introducir tu email"
                    , "Aceptar");
            }
            if (string.IsNullOrEmpty(this.Password)) {
                await Application.Current.MainPage.DisplayAlert(
                    "Error"
                    , "Debes introducir tu Password"
                    , "Aceptar");
            }
        }
        #endregion

    }
}
