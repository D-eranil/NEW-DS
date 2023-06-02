using CMS.DocumentEngine.Types.DotStarK;
using DSWEBSITE_K13.Libraries.Infrastructure.Provider;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DSWEBSITE_K13.Components.ViewComponents
{
    public class CareerValuesSectionModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        public string SectionDivId { get; set; }
        public bool IsCategoryBreadcrumbs { get; set; }

        public static CareerValuesSectionModel GetModel(CareerValuesSection careerValuesSection)
        {
            var data = careerValuesSection == null ? null : new CareerValuesSectionModel()
            {
                Name = careerValuesSection.Fields.Name,
                Description = careerValuesSection.Fields.Description,
                Image = careerValuesSection.Fields.Image,
                IsCategoryBreadcrumbs = careerValuesSection.Fields.IsCategoryBreadcrumbs,
                SectionDivId = CommonHelper.GetDashedCodeWithClassName(careerValuesSection.Fields.Name, careerValuesSection.ClassName)
            };

            return data;
        }
    }
}
