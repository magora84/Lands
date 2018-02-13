using System;
using System.Collections.Generic;
using System.Text;


namespace Lands.ViewModels {
    using GalaSoft.MvvmLight.Command;
    using System.ComponentModel;
    using System.Windows.Input;
    using Xamarin.Forms;

    public class LoginViewModel : INotifyPropertyChanged {
        #region eventos
        public event PropertyChangedEventHandler PropertyChanged;
        #endregion

        #region Atributos
        private string password;
        private bool isRunnig;
        private bool isEnabled;

        #endregion

        #region Propiedades
        public string Email { get; set; }
        public string Password { get; set; }
        public bool IsRunning { get; set; }
        public bool IsRemembered { get; set; }
        public bool IsEnabled { get; set; }

        #endregion

        #region constructor
        public LoginViewModel() {
            this.IsRemembered = true;
            this.IsEnabled= true;
        } 
        #endregion
        #region Commandos
        public ICommand LoginCommand {
            get {
                return new RelayCommand(login);
            }
        }



        private async void login() {
            if (string.IsNullOrEmpty(this.Email)) {
                await Application.Current.MainPage.DisplayAlert(
                    "Error"
                    , "Debes introducir tu email"
                    , "Aceptar");
                return;
            }
            if (string.IsNullOrEmpty(this.Password)) {
                await Application.Current.MainPage.DisplayAlert(
                    "Error"
                    , "Debes introducir tu Password"
                    , "Aceptar");
                return;
            }
            if (this.Email != "magora84@hotmail.com " || this.Password != "1234") {

                await Application.Current.MainPage.DisplayAlert(
                    "error",
                    "email o password incorrecto",
                    "aceptar"
                    );
                this.Password = string.Empty;
                return;
            }
            await Application.Current.MainPage.DisplayAlert(
               "ok",
               "fuck yEA",
               "aceptar"
               );
        }
        #endregion

    }
}
