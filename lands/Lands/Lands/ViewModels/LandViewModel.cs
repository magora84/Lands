

namespace Lands.ViewModels
{
    using Models;
    public class LandViewModel {
        private LandItemViewModel landItemViewModel;

        #region propiedades
        public Land Land { get; set; }

        #endregion

        #region Constructor
        public LandViewModel(Land land) {
            this.Land = land;
        }
        #endregion

    }
}
