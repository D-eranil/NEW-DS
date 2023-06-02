using CMS.DocumentEngine.Types.DotStarK;
using System;

namespace DSWEBSITE_K13.Models.ViewModels.Headers
{
    public class LinkIconViewModel
    {
        public string Icon { get; set; }
        public string IconAltText { get; set; }
        public string IconUrl { get; set; }

        public static LinkIconViewModel GetViewModel(LinkIcon linkIcon) 
        {
            try
            {
                var data = linkIcon == null ? null : new LinkIconViewModel()
                {
                    Icon = linkIcon.Fields.Icon,
                    IconAltText = linkIcon.Fields.IconAltText,
                    IconUrl = linkIcon.Fields.IconUrl
                };

                return data;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
