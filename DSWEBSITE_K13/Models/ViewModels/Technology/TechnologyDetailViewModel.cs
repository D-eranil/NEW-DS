using CMS.DocumentEngine.Types.DotStarK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DSWEBSITE_K13.Models.ViewModels
{
    public class TechnologyDetailViewModel
    {

        public string TechnologyTitle { get; set; }
        public string TechnologyName { get; set; }
        public string BackgroundImage { get; set; }
        public string BackgroundImageAltText { get; set; }
        public string TechnologyLogo { get; set; }
        public string ContentText { get; set; }
        public bool IsActive { get; set; }

        public static TechnologyDetailViewModel GetModel(TechnologyDetails technologySection)
        {
            var data = technologySection == null ? null : new TechnologyDetailViewModel()
            {

                TechnologyTitle = technologySection.Fields.TechnologyTitle,
                TechnologyName = technologySection.Fields.TechnologyName,
                BackgroundImage = technologySection.Fields.BackgroundImage,
                BackgroundImageAltText = technologySection.Fields.BackgroundImageAltText,
                TechnologyLogo = technologySection.Fields.TechnologyLogo,
                ContentText = technologySection.Fields.ContentText,
                IsActive = technologySection.Fields.IsActive,

            };

            return data;
        }

    }
}
