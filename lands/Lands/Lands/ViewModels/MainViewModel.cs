
namespace Lands.ViewModels
{
    using Models;
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;

    public class MainViewModel
    {
        #region Propiedades 
        public  List<Land> LandsList { get; set; }
        public TokenResponse Token { get; set; }
        public ObservableCollection<MenuItemViewModel> Menus { get; set; }
        #endregion

        #region ViewModels 
        public LoginViewModel Login { get; set; }
        public LansViewModel Lands { get; set; }
        public LandViewModel Land { get; set; }
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
    }
    #region metodos
    private void LoadMenu() {
        this.Menus = new ObservableCollection<MenuItemViewModel>();
        this.Menus.Add(new MenuItemViewModel {
        Icon="",
        PageName="",
        Title=""});
    }
    #endregion
}
