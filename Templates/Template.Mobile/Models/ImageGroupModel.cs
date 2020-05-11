using System;
using System.Collections.Generic;
using System.Text;

namespace Template.Mobile.Models
{
    public class ImageGroupModel : List<ImageModel>
    {
        public string GroupName { get; private set; }

        public ImageGroupModel(string groupname, List<ImageModel> images) : base(images)
        {
            GroupName = groupname;
        }
    }
}
