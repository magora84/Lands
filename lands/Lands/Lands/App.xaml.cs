

namespace Lands
{
    using Lands.Helpers;
    using Views;
    using ViewModels;
    using Xamarin.Forms;
    using Services;
    using Lands.Models;

    public partial class App : Application
	{
        #region properties
        public static NavigationPage Navigator { get; internal set; }
        
        #endregion
        #region Constructors
        public App ()
		{
			InitializeComponent();
            if (string.IsNullOrEmpty(Settings.Token)) {
                MainPage = new NavigationPage(new LoginPage()) /*{ BarBackgroundColor = Color.FromHex("#c31441") }*/;

            }
            else {
                var dataSevice = new DataService();
                var user = dataSevice.First<UserLocal>(false);
                var mainViewModel = MainViewModel.GetInstance();

             
                mainViewModel.Token = Settings.Token;
                mainViewModel.Token = Settings.TokenType;
                mainViewModel.User = user;
                mainViewModel.Lands = new LansViewModel();
                MainPage = new MasterPage() /*{ BarBackgroundColor = Color.FromHex("#c31441") }*/;

            }
        }
        #endregion

        #region Methods
        protected override void OnStart ()
		{
			// Handle when your app starts
		}

		protected override void OnSleep ()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume ()
		{
			// Handle when your app resumes
		}
        #endregion
    }
}
