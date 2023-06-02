using CMS.DocumentEngine.Types.DotStarK;
using DSWEBSITE_K13.Libraries.Infrastructure.Provider;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DSWEBSITE_K13.Components.ViewComponents
{
    public class CareerSectionModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        public string ImageLocation { get; set; }
        public string DescriptionLocation { get; set; }
        public string SectionDivId { get; set; }
        public bool IsCategoryBreadcrumbs { get; set; }

        public static CareerSectionModel GetModel(CareerSection careerSection)
        {
            var data = careerSection == null ? null : new CareerSectionModel()
            {
                Name = careerSection.Fields.Name,
                Description = careerSection.Fields.Description,
                Image = careerSection.Fields.Image,
                ImageLocation = (careerSection.Fields.ImageLocation == "Left") ? "start" : "end",
                DescriptionLocation = (careerSection.Fields.ImageLocation == "Left") ? "end" : "start",
                IsCategoryBreadcrumbs = careerSection.Fields.IsCategoryBreadcrumbs,
                SectionDivId = CommonHelper.GetDashedCodeWithClassName(careerSection.Fields.Name, careerSection.ClassName)
            };

            return data;
        }
    }
}
