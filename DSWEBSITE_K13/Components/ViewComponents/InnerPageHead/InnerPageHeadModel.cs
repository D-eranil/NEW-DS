using CMS.DocumentEngine.Types.DotStarK;
using System.Collections.Generic;

namespace DSWEBSITE_K13.Components.ViewComponents
{
    public class InnerPageHeadModel
    {

        public string BannerImage { get; set; }
        public string BannerTitle { get; set; }
        public string SubTitle { get; set; }
        public List<BreadcrumbModel> LstBreadcrumb { get; set; }

        public static InnerPageHeadModel GetModel(InnerPageHead innerPageHead)
        {
            var data = innerPageHead == null ? null : new InnerPageHeadModel()
            {
                BannerImage = innerPageHead.Fields.BannerImage,
                BannerTitle = innerPageHead.Fields.BannerTitle,
                SubTitle = innerPageHead.Fields.SubTitle
            };

            if (innerPageHead.NodeParentID > 0)
            {
               
            }

            return data;
        }
    }

    public class BreadcrumbModel
    {
        public string ItemName { get; set; }
        public string ItemUrl { get; set; }

    }
}
