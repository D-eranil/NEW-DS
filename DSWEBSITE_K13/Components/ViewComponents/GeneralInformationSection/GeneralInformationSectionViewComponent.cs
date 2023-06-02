using CMS.DocumentEngine;
using DSWEBSITE_K13.Repositories.Repository;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DSWEBSITE_K13.Components.ViewComponents
{
    public class GeneralInformationSectionViewComponent : ViewComponent
    {
        private readonly PageHeadRepository pageHeadRepository;

        public GeneralInformationSectionViewComponent(PageHeadRepository _pageHeadRepository)
        {
            pageHeadRepository = _pageHeadRepository;
        }
        public IViewComponentResult Invoke(TreeNode page)
        {
            var pageModel = pageHeadRepository.GetPageGeneralInformationSectionData(page.ClassName, page.NodeAliasPath);

            return View("/Components/ViewComponents/GeneralInformationSection/GeneralInformationSection.cshtml", pageModel);
        }
    }
}
