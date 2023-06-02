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
    public class BlogBannerViewComponent : ViewComponent
    {
        private readonly IPageRetriever pageRetriever;
        private readonly BlogRepository blogRepository;

        public BlogBannerViewComponent(IPageRetriever _pageRetriever, BlogRepository _blogRepository)
        {
            pageRetriever = _pageRetriever;
            blogRepository = _blogRepository;
        }
        public IViewComponentResult Invoke(TreeNode page)
        {
            //banner
            var blogBanner = new BlogBannerViewModel();

            // Get inner page head detail from tree node
            if (page.ClassName == BlogBanner.CLASS_NAME)
            {
                //bind blog banner
                var _blogBanner = blogRepository.GetBlogBanner();
                if (_blogBanner != null)
                    blogBanner = _blogBanner;
            }
            return View("/Components/ViewComponents/BlogBanner/BlogBanner.cshtml", blogBanner);

        }
    }
}
