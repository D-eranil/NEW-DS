using CMS.DocumentEngine.Types.DotStarK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DSWEBSITE_K13.Models.ViewModels
{
    public class ProcessViewModel
    {
        public string Name { get; set; }
        public string Title { get; set; }
        public string ContentText { get; set; }
        public string ImageURL { get; set; }
        public string ImageAltText { get; set; }
        public string ImageHoverText { get; set; }
        public bool IsActive { get; set; }

        public List<ProcessListViewModel> Processes { get; set; }

        public static ProcessViewModel GetModel(Process processSection)
        {
            var data = processSection == null ? null : new ProcessViewModel()
            {
                Name = processSection.Fields.Name,
                Title = processSection.Fields.Title,
                ContentText = processSection.Fields.ContentText,
                ImageURL = processSection.Fields.ImageURL,
                ImageAltText = processSection.Fields.ImageAltText,
                ImageHoverText = processSection.Fields.ImageHoverText,
                IsActive = processSection.Fields.IsActive
                
            };

            return data;
        }
    }
}
