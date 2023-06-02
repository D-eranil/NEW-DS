using CMS.DocumentEngine.Types.DotStarK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DSWEBSITE_K13.Components.ViewComponents
{
    public class NewsletterModel
    {
        public string NewsletterName { get; set; }
        public string BackgroundImage { get; set; }
        public string BackgroundImageURL { get; set; }
        public string TitleText { get; set; }
        public string ContentText { get; set; }
        public string EmailTextboxName { get; set; }
        public string ButtonText { get; set; }
        public bool AgreedCheckbox { get; set; }
        public string CheckboxText { get; set; }
        public string ButtonRedirectURL { get; set; }
        public Guid NodeGUID { get; set; }
        public static NewsletterModel GetModel(Newsletter newsletter)
        {
            var data = newsletter == null ? null : new NewsletterModel()
            {
                NewsletterName = newsletter.Fields.Name,
                AgreedCheckbox = newsletter.Fields.AgreedCheckbox,
                BackgroundImage = newsletter.Fields.BackgroundImage,
                BackgroundImageURL = newsletter.Fields.BackgroundImageURL,
                ButtonRedirectURL = newsletter.Fields.ButtonRedirectURL,
                ButtonText = newsletter.Fields.ButtonText,
                CheckboxText = newsletter.Fields.CheckboxText,
                ContentText = newsletter.Fields.ContentText,
                EmailTextboxName = newsletter.Fields.EmailTextboxName,
                TitleText = newsletter.Fields.TitleText,
                NodeGUID = newsletter.NodeGUID
            };

            return data;
        }
    }
}
