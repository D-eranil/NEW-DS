using CMS.DocumentEngine.Types.DotStarK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DSWEBSITE_K13.Models.ViewModels
{
    public class LatestBlogViewModel
    {
        public int NodeId { get; set; }
        public string NodeAliasPath { get; set; }
        public string Heading { get; set; }
        public string BlogImage { get; set; }
        public string BlogImageAltText { get; set; }
        public string BlogAuthor { get; set; }
        public string Topic { get; set; }
        public DateTime? BlogCreatedDate { get; set; }
        public string DisplayDate { get; set; }
        public string BlogShortTitle { get; set; }
        public string BlogTitle { get; set; }
        public string BlogContentText { get; set; }
        public bool IsActive { get; set; }
        public string BlogBannerImage { get; set; }
        public string BannerImageAltText { get; set; }

        public static LatestBlogViewModel GetModel(Blogs latestBlogSection)
        {
            var data = latestBlogSection == null ? null : new LatestBlogViewModel()
            {
                Heading = latestBlogSection.Fields.BlogHeading,
                BlogImage = latestBlogSection.Fields.BlogDetailImage,
                BlogImageAltText = latestBlogSection.Fields.BlogDetailImageAltText,
                BlogShortTitle = latestBlogSection.Fields.ShortTitle,
                BlogTitle = latestBlogSection.Fields.BlogTitle,
                BlogContentText = latestBlogSection.Fields.BlogContentText,
                BlogAuthor = latestBlogSection.Fields.BlogAuthor,
                BlogCreatedDate = latestBlogSection.Fields.BlogCreatedDate,
                Topic = latestBlogSection.Fields.BlogTopic,
                IsActive = latestBlogSection.Fields.IsActive,
                DisplayDate = latestBlogSection.Fields.BlogCreatedDate.ToString("MMM dd, yyyy"),
                BlogBannerImage = latestBlogSection.Fields.BlogBannerImage,
                BannerImageAltText = latestBlogSection.Fields.BlogBannerImageAltText,
                NodeAliasPath = latestBlogSection.NodeAliasPath
            };

            return data;
        }
    }

}
