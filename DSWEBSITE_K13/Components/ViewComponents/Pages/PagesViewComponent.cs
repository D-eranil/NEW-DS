using CMS.DocumentEngine;
using CMS.DocumentEngine.Types.DotStarK;
using Kentico.Content.Web.Mvc;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace DSWEBSITE_K13.Components.ViewComponents
{
    public class PagesViewComponent : ViewComponent
    {
        private readonly IPageRetriever pageRetriever;

        public PagesViewComponent(IPageRetriever _pageRetriever)
        {
            pageRetriever = _pageRetriever;
        }

        public IViewComponentResult Invoke(TreeNode page)
        {
            // Aggregate ItemAccordionPanels
            PageHead pageHead = new PageHead();

            // Get page head detail from children
            if (page.ClassName == PageHead.CLASS_NAME)
            {
                pageHead = pageRetriever.Retrieve<PageHead>(
                query => query
                    .Columns(
                        "Title"
                    )
                    .Path(page.NodeAliasPath, PathTypeEnum.Single)
                    .NestingLevel(1).FirstOrDefault(),

                cache => cache
                    .Key($"{nameof(PageHeadViewComponent)}|{nameof(Invoke)}|{page.NodeAliasPath}")
                    .Dependencies((_, builder) => builder.PagePath(page.NodeAliasPath, PathTypeEnum.Children))
            ).FirstOrDefault();

            }

            var pageHeadModel = new PageHeadModel()
            {
                PageName = pageHead != null ? pageHead.Fields.Title : ""
            };

            return View("/Components/ViewComponents/PageHead/PageHead.cshtml", pageHeadModel);
        }
    }
}
