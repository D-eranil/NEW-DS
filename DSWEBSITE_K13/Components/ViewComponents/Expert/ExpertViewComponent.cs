using CMS.DocumentEngine;
using CMS.DocumentEngine.Types.DotStarK;
using DSWEBSITE_K13.Repositories.Repository;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DSWEBSITE_K13.Components.ViewComponents
{
    public class ExpertViewComponent : ViewComponent
    {
        private readonly ExpertRepository expertRepository;

        public ExpertViewComponent(ExpertRepository _expertRepository)
        {
            expertRepository = _expertRepository;
        }

        public IViewComponentResult Invoke(TreeNode page)
        {
            // Initializaton of InnerPageHead instance
            ExpertModel expertContainerModel = new ExpertModel();

            // Get inner page head detail from tree node
            if (page.ClassName == Expert.CLASS_NAME)
            {
                expertContainerModel = expertRepository.GetExperties(page.ClassName, page.NodeAliasPath);
            }

            return View("/Components/ViewComponents/Expert/Expert.cshtml", expertContainerModel);
        }
    }
}
