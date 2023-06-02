using CMS.DocumentEngine.Types.DotStarK;

namespace DSWEBSITE_K13.Models.ViewModels
{
    public class BadgeViewModel
    {
        public string BadgeAltText { get; set; }
        public string BadgeImage { get; set; }
        public string BadgeTitle { get; set; }

        public static BadgeViewModel GetModel(Badge badge)
        {
            var data = badge == null ? null : new BadgeViewModel()
            {
                BadgeAltText = badge.Fields.AltText,
                BadgeImage = badge.Fields.Image,
                BadgeTitle = badge.Fields.Title
            };
            return data;
        }
    }
}
