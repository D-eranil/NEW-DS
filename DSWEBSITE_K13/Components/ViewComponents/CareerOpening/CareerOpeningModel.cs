using CMS.DocumentEngine;
using CMS.DocumentEngine.Types.DotStarK;
using DSWEBSITE_K13.Libraries.Infrastructure.Provider;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DSWEBSITE_K13.Components.ViewComponents
{
    public class CareerOpeningModel
    {
        public string OpeningTitle { get; set; }
        public string Location { get; set; }
        public bool RemoteWork { get; set; }
        public int NoOfVaccancies { get; set; }
        public string Description { get; set; }
        public string sectionDivId { get; set; }

        private static CareerOpeningModel GetCareerOpeningModel(CareerOpening careerOpening)
        {

            var data = careerOpening == null ? null : new CareerOpeningModel()
            {
                OpeningTitle = careerOpening.Fields.OpeningTitle,
                Location = careerOpening.Fields.Location,
                RemoteWork = careerOpening.Fields.RemoteWork,
                NoOfVaccancies = careerOpening.Fields.NoOfVaccancies,
                Description = careerOpening.Fields.Description,
                sectionDivId = CommonHelper.GetDashedCodeWithClassName(careerOpening.Fields.Name, careerOpening.ClassName)
            };

            return data;
        }

        public static CareerOpeningModel GetCareerOpenings(TreeNode tree)
        {
            var careerOpening = tree as CareerOpening;

            var data = GetCareerOpeningModel(careerOpening);
            data.sectionDivId = CommonHelper.GetDashedCodeWithClassName(careerOpening.Name, careerOpening.NodeClassName);
            return data;
        }
    }
}
