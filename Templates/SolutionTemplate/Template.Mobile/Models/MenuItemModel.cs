using System;
using System.Collections.Generic;
using System.Text;

namespace $safeprojectname$.Models
{
    public class MenuItemModel
    {
        public MenuItemModel()
        {
            //Defaut value
            IsActive = true;
        }

        public string Title { get; set; }

        public string NavigationPath { get; set; }

        public bool IsActive { get; set; }

        public string ItemImageSource { get; set; }
    }
}
