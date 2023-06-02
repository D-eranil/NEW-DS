using DSWEBSITE_K13.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DSWEBSITE_K13.Components.ViewComponents
{
    public class BlogDetailsModel
    {
        public BlogBannerViewModel BlogBanner { get; set; }
        public BlogDetailsViewModel LatestBlog { get; set; }
        public List<BlogDetailsViewModel> Blogs { get; set; }
    }
}
