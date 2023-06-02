using CMS.DocumentEngine.Types.DotStarK;
using DSWEBSITE_K13.Models.ViewModels.Headers;
using System.Collections.Generic;

namespace DSWEBSITE_K13.Components.ViewComponents
{
    public class TopSectionModel
    {
        public string MainTitle { get; set; }
        public string HeadingContentText { get; set; }
        public string ButtonText { get; set; }
        public string ButtonRedirectURL { get; set; }
        public string ButtonHoverText { get; set; }
        public string ClientCaptionCount { get; set; }
        public string ClientCaptionText { get; set; }
        public string ImageAltText { get; set; }
        public string ImageURL { get; set; }
        public List<LinkIconViewModel> BrandList { get; set; }
        public static TopSectionModel GetModel(TopSection topSection)
        {
            var data = topSection == null ? null : new TopSectionModel()
            {
                ButtonHoverText = topSection.Fields.ButtonHoverText,
                ButtonRedirectURL = topSection.Fields.ButtonRedirectURL,
                ButtonText = topSection.Fields.ButtonText,
                ClientCaptionCount = topSection.Fields.ClientCaptionCount,
                ClientCaptionText = topSection.Fields.ClientCaptionText,
                HeadingContentText = topSection.Fields.HeadingContentText,
                ImageAltText = topSection.Fields.ImageAltText,
                ImageURL = topSection.Fields.ImageURL,
                MainTitle = topSection.Fields.MainTitle,
            };

            return data;
        }
    }
}
