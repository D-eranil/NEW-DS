using CMS.DocumentEngine.Types.DotStarK;
using DSWEBSITE_K13.Libraries.Infrastructure.Provider;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DSWEBSITE_K13.Components.ViewComponents
{
    public class CareerCurrentOpeningModel
    {
        public string Title { get; set; }

        public string Description { get; set; }
        public string sectionDivId { get; set; }
        public static CareerCurrentOpeningModel GetModel(CareerCurrentOpening generalInformationSection)
        {
            var data = generalInformationSection == null ? null : new CareerCurrentOpeningModel()
            {
                Title = generalInformationSection.Fields.Title,
                Description = generalInformationSection.Fields.Description,
                sectionDivId = CommonHelper.GetDashedCodeWithClassName(generalInformationSection.Fields.Title, generalInformationSection.ClassName)
            };

            if (generalInformationSection.NodeParentID > 0)
            {

            }

            return data;
        }
    }
}
