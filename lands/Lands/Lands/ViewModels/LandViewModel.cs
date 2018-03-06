

namespace Lands.ViewModels
{
    using Models;
    using System;
    using System.Collections.ObjectModel;
    using System.Linq;

    public class LandViewModel: BaseViewModel {

        #region  Attributes
        private ObservableCollection<Border> borders;
        private ObservableCollection<Currency> currencies;
        private ObservableCollection<Language> languajes;
        #endregion

        #region propiedades
        public Land Land { get; set; }

        public ObservableCollection<Border> Borders {
            get { return this.borders; }
            set { this.SetValue(ref this.borders, value); }
        }

        public ObservableCollection<Currency> Currencies {
            get { return this.currencies; }
            set { this.SetValue(ref this.currencies, value); }
        }
        public ObservableCollection<Language> Languajes {
            get { return this.languajes; }
            set { this.SetValue(ref this.languajes, value); }
        }

        #endregion

        #region Constructor
        public LandViewModel(Land land) {
            this.Land = land;
            this.LoadBorders();
            this.Currencies = new ObservableCollection<Currency>(this.Land.Currencies);
            this.Languajes = new ObservableCollection<Language>(this.Land.Languages);
        }

    
        #endregion

       
        private void LoadBorders() {
            this.Borders = new ObservableCollection<Border>();
            foreach (var border in this.Land.Borders) {
                var land = MainViewModel.GetInstance().LandsList.Where(l => l.Alpha3Code == border).FirstOrDefault();
                if (land != null) {
                    this.Borders.Add(new Border {
                        Code = land.Alpha3Code,
                        Name = land.Name,
                    });
                }
            }
        }
    }
}
