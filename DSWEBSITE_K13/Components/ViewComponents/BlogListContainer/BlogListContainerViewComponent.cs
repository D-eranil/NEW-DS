using CMS.DocumentEngine;
using CMS.DocumentEngine.Types.DotStarK;
using CMS.Helpers;
using DSWEBSITE_K13.Models.ViewModels;
using DSWEBSITE_K13.Repositories.Repository;
using Kentico.Content.Web.Mvc;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace DSWEBSITE_K13.Components.ViewComponents
{
    public class BlogListContainerViewComponent : ViewComponent
    {
        private readonly IPageRetriever pageRetriever;
        private readonly BlogRepository blogRepository;

        public BlogListContainerViewComponent(IPageRetriever _pageRetriever, BlogRepository _blogRepository)
        {
            pageRetriever = _pageRetriever;
            blogRepository = _blogRepository;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="page"></param>
        /// <returns></returns>
        public IViewComponentResult Invoke(TreeNode page)
        {

            //key value
            string category = ValidationHelper.GetString(HttpContext.Request.Query["category"], "");
            string tag = ValidationHelper.GetString(HttpContext.Request.Query["tag"], "");

            //list
            var blogListContainer = new BlogListContainerModel();
            // Get inner page head detail from tree node
            if (page.ClassName == BlogListContainer.CLASS_NAME)
            {
                blogListContainer = blogRepository.GetBlogList(category, tag);
            }
            return View("/Components/ViewComponents/BlogListContainer/BlogListContainer.cshtml", blogListContainer);

        }
    }
}
