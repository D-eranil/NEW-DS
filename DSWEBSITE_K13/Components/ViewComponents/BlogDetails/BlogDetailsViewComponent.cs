using CMS.DocumentEngine;
using CMS.DocumentEngine.Types.DotStarK;
using CMS.Helpers;
using DSWEBSITE_K13.Models.ViewModels;
using DSWEBSITE_K13.Repositories.Repository;
using Kentico.Content.Web.Mvc;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DSWEBSITE_K13.Components.ViewComponents
{
    public class BlogDetailsViewComponent : ViewComponent
    {
        private readonly IPageRetriever pageRetriever;
        private readonly BlogRepository blogRepository;

        public BlogDetailsViewComponent(IPageRetriever _pageRetriever, BlogRepository _blogRepository)
        {
            pageRetriever = _pageRetriever;
            blogRepository = _blogRepository;
        }


        public IViewComponentResult Invoke(TreeNode page)
        {
            // Initializaton of InnerPageHead instance
            BlogDetailsModel blogDetails = new BlogDetailsModel();

            // Get inner page head detail from tree node
            if (page.ClassName == Blogs.CLASS_NAME)
            {

                blogDetails = blogRepository.GetSelectedBlog(page.NodeAliasPath);
            }

            return View("/Components/ViewComponents/BlogDetails/BlogDetails.cshtml", blogDetails);

        }
    }
}
