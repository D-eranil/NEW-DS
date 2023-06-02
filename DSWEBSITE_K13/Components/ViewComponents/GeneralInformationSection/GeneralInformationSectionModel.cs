using CMS.DocumentEngine.Types.DotStarK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DSWEBSITE_K13.Components.ViewComponents
{
    public class GeneralInformationSectionModel
    {
        public string Description { get; set; }

        public static GeneralInformationSectionModel GetModel(GeneralInformationSection generalInformationSection)
        {
            var data = generalInformationSection == null ? null : new GeneralInformationSectionModel()
            {
                Description = generalInformationSection.Fields.Description
            };

            if (generalInformationSection.NodeParentID > 0)
            {

            }

            return data;
        }
    }
}
