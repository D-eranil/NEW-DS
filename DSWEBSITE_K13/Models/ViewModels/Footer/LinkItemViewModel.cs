using CMS.DocumentEngine.Types.DotStarK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DSWEBSITE_K13.Models.ViewModels
{
    public class LinkItemViewModel
    {
        public string LinkItemText { get; set; }
        public string LinkItemUrl { get; set; }

        public static LinkItemViewModel GetModel(LinkItem linkItem)
        {
            var data = linkItem == null ? null : new LinkItemViewModel()
            {
                LinkItemText = linkItem.Fields.Text,
                LinkItemUrl = linkItem.Fields.Url
            };

            return data;
        }
    }
}
