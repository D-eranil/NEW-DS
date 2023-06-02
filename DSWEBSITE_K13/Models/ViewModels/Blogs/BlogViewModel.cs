using CMS.DocumentEngine.Types.DotStarK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DSWEBSITE_K13.Models.ViewModels
{
    public class BlogViewModel
    {
        public string Name { get; set; }
        public string Heading { get; set; }
        public string BlogImage { get; set; }
        public string BlogTitle { get; set; }
        public string BlogImageAltText { get; set; }
        public string BlogShortTitle { get; set; }
        public string BlogContentText { get; set; }
        public string BlogAuthor { get; set; }
        public DateTime? BlogCreatedDate { get; set; }
        public string BlogReadTimeText { get; set; }
        public string DisplayDate { get; set; }
        public bool IsActive { get; set; }
        public string NodeAliasPath { get; set; }

        public static BlogViewModel GetModel(Blogs blogSection)
        {
            var data = blogSection == null ? null : new BlogViewModel()
            {
                Name = blogSection.Fields.Name,
                Heading = blogSection.Fields.BlogHeading,
                BlogImage = blogSection.Fields.BlogImage,
                BlogTitle = blogSection.Fields.BlogTitle,
                BlogImageAltText = blogSection.Fields.BlogImageAltText,
                BlogShortTitle = blogSection.Fields.ShortTitle,
                BlogContentText = blogSection.Fields.BlogContentText,
                BlogAuthor = blogSection.Fields.BlogAuthor,
                BlogCreatedDate = blogSection.Fields.BlogCreatedDate,
                DisplayDate = blogSection.Fields.BlogCreatedDate.ToString("MMM dd, yyyy"),
                BlogReadTimeText = blogSection.Fields.BlogReadTimeText,
                IsActive = blogSection.Fields.IsActive,
                NodeAliasPath = blogSection.NodeAliasPath
            };

            return data;
        }
    }
}
