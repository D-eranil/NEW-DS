using DSWEBSITE_K13.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DSWEBSITE_K13.Components.ViewComponents
{
    public class BlogListContainerModel
    {
        //public BlogBannerViewModel BlogBanner { get; set; }
        public BlogControlsViewModel Controls { get; set; }
        public LatestBlogViewModel LatestBlog { get; set; }
        public List<BlogListViewModel> Blogs { get; set; }
        public string Message { get; set; }
        public bool IsTagSearch { get; set; }
        public bool IsCategorySearch { get; set; }
    }
}
