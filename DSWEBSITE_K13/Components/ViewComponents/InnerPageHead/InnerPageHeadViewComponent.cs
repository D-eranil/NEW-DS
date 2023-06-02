using CMS.DocumentEngine;
using DSWEBSITE_K13.Repositories.Repository;
using Microsoft.AspNetCore.Mvc;

namespace DSWEBSITE_K13.Components.ViewComponents
{
    public class InnerPageHeadViewComponent : ViewComponent
    {
        private readonly PageHeadRepository pageHeadRepository;
        
        public InnerPageHeadViewComponent(PageHeadRepository _pageHeadRepository)
        {
            pageHeadRepository = _pageHeadRepository;
        }
        public IViewComponentResult Invoke(TreeNode page)
        {
            var pageModel = pageHeadRepository.GetInnerPageHead(page.ClassName, page.NodeAliasPath);

            return View("/Components/ViewComponents/InnerPageHead/InnerPageHead.cshtml", pageModel);
        }
    }
}