using CMS.DocumentEngine.Types.DotStarK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DSWEBSITE_K13.Models.ViewModels
{
    public class TechnologyViewModel
    {

        public string Heading { get; set; }
        public string SubHeading { get; set; }
        public string ContentText { get; set; }
        public string BannerImage { get; set; }
        public string ImageAltText { get; set; }
        public string Title { get; set; }
        public bool IsActive { get; set; }

        //public List<TechnologiesViewModel> Technologies { get; set; }

        public static TechnologyViewModel GetModel(Technology technologySection)
        {
            var data = technologySection == null ? null : new TechnologyViewModel()
            {

                Heading = technologySection.Fields.Heading,
                SubHeading = technologySection.Fields.SubHeading,
                BannerImage = technologySection.Fields.BannerImage,
                Title = technologySection.Fields.Title,
                ContentText = technologySection.Fields.ContentText,
                ImageAltText = technologySection.Fields.ImageAltText,
                IsActive = technologySection.Fields.IsActive,

            };

            return data;
        }

    }
}
