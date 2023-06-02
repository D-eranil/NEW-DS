using CMS.DocumentEngine.Types.DotStarK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DSWEBSITE_K13.Models.ViewModels
{
    public class ClienteleViewModel
    {
        public string Name { get; set; }
        public string ContentText { get; set; }
        public string ClientImage { get; set; }
        public string ClientImageAltText { get; set; }
        public string ClientImageURL { get; set; }
        public bool IsActive { get; set; }
        public int OrderNumber { get; set; }
        public string ClientDesignation { get; set; }
        public string ClientFullName { get; set; }
        public string ClientLocation { get; set; }

        public static ClienteleViewModel GetModel(Clientele clienteleSection)
        {
            var data = clienteleSection == null ? null : new ClienteleViewModel()
            {
                Name = clienteleSection.Fields.Name,
                ContentText = clienteleSection.Fields.ContentText,
                ClientImage = clienteleSection.Fields.ClientImage,
                ClientImageAltText = clienteleSection.Fields.ClientImageAltText,
                ClientImageURL = clienteleSection.Fields.ClientImageURL,
                IsActive = clienteleSection.Fields.IsActive,
                ClientDesignation = clienteleSection.Fields.ClientDesignation,
                ClientFullName = clienteleSection.Fields.ClientFullName,
                ClientLocation = clienteleSection.Fields.ClientLocation,

            };

            return data;
        }
    }
}
