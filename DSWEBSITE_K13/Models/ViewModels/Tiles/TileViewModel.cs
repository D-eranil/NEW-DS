using CMS.DocumentEngine.Types.DotStarK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DSWEBSITE_K13.Models.ViewModels
{
    public class TileViewModel
    {

        public string Name { get; set; }
        public string ImageAltText { get; set; }
        public string ImageURL { get; set; }
        public string Title { get; set; }
        public string ContentText { get; set; }
        public string ButtonText { get; set; }
        public string ButtonRedirectURL { get; set; }
        public string ThemesColor { get; set; }

        public static TileViewModel GetModel(Tiles tileSection)
        {
            var data = tileSection == null ? null : new TileViewModel()
            {

                Name = tileSection.Fields.Name,
                ImageAltText = tileSection.Fields.ImageAltText,
                ImageURL = tileSection.Fields.ImageURL,
                Title = tileSection.Fields.Title,
                ContentText = tileSection.Fields.ContentText,
                ButtonText = tileSection.Fields.ButtonText,
                ButtonRedirectURL = tileSection.Fields.ButtonRedirectURL,
                ThemesColor = tileSection.Fields.ThemesColor,


            };

            return data;
        }

    }
}
