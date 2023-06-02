using CMS.DocumentEngine.Types.DotStarK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DSWEBSITE_K13.Models.ViewModels
{
    public class BlogListViewModel
    {
        public int NodeID { get; set; }
        public string NodeAliasPath { get; set; }
        public int BlogsID { get; set; }
        public string Name { get; set; }
        public string Heading { get; set; }
        public string BlogTitle { get; set; }
        public string ThumbnailImage { get; set; }
        public string BlogURL { get; set; }
        public string ThumbnailImageAltText { get; set; }
        public string BlogAuthor { get; set; }
        public string Topic { get; set; }
        public DateTime? BlogCreatedDate { get; set; }
        public string DisplayDate { get; set; }
        public string BlogShortTitle { get; set; }
        public string BlogContentText { get; set; }
        public bool IsActive { get; set; }

        public static BlogListViewModel GetModel(Blogs blogListingSection)
        {
            var data = blogListingSection == null ? null : new BlogListViewModel()
            {
                BlogsID = blogListingSection.BlogsID,
                Name = blogListingSection.Fields.Name,
                Heading = blogListingSection.Fields.BlogHeading,
                BlogTitle = blogListingSection.Fields.BlogTitle,
                ThumbnailImage = blogListingSection.Fields.ThumbnailImage,
                ThumbnailImageAltText = blogListingSection.Fields.ThumbnailImageAltText,
                BlogShortTitle = blogListingSection.Fields.ShortTitle,
                BlogContentText = blogListingSection.Fields.BlogContentText,
                BlogAuthor = blogListingSection.Fields.BlogAuthor,
                BlogCreatedDate = blogListingSection.Fields.BlogCreatedDate,
                Topic = blogListingSection.Fields.BlogTopic,
                IsActive = blogListingSection.Fields.IsActive,
                BlogURL = blogListingSection.NodeAliasPath,
                DisplayDate = blogListingSection.Fields.BlogCreatedDate.ToString("MMM dd, yyyy"),

                NodeID = blogListingSection.NodeID,
                NodeAliasPath = blogListingSection.NodeAliasPath
            };

            return data;
        }
    }
}
