using CMS.DocumentEngine.Types.DotStarK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DSWEBSITE_K13.Models.ViewModels
{
    public class BlogBannerViewModel
    {
        public string Name { get; set; }
        public string Heading { get; set; }
        public string SubHeading { get; set; }
        public string BannerImage { get; set; }
        public string BannerImageAltText { get; set; }
        public bool IsActive { get; set; }

        public static BlogBannerViewModel GetModel(BlogBanner blogBannerSection)
        {
            var data = blogBannerSection == null ? null : new BlogBannerViewModel()
            {
                Name = blogBannerSection.Fields.Name,
                Heading = blogBannerSection.Fields.Heading,
                SubHeading = blogBannerSection.Fields.SubHeading,
                BannerImage = blogBannerSection.Fields.BannerImage,
                BannerImageAltText = blogBannerSection.Fields.BannerImageAltText,
                IsActive = blogBannerSection.Fields.IsActive,
            };

            return data;
        }
    }
}
