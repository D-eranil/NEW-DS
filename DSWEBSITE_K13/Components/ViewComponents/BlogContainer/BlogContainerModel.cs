using CMS.DocumentEngine.Types.DotStarK;
using DSWEBSITE_K13.Libraries.Infrastructure.Provider;
using DSWEBSITE_K13.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DSWEBSITE_K13.Components.ViewComponents
{
    public class BlogContainerModel
    {
        public BlogControlsViewModel Controls { get; set; }
        public List<BlogViewModel> Blogs { get; set; }
    }
}
