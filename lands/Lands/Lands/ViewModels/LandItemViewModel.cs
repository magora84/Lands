﻿
namespace Lands.ViewModels {
    using GalaSoft.MvvmLight.Command;
    using Views;
    using Models;
    using System.Windows.Input;
    using Xamarin.Forms;

    public class LandItemViewModel : Land {
        #region commandos
        public ICommand Command {
            get {
                return new RelayCommand(SelectLand);
            }
        }

        private async void SelectLand() {
            MainViewModel.GetInstance().Land = new LandViewModel(this);
            await Application.Current.MainPage.Navigation.PushAsync(new LandPage());
        }
        #endregion
    }
}
