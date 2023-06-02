using CMS.DocumentEngine.Types.DotStarK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DSWEBSITE_K13.Models.ViewModels
{
    public class ContactusSourceViewModel
    {
        public string Key { get; set; }
        public bool Value { get; set; }

        public static ContactusSourceViewModel GetModel(ContactusSource sourceSection)
        {
            var data = sourceSection == null ? null : new ContactusSourceViewModel()
            {
                Key = sourceSection.Fields.SourceName,
                Value = false,
                
            };

            return data;
        }
    }
}
