using CMS.DocumentEngine.Types.DotStarK;
using DSWEBSITE_K13.Libraries.Infrastructure.Provider;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DSWEBSITE_K13.Components.ViewComponents
{
    public class BlogModel
    {
        public string Name { get; set; }
        public string BlogImage { get; set; }
        public string BlogTitle { get; set; }
        public string BlogImageAltText { get; set; }
        public string BlogImageURL { get; set; }
        public string BlogShortTitle { get; set; }
        public string BlogContentText { get; set; }
        public string BlogAuthor { get; set; }
        public DateTime? BlogCreatedDate { get; set; }
        public string BlogDate { get; set; }
        public string BlogReadTimeText { get; set; }
        public bool IsActive { get; set; }

        public static BlogModel GetModel(Blogs blogSection)
        {
            var data = blogSection == null ? null : new BlogModel()
            {
                Name = blogSection.Fields.Name,
                BlogImage = blogSection.Fields.BlogImage,
                BlogTitle = blogSection.Fields.BlogTitle,
                BlogImageAltText = blogSection.Fields.BlogImageAltText,
                BlogShortTitle = blogSection.Fields.ShortTitle,
                BlogContentText = blogSection.Fields.BlogContentText,
                BlogAuthor = blogSection.Fields.BlogAuthor,
                BlogCreatedDate = blogSection.Fields.BlogCreatedDate,
                BlogReadTimeText = blogSection.Fields.BlogReadTimeText,
                IsActive = blogSection.Fields.IsActive,
            };

            return data;
        }

        //public static string DateTimeConversion(string Date, string DateInputFormat, string DateOutputFormat)
        //{
        //    string ConvertedDate = "";
        //    if (string.IsNullOrEmpty(Date))
        //    {
        //        ConvertedDate = "Please Provide the Valid DateTime";
        //    }
        //    else
        //    {
        //        DateTime Outputdate;

        //        if (DateTime.TryParseExact(Date, DateInputFormat, System.Globalization.CultureInfo.InvariantCulture, System.Globalization.DateTimeStyles.None, out Outputdate))
        //        {
        //            ConvertedDate = Outputdate.ToString(DateOutputFormat);
        //        }
        //        else
        //        {
        //            ConvertedDate = "Enter the valid Date as Per Input Format";
        //        }
        //    }
        //    return ConvertedDate;
        //}
    }
}
