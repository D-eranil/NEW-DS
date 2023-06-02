using CMS.DocumentEngine;
using CMS.DocumentEngine.Types.DotStarK;
using DSWEBSITE_K13.Repositories.Repository;
using Microsoft.AspNetCore.Mvc;

namespace DSWEBSITE_K13.Components.ViewComponents
{
    public class ExpertContainerViewComponent : ViewComponent
    {

        private readonly ExpertRepository expertRepository;

        public ExpertContainerViewComponent(ExpertRepository _expertRepository)
        {
            expertRepository = _expertRepository;
        }

        public IViewComponentResult Invoke(TreeNode page)
        {
            // Initializaton of InnerPageHead instance
            ExpertContainerModel expertContainerModel = new ExpertContainerModel();

            // Get inner page head detail from tree node
            if (page.ClassName == ExpertContainer.CLASS_NAME)
            {
                expertContainerModel = expertRepository.GetHomePageExperties(page.ClassName, page.NodeAliasPath);
            }

            return View("/Components/ViewComponents/ExpertContainer/ExpertContainer.cshtml", expertContainerModel);
        }
    }
}
