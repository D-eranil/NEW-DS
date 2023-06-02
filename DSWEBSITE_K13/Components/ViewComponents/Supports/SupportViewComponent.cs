using CMS.DocumentEngine;
using CMS.DocumentEngine.Types.DotStarK;
using DSWEBSITE_K13.Models.ViewModels;
using DSWEBSITE_K13.Repositories.Repository;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace DSWEBSITE_K13.Components.ViewComponents
{
    public class SupportViewComponent : ViewComponent
    {

        private readonly SupportRepository supportRepository;

        public SupportViewComponent(SupportRepository _supportRepository)
        {
            supportRepository = _supportRepository;
        }

        public IViewComponentResult Invoke(TreeNode page)
        {
            // Initializaton of InnerPageHead instance
            SupportViewModel supportModel = new SupportViewModel();

            // Get inner page head detail from tree node
            if (page.ClassName == Support.CLASS_NAME)
            {
                supportModel =  supportRepository.GetSupportList(page.ClassName, page.NodeAliasPath);

            }

            return View("/Components/ViewComponents/Supports/Support.cshtml", supportModel);
        }
    }
}
