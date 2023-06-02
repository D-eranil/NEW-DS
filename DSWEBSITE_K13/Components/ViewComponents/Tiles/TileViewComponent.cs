using CMS.DocumentEngine;
using CMS.DocumentEngine.Types.DotStarK;
using Kentico.Content.Web.Mvc;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace DSWEBSITE_K13.Components.ViewComponents
{
    public class TileViewComponent : ViewComponent
    {
        private readonly IPageRetriever pageRetriever;

        public TileViewComponent(IPageRetriever _pageRetriever)
        {
            pageRetriever = _pageRetriever;
        }
        public IViewComponentResult Invoke(TreeNode page)
        {
            // Initializaton of InnerPageHead instance
            ServiceSection serviceSection = new ServiceSection();

            // Get inner page head detail from tree node
            if (page.ClassName == ServiceSection.CLASS_NAME)
            {
                serviceSection = pageRetriever.Retrieve<ServiceSection>(
                query => query
                    .Columns(
                        "Name", "Description", "Image", "IsCategoryBreadcrumbs"
                    )
                    .Path(page.NodeAliasPath, PathTypeEnum.Single)
                    .NestingLevel(1).FirstOrDefault(),
                cache => cache
                    .Key($"{nameof(ServiceSectionViewComponent)}|{nameof(Invoke)}|{page.NodeAliasPath}")
                    .Dependencies((_, builder) => builder.PagePath(page.NodeAliasPath, PathTypeEnum.Single))
            ).FirstOrDefault();

            }

            var serviceSectionModel = ServiceSectionModel.GetModel(serviceSection);

            return View("/Components/ViewComponents/ServiceSection/ServiceSection.cshtml", serviceSectionModel);

        }
    }
}
