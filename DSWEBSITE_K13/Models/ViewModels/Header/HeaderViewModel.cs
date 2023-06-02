using CMS.Core;
using CMS.DocumentEngine.Types.DotStarK;
using CMS.MediaLibrary;
using DSWEBSITE_K13.Models.ViewModels.Headers;
using DSWEBSITE_K13.Repositories.Repository.Layouts;
using Kentico.Content.Web.Mvc;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace DSWEBSITE_K13.Models.ViewModels
{
    public class HeaderViewModel : CommonSettingsViewModel
    {
        public string Name { get; set; }
        public string Logo { get; set; }
        public string LogoAltText { get; set; }
        public string LogoUrl { get; set; }
        public string HoverTitle { get; set; }

        public List<LinkIconViewModel> LinkIcons { get; set; }


        public static HeaderViewModel GetViewModel(Header header, IMediaFileUrlRetriever mediaFileUrlRetriever, IEnumerable<MediaFileInfo> mediaLibraryFiles, string nodeAliasPath, bool disableCache)
        {
            var objHeaderViewModel = new HeaderViewModel();
            try
            {
                objHeaderViewModel = header == null ? null : new HeaderViewModel()
                {
                    Name = header.Fields.Name,
                };
            }
            catch (Exception ex)
            {
                EventLogManager.LogException(ex.Source, "DS-CATCH-ERROR-PARTNER", ex.Message, ex);
                throw ex;
            }
            return objHeaderViewModel;
        }
    }
}
