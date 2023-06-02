using CMS.DocumentEngine.Types.DotStarK;

namespace DSWEBSITE_K13.Models.ViewModels
{
    public class SocialMediaIconViewModel
    {
        public string SocialMediaIcon { get; set; }
        public string SocialMediaURL { get; set; }
        public string SocialAltText { get; set; }
        //public string SocialMediaRedirectURL { get; set; }
        public int IconWidth { get; set; }
        public bool IsActive { get; set; }

        public static SocialMediaIconViewModel GetModel(SocialMediaIcons socialMediaIcons)
        {
            var data = socialMediaIcons == null ? null : new SocialMediaIconViewModel()
            {
                SocialAltText = socialMediaIcons.Fields.SocialAltText,
                SocialMediaIcon = socialMediaIcons.Fields.SocialMediaIcon,
                SocialMediaURL = socialMediaIcons.Fields.SocialMediaURL,
                IconWidth = socialMediaIcons.Fields.IconWidth,
                //SocialMediaRedirectURL = socialMediaIcons.Fields.SocialMediaRedirectURL,
                IsActive = socialMediaIcons.Fields.IsActive,
            };
            return data;
        }
    }
}
