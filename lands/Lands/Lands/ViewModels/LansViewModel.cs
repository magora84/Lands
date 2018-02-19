
using System;
using System.Collections.Generic;
using System.Text;

namespace Lands.ViewModels
{
    using Servicios;
    using Models;
    using System.Collections.ObjectModel;
    using Xamarin.Forms;
    using System.Windows.Input;
    using GalaSoft.MvvmLight.Command;

    public class LansViewModel : BaseViewModel {
        #region servicios
        private ApiService apiService;
        
        #endregion

        #region Atributos
        private ObservableCollection<Land> lands;
        private bool isRefreshing;
        #endregion

        #region propiedades
        public ObservableCollection <Land> Lands {
            get {
                return this.lands;
            } set { SetValue(ref this.lands, value); }

        }
        public bool IsRefreshing {
            get { return this.isRefreshing; }
            set { SetValue(ref this.isRefreshing, value); }

        }
        #endregion
        #region constructor
        public LansViewModel() {
            this.apiService = new ApiService();
            this.LoadLands();
        }
        #endregion

        #region metodos
        private async void LoadLands() {
            this.IsRefreshing = false; 
            var connection = await this.apiService.CheckConnection();

            if (!connection.IsSuccess) {
                await Application.Current.MainPage.DisplayAlert("Error",connection.Message,"Accept");
                await Application.Current.MainPage.Navigation.PopAsync();
                return;
            }


            var response = await this.apiService.GetList<Land>("http://restcountries.eu", "/rest", "/v2/all");
            if (!response.IsSuccess) {
                await Application.Current.MainPage.DisplayAlert("error", response.Message, "aceptar");
                return;
            }
            var list = (List<Land>)response.Result;
            this.Lands = new ObservableCollection<Land>(list);
            this.IsRefreshing = false;
        }
        #endregion
        #region Commandos
        public ICommand Command { get {
                return new RelayCommand(LoadLands);
            } }
        #endregion
    }
}
