using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CMS.DataEngine;
using CMS.DocumentEngine.Types.DotStarK;
using CMS.SiteProvider;
using DSWEBSITE_K13.Components.ViewComponents;

namespace DSWEBSITE_K13.Models.ViewModels
{
    public class ContactusViewModel
    {
        public string Name { get; set; }
        public string Title { get; set; }
        public string Subtitle { get; set; }
        public string ButtonText { get; set; }
        public string RecaptchaSiteKey { get; set; }

        public static ContactusViewModel GetModel(Contactus contactSection)
        {
            string key = SettingsKeyInfoProvider.GetValue(SiteContext.CurrentSiteName + ".G_captcha_data_sitekey");

            var data = contactSection == null ? null : new ContactusViewModel()
            {
                Name = contactSection.Fields.Name,
                Title = contactSection.Fields.Title,
                Subtitle = contactSection.Fields.Subtitle,
                ButtonText = contactSection.Fields.ButtonText,
                RecaptchaSiteKey = key
            };

            return data;
        }
    }
}
