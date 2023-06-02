using CMS.DocumentEngine.Types.DotStarK;
using DSWEBSITE_K13.Libraries.Infrastructure.Provider;

namespace DSWEBSITE_K13.Components.ViewComponents
{
    /// <summary>
    /// Get all service section details
    /// </summary>
    public class ServiceSectionModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        public string SectionDivId { get; set; }
        public bool IsCategoryBreadcrumbs { get; set; }

        public static ServiceSectionModel GetModel(ServiceSection serviceSection)
        {
            var data = serviceSection == null ? null : new ServiceSectionModel()
            {
                Name = serviceSection.Fields.Name,
                Description = serviceSection.Fields.Description,
                Image = serviceSection.Fields.Image,
                IsCategoryBreadcrumbs = serviceSection.Fields.IsCategoryBreadcrumbs,
                SectionDivId = CommonHelper.GetDashedCodeWithClassName(serviceSection.Fields.Name,serviceSection.ClassName)
            };

            return data;
        }
    }
}
