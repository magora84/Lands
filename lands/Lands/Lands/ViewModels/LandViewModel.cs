

namespace Lands.ViewModels
{
    using Models;
    using System;
    using System.Collections.ObjectModel;
    using System.Linq;

    public class LandViewModel: BaseViewModel {

        #region  Attributes
        private ObservableCollection<Border> borders;

        #endregion

        #region propiedades
        public Land Land { get; set; }
        #endregion

        #region Constructor
        public LandViewModel(Land land) {
            this.Land = land;
            this.LoadBorders();
        }

    
        #endregion

        public ObservableCollection<Border> Borders {
            get { return this.borders; }
            set { this.SetValue(ref this.borders, value); }
        }
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
