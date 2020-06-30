using System;
using System.Collections.Generic;
using System.Text;
using Prism.Mvvm;
using ReactiveUI.Fody.Helpers;

namespace $safeprojectname$.Models
{
    public class WalkThroughItemModel : BindableBase
    {
        [Reactive] public string Title { get; set; }
        [Reactive] public string Description { get; set; }
        //[Reactive] public string CenterImage { get; set; }
        //[Reactive] public Image BackgroundImage { get; set; }

    }
}
