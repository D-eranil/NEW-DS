using CMS.DocumentEngine.Types.DotStarK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DSWEBSITE_K13.Models.ViewModels
{
    public class TechnologiesViewModel
    {
        public string TechnologyName { get; set; }
        public string TechnologyImage { get; set; }
        public string ImageAltText { get; set; }
        public string TechnologyDescription { get; set; }
        public bool IsActive { get; set; }

        public List<TechnologyDetailViewModel> TechnologyDetails { get; set; }

        public static TechnologiesViewModel GetModel(Technologies technologiesSection)
        {
            var data = technologiesSection == null ? null : new TechnologiesViewModel()
            {
                TechnologyName = technologiesSection.Fields.TechnologyName,
                ImageAltText = technologiesSection.Fields.ImageAltText,
                TechnologyImage = technologiesSection.Fields.TechnologyImage,
                IsActive = technologiesSection.Fields.IsActive,
                TechnologyDescription = technologiesSection.Fields.TechnologyDescription,
                TechnologyDetails = new List<TechnologyDetailViewModel>()
            };

            return data;
        }

    }
}
