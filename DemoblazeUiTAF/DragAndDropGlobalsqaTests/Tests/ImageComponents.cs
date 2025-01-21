using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoblazeUiTAF.DragAndDropGlobalsqaTests.Tests
{
    internal class ImageComponents
    {
        public string Title { get; set; }
        public string Image { get; set; }
        public string TrashIcon { get; set; }
        public string ZoomIcon { get; set; }

        public ImageComponents(string title, string image, string trashIcon, string zoomIcon)
        {
            Title = title;
            Image = image;
            TrashIcon = trashIcon;
            ZoomIcon = zoomIcon;
        }
        

        
    }
}
