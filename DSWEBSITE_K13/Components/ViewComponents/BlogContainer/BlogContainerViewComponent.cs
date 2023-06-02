using CMS.DocumentEngine;
using CMS.DocumentEngine.Types.DotStarK;
using DSWEBSITE_K13.Models.ViewModels;
using DSWEBSITE_K13.Repositories.Repository;
using Kentico.Content.Web.Mvc;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace DSWEBSITE_K13.Components.ViewComponents
{
    public class BlogContainerViewComponent : ViewComponent
    {
        private readonly IPageRetriever pageRetriever;
        private readonly BlogRepository blogRepository;

        public BlogContainerViewComponent(IPageRetriever _pageRetriever, BlogRepository _blogRepository)
        {
            pageRetriever = _pageRetriever;
            blogRepository = _blogRepository;
        }
        public IViewComponentResult Invoke(TreeNode page)
        {
            // Initializaton of InnerPageHead instance
            BlogContainerModel blogSection = new BlogContainerModel();

            // Get inner page head detail from tree node
            if (page.ClassName == BlogContainer.CLASS_NAME)
            {
                blogSection = blogRepository.GetHomePageBlogs();
            }


            return View("/Components/ViewComponents/BlogContainer/BlogContainer.cshtml", blogSection);

        }
    }
}
