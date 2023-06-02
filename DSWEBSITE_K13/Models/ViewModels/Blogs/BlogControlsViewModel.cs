using CMS.DocumentEngine.Types.DotStarK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DSWEBSITE_K13.Models.ViewModels
{
    public class BlogControlsViewModel
    {
        public string Name { get; set; }
        public string Heading { get; set; }
        public string SliderButtonID { get; set; }
        public string SliderButtonText { get; set; }
        public string ButtonID { get; set; }
        public string ButtonText { get; set; }
        public string ListingButtonID { get; set; }
        public string ListingButtonText { get; set; }

        public static BlogControlsViewModel GetControlHeading(BlogContainer container)
        {
            return container != null ? new BlogControlsViewModel()
            {
                Name = container.Fields.Name,
                Heading = container.Fields.Heading,
                SliderButtonID = container.Fields.SliderButtonID,
                SliderButtonText = container.Fields.SliderButtonText,
                ButtonID = container.Fields.ButtonID,
                ButtonText = container.Fields.ButtonText,
                ListingButtonID = container.Fields.ListingButtonID,
                ListingButtonText = container.Fields.ListingButtonText,

            } : new BlogControlsViewModel();
        }
    }
}

