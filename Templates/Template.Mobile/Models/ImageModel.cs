using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Text;

namespace Template.Mobile.Models
{
    public class ImageModel : BindableBase
    {
        public string Filename { get; set; }
        public int ImageHeight { get; set; }
        public int ImageWidth { get; set; }

    }
}
