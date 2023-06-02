using CMS.DocumentEngine.Types.DotStarK;
using DSWEBSITE_K13.Libraries.Infrastructure.Provider;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DSWEBSITE_K13.Components.ViewComponents
{
    public class TileModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        public string SectionDivId { get; set; }
        public bool IsCategoryBreadcrumbs { get; set; }

        public static TileModel GetModel(ServiceSection serviceSection)
        {
            var data = serviceSection == null ? null : new TileModel()
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
