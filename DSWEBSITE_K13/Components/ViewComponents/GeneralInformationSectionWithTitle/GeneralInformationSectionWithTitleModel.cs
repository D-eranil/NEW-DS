using CMS.DocumentEngine.Types.DotStarK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DSWEBSITE_K13.Components.ViewComponents
{
    public class GeneralInformationSectionWithTitleModel
    {
        public string Title { get; set; }

        public string Description { get; set; }
        public static GeneralInformationSectionWithTitleModel GetModel(GeneralInformationSectionWithTitle generalInformationSection)
        {
            var data = generalInformationSection == null ? null : new GeneralInformationSectionWithTitleModel()
            {
                Title = generalInformationSection.Fields.Title,
                Description = generalInformationSection.Fields.Description
            };

            if (generalInformationSection.NodeParentID > 0)
            {

            }

            return data;
        }
    }
}
