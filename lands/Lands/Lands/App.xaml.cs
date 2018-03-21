
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lands
{
    using Views;
    using Xamarin.Forms; 

    public partial class App : Application
	{
        #region properties
        public static NavigationPage Navigator { get; internal set; }
        
        #endregion
        #region Constructors
        public App ()
		{
			InitializeComponent();

			MainPage =new MasterPage() /*{ BarBackgroundColor = Color.FromHex("#c31441") }*/;
          //  MainPage = new NavigationPage(new LoginPage()) /*{ BarBackgroundColor = Color.FromHex("#c31441") }*/;
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
