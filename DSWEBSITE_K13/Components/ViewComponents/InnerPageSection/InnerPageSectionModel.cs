using CMS.DocumentEngine.Types.DotStarK;
using System.Collections.Generic;
using DSWEBSITE_K13.Libraries.Infrastructure;
using DSWEBSITE_K13.Libraries.Infrastructure.Provider;
using DSWEBSITE_K13.Models.ViewModels;

namespace DSWEBSITE_K13.Components.ViewComponents
{
    public class InnerPageSectionModel
    {
        public string DivSectionId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public bool IsH3Section { get; set; }
        public string Image { get; set; }
        public string ThemesColor { get; set; }
        public bool IsCategoryBreadcrumbs { get; set; }
        public List<ActivitiesModel> Activities { get; set; }
        public List<LinkItemViewModel> Industries { get; set; }
        public List<StrengthViewModel> Strengths { get; set; }

        public static InnerPageSectionModel GetModel(InnerPageSection innerSection)
        {
            var data = innerSection == null ? null : new InnerPageSectionModel()
            {
                Description = innerSection.Fields.Description,
                Image = innerSection.Fields.Image,
                IsCategoryBreadcrumbs = innerSection.Fields.IsCategoryBreadcrumbs,
                IsH3Section = innerSection.Fields.IsH3Section,
                ThemesColor = innerSection.Fields.ThemesColor,
                Title = innerSection.Fields.Title,
                DivSectionId = CommonHelper.GetDashedCodeWithClassName(innerSection.DocumentName, innerSection.NodeClassName)
            };

            return data;
        }
    }
}
