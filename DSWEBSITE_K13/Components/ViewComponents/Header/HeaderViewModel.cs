using CMS.DocumentEngine.Types.DotStarK;
using DSWEBSITE_K13.Models.ViewModels.Headers;
using System;
using System.Collections.Generic;

namespace DSWEBSITE_K13.Components.ViewComponents
{
    public class NavLinkModel
    {
        public string NavItemName { get; set; }
        public string NavItemUrl { get; set; }
    }

    public class HeaderViewModel
    {
        public string Name { get; set; }
        public string Logo { get; set; }
        public string LogoAltText { get; set; }
        public string LogoUrl { get; set; }
        public string HoverTitle { get; set; }
        public List<NavLinkModel> MainNavMenus { get; set; }
        public List<LinkIconViewModel> LinkIcons { get; set; }

        public static HeaderViewModel GetViewModel(Header header)
        {
            var headerViewModel = new HeaderViewModel();
            try
            {
                headerViewModel = header == null ? null : new HeaderViewModel()
                {
                    ////map property form entity to model
                  Name = header.Fields.Name,
                  HoverTitle = header.Fields.HoverTitle,
                  Logo = header.Fields.Logo,
                  LogoAltText = header.Fields.LogoAltText,
                  LogoUrl = header.Fields.LogoUrl                  
                };
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return headerViewModel;
        }
    }
}
