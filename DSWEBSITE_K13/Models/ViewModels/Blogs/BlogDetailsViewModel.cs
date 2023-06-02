using CMS.DocumentEngine.Types.DotStarK;
using DSWEBSITE_K13.Libraries.Infrastructure.Provider;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DSWEBSITE_K13.Models.ViewModels
{
    public class BlogDetailsViewModel
    {
        public string Name { get; set; }
        public string Heading { get; set; }
        public string BlogTitle { get; set; }
        public string BlogImage { get; set; }
        public string BlogImageAltText { get; set; }
        public string BlogDetailImage { get; set; }
        public string BlogDetailImageAltText { get; set; }
        public string BlogShortTitle { get; set; }
        public string BlogContentText { get; set; }
        public string BlogContentHtmlText { get; set; }
        public string BlogAuthor { get; set; }
        public DateTime? BlogCreatedDate { get; set; }
        public string DisplayDate { get; set; }
        public string BlogReadTimeText { get; set; }
        public bool IsActive { get; set; }
        public string Topic { get; set; }
        public string BlogImageURL { get; set; }

        public string BlogBannerImage { get; set; }
        public string BlogBannerImageAltText { get; set; }
        public string Category { get; set; }
        public string Tag { get; set; }

        public List<string> Tags { get; set; }


        public int NodeID { get; set; }
        public string NodeAliasPath { get; set; }


        public static BlogDetailsViewModel GetModel(Blogs blogDetailSection)
        {
            var data = blogDetailSection == null ? null : new BlogDetailsViewModel()
            {
                Name = blogDetailSection.Fields.Name,
                Heading = blogDetailSection.Fields.BlogHeading,
                BlogTitle = blogDetailSection.Fields.BlogTitle,
                BlogImage = blogDetailSection.Fields.BlogImage,
                BlogImageAltText = blogDetailSection.Fields.BlogImageAltText,
                BlogDetailImage = blogDetailSection.Fields.BlogDetailImage,
                BlogDetailImageAltText = blogDetailSection.Fields.BlogDetailImageAltText,
                BlogShortTitle = blogDetailSection.Fields.ShortTitle,
                BlogContentText = blogDetailSection.Fields.BlogContentText,
                BlogContentHtmlText = blogDetailSection.Fields.BlogDetailContent,
                BlogAuthor = blogDetailSection.Fields.BlogAuthor,
                BlogCreatedDate = blogDetailSection.Fields.BlogCreatedDate,
                BlogReadTimeText = blogDetailSection.Fields.BlogReadTimeText,
                Topic = blogDetailSection.Fields.BlogTopic,
                IsActive = blogDetailSection.Fields.IsActive,
                DisplayDate = blogDetailSection.Fields.BlogCreatedDate.ToString("MMM dd, yyyy"),

                BlogBannerImage = blogDetailSection.Fields.BlogBannerImage,
                BlogBannerImageAltText = blogDetailSection.Fields.BlogBannerImageAltText,
                Category = blogDetailSection.Fields.Category,
                Tag = blogDetailSection.Fields.Tag,
                Tags = CommonHelper.GetListFormString(blogDetailSection.Fields.Tag),

                NodeID = blogDetailSection.NodeID,
                NodeAliasPath = blogDetailSection.NodeAliasPath
            };

            return data;
        }
    }

}
