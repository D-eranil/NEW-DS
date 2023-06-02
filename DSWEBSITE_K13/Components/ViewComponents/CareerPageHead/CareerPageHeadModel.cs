using CMS.DocumentEngine.Types.DotStarK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DSWEBSITE_K13.Components.ViewComponents
{
    public class CareerPageHeadModel
    {
        public string BannerImage { get; set; }
        public string BannerTitle { get; set; }
        public string SubTitle { get; set; }
        public bool FormEnabled { get; set; }
        public string FormTitle { get; set; }
        public string ShortDescription { get; set; }
        public List<CareerOpeningModel> CurrentOpenings { get; set; }
        public List<BreadcrumbModel> LstBreadcrumb { get; set; }

        public static CareerPageHeadModel GetModel(CareerPageHead careerPageHead)
        {
            var data = careerPageHead == null ? null : new CareerPageHeadModel()
            {
                BannerImage = careerPageHead.Fields.BannerImage,
                BannerTitle = careerPageHead.Fields.BannerTitle,
                SubTitle = careerPageHead.Fields.SubTitle,
                FormEnabled = careerPageHead.Fields.FormEnabled,
                FormTitle = careerPageHead.Fields.FormTitle,
                ShortDescription = careerPageHead.Fields.ShortDescription
            };

            if (careerPageHead.NodeParentID > 0)
            {

            }

            return data;
        }
    }
}
