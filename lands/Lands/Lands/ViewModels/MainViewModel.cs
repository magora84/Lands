
namespace Lands.ViewModels
{
    using Lands.Helpers;
    using Models;
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;

    public class MainViewModel
    {
        #region Propiedades 
        public  List<Land> LandsList { get; set; }
        // public TokenResponse Token { get; set; }
        public string Token { get; set; }
        public string TokenType { get; set; }
        public ObservableCollection<MenuItemViewModel> Menus { get; set; }
        public UserLocal User { get; set; }
        #endregion

        #region ViewModels 
        public LoginViewModel Login { get; set; }
        public RegisterViewModel Register { get; set; }
        public LansViewModel Lands { get; set; }
        public LandViewModel Land { get; set; }
       public MyProfileViewModel MyProfile { get; set; }
        #endregion



        #region Constructors
        public MainViewModel() {
            instance = this;
            this.Login = new LoginViewModel();
            this.LoadMenu();
        }

        
        #endregion

        #region Singleton
        private static MainViewModel instance;
        public static MainViewModel GetInstance() {
            if (instance == null) {
                return new MainViewModel();
            }
            return instance;
        }
        #endregion

        #region metodos
        private void LoadMenu() {
            this.Menus = new ObservableCollection<MenuItemViewModel>();

            this.Menus.Add(new MenuItemViewModel {
                Icon = "ic_settings",
                PageName = "MyProfilePage",
                Title = Languages.MyProfile,
            });

            this.Menus.Add(new MenuItemViewModel {
                Icon = "ic_insert_chart",
                PageName = "StaticPage",
                Title = Languages.Statics,
            });
            this.Menus.Add(new MenuItemViewModel {
                Icon = "ic_exit_to_app",
                PageName = "LoginPage",
                Title = Languages.LogOut,
            });

        }
        #endregion
    }

}
