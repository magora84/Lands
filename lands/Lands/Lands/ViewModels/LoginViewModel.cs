namespace Lands.ViewModels {
    using GalaSoft.MvvmLight.Command;
    using System.ComponentModel;
    using System.Windows.Input;
    using Xamarin.Forms;
    using Views;
    using Lands.Servicios;
    using Helpers;
    public class LoginViewModel : BaseViewModel {

        #region servicios
        private ApiService apiService;
        #endregion

        #region Atributos
        private string email;
        private string password;
        private bool isRunnig;
        private bool isEnabled;

        #endregion

        #region Propiedades
        public string Email {
            get {
                return this.email;
            }
            set { SetValue(ref this.email, value); }
        }
        public string Password {
            get {
                return this.password;
            }
            set { SetValue(ref this.password, value); }

        }
        public bool IsRunning {

            get {
                return this.isRunnig;
            }
            set { SetValue(ref this.isRunnig, value); }
        }
        public bool IsRemembered { get; set; }
        public bool IsEnabled {
            get {
                return this.isEnabled;
            }
            set { SetValue(ref this.isEnabled, value); }
        }

        #endregion

        #region constructor
        public LoginViewModel() {
            this.apiService = new ApiService();
            this.IsRemembered = true;
            this.IsEnabled = true;
        // this.Email = "magora84@hotmail.com";
        //  this.Password = "123456";
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
                    Languages.Error
                    , Languages.EmailValidation
                    , Languages.Accept);
                return;
            }
            if (string.IsNullOrEmpty(this.Password)) {
                await Application.Current.MainPage.DisplayAlert(
                    "Error"
                    , "Debes introducir tu Password"
                    , "Aceptar");
                return;
            }

            this.IsRunning = true;
            this.IsEnabled = false;
            var connection = await this.apiService.CheckConnection();
            if (!connection.IsSuccess) {
                this.IsRunning = false;
                this.IsEnabled = true;
                await Application.Current.MainPage.DisplayAlert(
                    "error",
                    connection.Message,
                    "aceptar"
                    );
                this.Password = string.Empty;
                return;
            }
            var apiSecurity = Application.Current.Resources["APISecurity"].ToString();
            var token = await this.apiService.GetToken(apiSecurity, this.Email, this.Password);
            if (token == null) {
                this.IsRunning = false;
                this.IsEnabled = true;
                await Application.Current.MainPage.DisplayAlert(
                    "error",
                    "algo salio mal intenta de nuevo",
                    "aceptar"
                    );
                this.Password = string.Empty;
                return;
            }
            if (string.IsNullOrEmpty(token.AccessToken)) {
                this.IsRunning = false;
                this.IsEnabled = true;
                await Application.Current.MainPage.DisplayAlert(
                    "error",
                    token.ErrorDescription,
                    "aceptar"
                    );
                this.Password = string.Empty;
                return;
            }
            var user = await this.apiService.GetUserByEmail(apiSecurity, "/api/", "/Users/GetUserByEmail", 
                this.Email);

            var mainViewModel = MainViewModel.GetInstance();
            mainViewModel.Token = token.AccessToken;
            mainViewModel.TokenType = token.TokenType;
            if (this.IsRemembered) {
                Settings.Token = token.AccessToken;
                Settings.TokenType = token.TokenType;
            }
    
            mainViewModel.Lands = new LansViewModel();
            Application.Current.MainPage = new MasterPage();
            // await Application.Current.MainPage.Navigation.PushAsync(new LandsPage());
            this.IsRunning = false;
            this.IsEnabled = true;

            this.Email = string.Empty;
            this.Password = string.Empty;
         
        }
        public ICommand RegisterCommand {

            get { return new RelayCommand(Register); }
        }

        private async void Register() {
            MainViewModel.GetInstance().Register = new RegisterViewModel();
            await Application.Current.MainPage.Navigation.PushAsync(new RegisterPage());
        }
        #endregion

    }
}
