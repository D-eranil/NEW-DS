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

    public class InnerPageSectionViewComponent : ViewComponent
    {
        private readonly InnerPageSectionRepository innerPageSectionRepository;

        public InnerPageSectionViewComponent(InnerPageSectionRepository _innerPageSectionRepository)
        {
            innerPageSectionRepository = _innerPageSectionRepository;
        }

        public IViewComponentResult Invoke(TreeNode page)
        {
            // Initializaton of InnerPageHead instance
            InnerPageSectionModel innerPageSectionModel = new InnerPageSectionModel();

            // Get inner page head detail from tree node
            if (page.ClassName == InnerPageSection.CLASS_NAME)
            {
                //Root
                innerPageSectionModel = innerPageSectionRepository
                                        .GetInnerPageSection(page.NodeAliasPath);
            }

            return View("/Components/ViewComponents/InnerPageSection/InnerPageSection.cshtml", innerPageSectionModel);
        }
    }
}
