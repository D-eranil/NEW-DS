using CMS.Core;
using CMS.DocumentEngine;
using DSWEBSITE_K13.Repositories.Repository;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DSWEBSITE_K13.Components.ViewComponents
{
    public class TopSectionViewComponent : ViewComponent
    {
        private readonly TopSectionRepository topSectionRepository;

        public TopSectionViewComponent(TopSectionRepository _topSectionRepository)
        {
            topSectionRepository = _topSectionRepository;
        }
        public IViewComponentResult Invoke(TreeNode page)
        {
            TopSectionModel pageModel = new TopSectionModel();
            try
            {
                pageModel = topSectionRepository.GetTopSection(page.NodeAliasPath, page.ClassName);
            }
            catch (Exception ex)
            {
                Service.Resolve<IEventLogService>().LogException("TopSectionViewComponent", "Invoke", ex);
            }
            return View("/Components/ViewComponents/TopSection/TopSection.cshtml", pageModel);
        }
    }
}
