﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Lands.Infrastructure
{
    using ViewModels;
   public class InstanceLocator
    {
        #region propiedades
        public  MainViewModel Main { get; set; }
        #endregion
        #region Constructors
        public InstanceLocator() {
            this.Main= new MainViewModel();
        }

        #endregion
    }

}
