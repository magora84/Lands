using System;
using System.Collections.Generic;
using System.Text;


namespace Lands.ViewModels
{
    using System.Windows.Input;
    public class LoginViewModel
    {
        #region Propiedades
        public string Email { get; set; }
        public string Password { get; set; }
        public bool IsRunning { get; set; }
        public bool IsRemembered { get; set; }
        #endregion

        public LoginViewModel() {
            this.IsRemembered = true;

        }
        #region Commandos
        public ICommand LoginCommand { get; set; }
        #endregion

    }
}
