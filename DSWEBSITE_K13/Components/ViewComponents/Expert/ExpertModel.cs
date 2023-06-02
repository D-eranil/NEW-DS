using CMS.DocumentEngine;
using CMS.DocumentEngine.Types.DotStarK;
using DSWEBSITE_K13.Libraries.Infrastructure.Provider;

namespace DSWEBSITE_K13.Components.ViewComponents
{
    public class ExpertModel
    {
        public string Name { get; set; }
        public string ShortDescription { get; set; }
        public string Points { get; set; }
        public string Image { get; set; }
        public string ImageAltText { get; set; }
        public string CTAButtonText { get; set; }
        public bool IsCategoryBreadcrumbs { get; set; }
        public string ExpertiesRedirectPath { get; set; }
        public string CardImageAltText { get; set; }
        public string CardImage { get; set; }
        public int NodeOrder { get; set; }
        public bool IsStartexperties { get; set; }
        public string ThemesColor { get; set; }

        public string sectionDivId { get; set; }

        private static ExpertModel GetExpertModel(Expert expert) {

            var data = expert == null ? null : new ExpertModel()
            {
                Name = expert.Fields.Name,
                ShortDescription = expert.Fields.ShortDescription,
                Points = expert.Fields.Points,
                IsCategoryBreadcrumbs = expert.Fields.IsCategoryBreadcrumbs,
                ThemesColor = expert.Fields.ThemesColor
            };

            return data;
        }

        public static ExpertModel GetHomeModel(TreeNode tree)
        {
            var expert = tree as Expert;
            var data = GetExpertModel(expert);
            data.ImageAltText = expert.Fields.ImageAltText;
            data.CTAButtonText = expert.Fields.CTAButtonText;
            data.ExpertiesRedirectPath = "/expertise#" + CommonHelper.GetDashedCodeWithClassName(expert.Name, expert.NodeClassName);
            data.CardImage = expert.Fields.CardImage;
            data.CardImageAltText = expert.Fields.CardImageAltText;
            return data;
        }

        public static ExpertModel GetExperties(TreeNode tree)
        {
            var expert = tree as Expert;

            var data = GetExpertModel(expert);
            data.sectionDivId = CommonHelper.GetDashedCodeWithClassName(expert.Name, expert.NodeClassName);
            data.Image = expert.Fields.Image;
            data.NodeOrder = expert.NodeOrder;
            data.IsStartexperties = (expert.NodeOrder % 2) == 0;

            return data;
        }
    }
}
