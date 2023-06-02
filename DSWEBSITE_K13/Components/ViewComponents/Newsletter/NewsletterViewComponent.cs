using CMS.Core;
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
    public class NewsletterViewComponent:ViewComponent
    {
        private readonly NewslatterRepository newslatterRepository;

        public NewsletterViewComponent(NewslatterRepository _newslatterRepository)
        {
            newslatterRepository = _newslatterRepository;
        }
        public IViewComponentResult Invoke(TreeNode page)
        {
            var newslatterModel = new NewsletterModel();
            try
            {
                // Get inner page head detail from tree node
                if (page.ClassName == Newsletter.CLASS_NAME)
                {
                    newslatterModel = newslatterRepository.GetNewslatter(page.NodeAliasPath);
                }
            }
            catch (Exception ex)
            {
                //throw ex;
                Service.Resolve<IEventLogService>().LogException("HeaderViewComponent", "Invoke", ex);
            }
            return View("/Components/ViewComponents/Newsletter/Newsletter.cshtml", newslatterModel);

        }
    }
}
