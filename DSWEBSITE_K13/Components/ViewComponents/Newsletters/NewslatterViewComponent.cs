using CMS.DocumentEngine;
using CMS.DocumentEngine.Types.DotStarK;
using DSWEBSITE_K13.Repositories.Repository;
using Kentico.Content.Web.Mvc;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;

namespace DSWEBSITE_K13.Components.ViewComponents
{
    public class NewslatterViewComponent : ViewComponent
    {
        private readonly NewslatterRepository newslatterRepository;

        public NewslatterViewComponent(NewslatterRepository _newslatterRepository)
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
                   newslatterModel= newslatterRepository.GetNewslatter(page.NodeAliasPath);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return View("/Components/ViewComponents/Newslatters/Newslatter.cshtml", newslatterModel);

        }
    }
}
