using CMS.DocumentEngine.Types.DotStarK;
using DSWEBSITE_K13.Models.ViewModels;
using DSWEBSITE_K13.Models.ViewModels.Footer;
using System.Collections.Generic;

namespace DSWEBSITE_K13.Components.ViewComponents
{
    public class FooterNavLinkModel
    {
        public string NavItemName { get; set; }
        public string NavItemUrl { get; set; }
        public List<NavLinkModel> subNavlinks { get; set; }
    }
    public class FooterModel
    {
        public FooterModel()
        {
            usefulLinks = new List<LinkItemViewModel>();
            mainNavMenus = new List<FooterNavLinkModel>();
            badges = new List<BadgeViewModel>();
            bottomSocialMediaList = new List<SocialMediaIconViewModel>();
            topSocialMediaList = new List<SocialMediaIconViewModel>();
            brancheList = new List<BranchesViewModel>();
        }
        public string Name { get; set; }
        public string AddressTitle { get; set; }
        public string Address { get; set; }
        public string PrimaryContact { get; set; }
        public string PrimaryEmail { get; set; }
        public string BadgeTitle { get; set; }
        public string FooterMap { get; set; }
        public string ScrollTopIcon { get; set; }
        public string ScrollTopAltText { get; set; }
        public string ChatIcon { get; set; }
        public string ChatAltText { get; set; }
        public string FooterCopyRightText { get; set; }
        public string SocialIcon { get; set; }
        public string CountryName1 { get; set; }
        public string Address1 { get; set; }
        public string CountryName2 { get; set; }
        public string Address2 { get; set; }
        public string CountryName3 { get; set; }
        public string Address3 { get; set; }
        public string CountryName4 { get; set; }
        public string Address4 { get; set; }
        public List<FooterNavLinkModel> mainNavMenus { get; set; }
        public List<LinkItemViewModel> usefulLinks { get; set; }
        public List<BadgeViewModel> badges { get; set; }
        public List<SocialMediaIconViewModel> bottomSocialMediaList { get; set; }
        public List<SocialMediaIconViewModel> topSocialMediaList { get; set; }
        public List<BranchesViewModel> brancheList { get; set; }

        public static FooterModel GetModel(Footer footer)
        {
            var modelData = footer == null ? null : new FooterModel()
            {
                Address = footer.Fields.Address,
                Address1 = footer.Fields.Address1,
                Address2 = footer.Fields.Address2,
                Address3 = footer.Fields.Address3,
                Address4 = footer.Fields.Address4,
                AddressTitle = footer.Fields.AddressTitle,
                BadgeTitle = footer.Fields.BadgeTitle,
                ChatAltText = footer.Fields.ChatAltText,
                ChatIcon = footer.Fields.ChatIcon,
                CountryName1 = footer.Fields.CountryName1,
                CountryName2 = footer.Fields.CountryName2,
                CountryName3 = footer.Fields.CountryName3,
                CountryName4 = footer.Fields.CountryName4,
                FooterCopyRightText = footer.Fields.CopyRightText,
                FooterMap = footer.Fields.Map,
                Name = footer.Fields.Name,
                PrimaryContact = footer.Fields.PrimaryContact,
                PrimaryEmail = footer.Fields.PrimaryEmail,
                ScrollTopAltText = footer.Fields.ScrollTopAltText,
                ScrollTopIcon = footer.Fields.ScrollTopIcon,
                SocialIcon = footer.Fields.SocialIcon
            };

            return modelData;
        }
    }
}
