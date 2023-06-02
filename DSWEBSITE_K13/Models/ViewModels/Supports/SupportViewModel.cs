using CMS.DocumentEngine.Types.DotStarK;
using DSWEBSITE_K13.Libraries.Infrastructure.Provider;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DSWEBSITE_K13.Models.ViewModels
{
    public class SupportViewModel
    {
        public string Name { get; set; }
        public string Heading { get; set; }
        public string ContentText { get; set; }
        public string ImageURL { get; set; }
        public string ImageAltText { get; set; }
        public string SectionDivId { get; set; }

        public static SupportViewModel GetModel(Support support)
        {
            var data = support == null ? null : new SupportViewModel()
            {
                Name = support.Fields.Name,
                Heading = support.Fields.Heading,
                ContentText = support.Fields.Content,
                ImageURL = support.Fields.Image,
                ImageAltText = support.Fields.ImageAltText,
                SectionDivId = CommonHelper.GetDashedCodeWithClassName(support.Fields.Name, support.ClassName)
            };

            return data;
        }
    }
}
