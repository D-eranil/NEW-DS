using CMS.DataEngine;
using CMS.DocumentEngine;
using CMS.DocumentEngine.Types.DotStarK;
using CMS.SiteProvider;
using DSWEBSITE_K13.Components.ViewComponents;
using DSWEBSITE_K13.Libraries.Infrastructure;
using DSWEBSITE_K13.Libraries.Infrastructure.Provider;
using DSWEBSITE_K13.Models;
using DSWEBSITE_K13.Models.ViewModels;
using DSWEBSITE_K13.Models.ViewModels.Footer;
using Kentico.Content.Web.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace DSWEBSITE_K13.Repositories.Repository
{
    public partial class FooterRepository
    {
        private readonly IPageRetriever pageRetriever;
        private readonly bool enableCache;

        public FooterRepository(IPageRetriever _pageRetriever,
            RepositoryCacheHelper _repositoryCacheHelper)
        {
            this.pageRetriever = _pageRetriever;
            this.enableCache = SettingsKeyInfoProvider.GetBoolValue(SiteContext.CurrentSiteName + Constants.EnableCache);
        }

        public FooterModel GetFooter()
        {
            FooterModel footerViewModel = new FooterModel();
            Footer footerPage = new Footer();
            try
            {
                Action<DocumentQuery<Footer>> pageQuery = query => query.Published(true)
                           .OnSite(SiteContext.CurrentSiteName)
                           .Columns(
                                "Name", "AddressTitle", "Address", "PrimaryContact",
                                "PrimaryEmail", "BadgeTitle", "FooterMap", "ScrollTopIcon",
                                "ScrollTopAltText", "ChatIcon", "ChatAltText",
                                "FooterCopyRightText", "SocialIcon", "CountryName1",
                                "Address1", "CountryName2", "Address2", "CountryName3",
                                "Address3", "CountryName4", "Address4", "NodeOrder",
                                "NodeAliasPath"
                           )
                           .OrderBy("NodeOrder")
                           .FirstOrDefault();

                if (enableCache)
                {
                    footerPage = pageRetriever.RetrieveAsync(
                        pageQuery,
                        cache => cache
                            .Key($"{nameof(FooterRepository)}|{nameof(GetFooter)}")
                            // Include path dependency to flush cache when a new child page is created or page order is changed.
                            .Dependencies((_, builder) => builder.PagePath("/layout/footer", PathTypeEnum.Children).PageOrder()),
                        new CancellationToken())?.Result.FirstOrDefault();
                }
                else
                {
                    footerPage = pageRetriever.RetrieveAsync(
                        pageQuery)?.Result.FirstOrDefault();
                }

                //bind local model
                footerViewModel = FooterModel.GetModel(footerPage);
                footerViewModel.topSocialMediaList = GetSocialMediaList(footerPage.NodeAliasPath + "/top-social-media");
                footerViewModel.usefulLinks = GetUsefulLinks();
                footerViewModel.mainNavMenus = GetFooterNavMenu();
                footerViewModel.brancheList = GetBranchList(footerPage.NodeAliasPath);
                footerViewModel.badges = GetBadges(footerPage.NodeAliasPath);
                footerViewModel.bottomSocialMediaList = GetSocialMediaList(footerPage.NodeAliasPath + "/bottom-social-media");

            }
            catch (Exception ex)
            {
                throw ex;
            }


            return footerViewModel;
        }

        private List<FooterNavLinkModel> GetFooterNavMenu()
        {
            List<FooterNavLinkModel> navLinkModels = new List<FooterNavLinkModel>();
            List<Pages> menuNavItems = new List<Pages>();
            try
            {
                Action<DocumentQuery<Pages>> pageQuery = query => query.Published(true)
                           .OnSite(SiteContext.CurrentSiteName)
                           .Columns(
                                "PageName", "NodeAliasPath", "NodeOrder", "ShowInHeader", "ShowInFooter"
                            )
                           .OrderBy("NodeOrder")
                           .Where(x => x.ShowInFooter == true)
                           .ToList();

                if (enableCache)
                {
                    menuNavItems = pageRetriever.RetrieveAsync(
                        pageQuery,
                        cache => cache
                            .Key($"{nameof(FooterRepository)}|{nameof(GetFooterNavMenu)}")
                            // Include path dependency to flush cache when a new child page is created or page order is changed.
                            .Dependencies((_, builder) => builder.PagePath("/", PathTypeEnum.Single).PageOrder()),
                        new CancellationToken())?.Result.ToList();
                }
                else
                {
                    menuNavItems = pageRetriever.RetrieveAsync(
                        pageQuery)?.Result.ToList();
                }

                foreach (Pages menuItem in menuNavItems)
                {
                    if (menuItem.ShowInFooter == true)
                    {
                        navLinkModels.Add(new FooterNavLinkModel()
                        {
                            NavItemName = menuItem.Fields.PageName,
                            NavItemUrl = menuItem.NodeAliasPath,
                            subNavlinks = GetSubNavMenu(menuItem.NodeAliasPath)
                        });
                    }
                }

                return navLinkModels;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private List<NavLinkModel> GetSubNavMenu(string nodeAliasPath)
        {
            List<NavLinkModel> navLinkModels = new List<NavLinkModel>();
            List<Technologies> technologyItems = new List<Technologies>();
            List<ServiceSection> serviceItems = new List<ServiceSection>();
            List<Support> supportItems = new List<Support>();
            try
            {
                Action<DocumentQuery<Technologies>> pageQuery = query => query.Published(true)
                           .OnSite(SiteContext.CurrentSiteName)
                           .Columns(
                                "TechnologyName", "NodeOrder"
                            )
                           .Path(nodeAliasPath, PathTypeEnum.Children)
                           .OrderBy("NodeOrder")
                           .ToList();
                //Technology
                if (enableCache)
                {
                    technologyItems = pageRetriever.RetrieveAsync(
                        pageQuery,
                        cache => cache
                            .Key($"{nameof(FooterRepository)}|{nameof(GetSubNavMenu)}|{nodeAliasPath}")
                            // Include path dependency to flush cache when a new child page is created or page order is changed.
                            .Dependencies((_, builder) => builder.PagePath(nodeAliasPath, PathTypeEnum.Single).PageOrder()),
                        new CancellationToken()
                    )?.Result.ToList();
                }
                else
                {
                    technologyItems = pageRetriever.RetrieveAsync(
                        pageQuery
                    )?.Result.ToList();
                }
                //Bind
                foreach (Technologies menuItem in technologyItems)
                {
                    navLinkModels.Add(new NavLinkModel()
                    {
                        NavItemName = menuItem.Fields.TechnologyName,
                        NavItemUrl = nodeAliasPath + "#" + CommonHelper.GetDashedCodeFromName(menuItem.Fields.TechnologyName)
                    });
                }
                //Setvice
                Action<DocumentQuery<ServiceSection>> servicePageQuery = query => query.Published(true)
                         .OnSite(SiteContext.CurrentSiteName)
                         .Columns(
                              "Name", "NodeOrder"
                          )
                         .Path(nodeAliasPath, PathTypeEnum.Children)
                         .OrderBy("NodeOrder")
                         .ToList();

                if (enableCache)
                {
                    serviceItems = pageRetriever.RetrieveAsync(
                        servicePageQuery,
                        cache => cache
                            .Key($"{nameof(FooterRepository)}|{nameof(GetSubNavMenu)}|{nodeAliasPath}")
                            // Include path dependency to flush cache when a new child page is created or page order is changed.
                            .Dependencies((_, builder) => builder.PagePath(nodeAliasPath, PathTypeEnum.Single).PageOrder()),
                        new CancellationToken()
                    )?.Result.ToList();
                }
                else
                {
                    serviceItems = pageRetriever.RetrieveAsync(
                        servicePageQuery
                    )?.Result.ToList();
                }
                //Bind
                foreach (ServiceSection menuItem in serviceItems)
                {
                    navLinkModels.Add(new NavLinkModel()
                    {
                        NavItemName = menuItem.Fields.Name,
                        NavItemUrl = nodeAliasPath + "#" + CommonHelper.GetDashedCodeFromName(menuItem.Fields.Name)
                    });
                }

                //Support
                Action<DocumentQuery<Support>> supportPageQuery = query => query.Published(true)
                         .OnSite(SiteContext.CurrentSiteName)
                         .Columns(
                              "Name", "NodeOrder"
                          )
                         .Path(nodeAliasPath, PathTypeEnum.Children)
                         .OrderBy("NodeOrder")
                         .ToList();

                if (enableCache)
                {
                    supportItems = pageRetriever.RetrieveAsync(
                        supportPageQuery,
                        cache => cache
                            .Key($"{nameof(FooterRepository)}|{nameof(GetSubNavMenu)}|{nodeAliasPath}")
                            // Include path dependency to flush cache when a new child page is created or page order is changed.
                            .Dependencies((_, builder) => builder.PagePath(nodeAliasPath, PathTypeEnum.Single).PageOrder()),
                        new CancellationToken()
                    )?.Result.ToList();
                }
                else
                {
                    supportItems = pageRetriever.RetrieveAsync(
                        supportPageQuery
                    )?.Result.ToList();
                }
                //Bind
                foreach (Support menuItem in supportItems)
                {
                    navLinkModels.Add(new NavLinkModel()
                    {
                        NavItemName = menuItem.Fields.Name,
                        NavItemUrl = nodeAliasPath + "#" + CommonHelper.GetDashedCodeFromName(menuItem.Fields.Name)
                    });
                }

                return navLinkModels;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private List<LinkItemViewModel> GetUsefulLinks()
        {
            List<LinkItemViewModel> linkModel = new List<LinkItemViewModel>();
            List<LinkItem> linkPages = new List<LinkItem>();
            string nodeAliasPath = Constants.UsefulLinksPath;
            try
            {
                Action<DocumentQuery<LinkItem>> pageQuery = query => query.Published(true)
                           .OnSite(SiteContext.CurrentSiteName)
                           .Columns(
                                "LinkItemText", "LinkItemUrl", "NodeOrder"
                           )
                           .OrderBy("NodeOrder")
                           .Path(nodeAliasPath, PathTypeEnum.Children)
                           .ToList();

                if (enableCache)
                {
                    linkPages = pageRetriever.RetrieveAsync(
                        pageQuery,
                        cache => cache
                            .Key($"{nameof(FooterRepository)}|{nameof(GetUsefulLinks)}|{nodeAliasPath}")
                            // Include path dependency to flush cache when a new child page is created or page order is changed.
                            .Dependencies((_, builder) => builder.PagePath(nodeAliasPath, PathTypeEnum.Children).PageOrder()),
                        new CancellationToken())?.Result.ToList();
                }
                else
                {
                    linkPages = pageRetriever.RetrieveAsync(
                        pageQuery)?.Result.ToList();
                }

                //bind local model
                foreach (var linkItem in linkPages)
                {
                    linkModel.Add(LinkItemViewModel.GetModel(linkItem));
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }


            return linkModel;
        }
        private List<BadgeViewModel> GetBadges(string nodeAliasPath)
        {
            List<BadgeViewModel> badgeList = new List<BadgeViewModel>();
            List<Badge> badges = new List<Badge>();
            try
            {
                Action<DocumentQuery<Badge>> pageQuery = query => query.Published(true)
                           .OnSite(SiteContext.CurrentSiteName)
                           .Columns(
                                "BadgeAltText", "BadgeImage", "BadgeTitle", "NodeOrder"
                           )
                           .OrderBy("NodeOrder")
                           .Path(nodeAliasPath, PathTypeEnum.Children)
                           .ToList();

                if (enableCache)
                {
                    badges = pageRetriever.RetrieveAsync(
                        pageQuery,
                        cache => cache
                            .Key($"{nameof(FooterRepository)}|{nameof(GetBadges)}|{nodeAliasPath}")
                            // Include path dependency to flush cache when a new child page is created or page order is changed.
                            .Dependencies((_, builder) => builder.PagePath(nodeAliasPath, PathTypeEnum.Children).PageOrder()),
                        new CancellationToken())?.Result.ToList();
                }
                else
                {
                    badges = pageRetriever.RetrieveAsync(
                        pageQuery)?.Result.ToList();
                }

                //bind local model
                foreach (var badge in badges)
                {
                    badgeList.Add(BadgeViewModel.GetModel(badge));
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return badgeList;
        }
        private List<BranchesViewModel> GetBranchList(string nodeAliasPath)
        {
            List<BranchesViewModel> branchList = new List<BranchesViewModel>();
            List<Branches> branches = new List<Branches>();
            try
            {
                Action<DocumentQuery<Branches>> pageQuery = query => query.Published(true)
                           .OnSite(SiteContext.CurrentSiteName)
                           .Columns(
                                "BranchName", "BranchImage", "ImageAltText", "IsActive", 
                                "BranchAddress", "IsActive", "NodeOrder"
                           )
                           .OrderBy("NodeOrder")
                           .Path(nodeAliasPath, PathTypeEnum.Children)
                           .WhereEquals("IsActive", true)
                           .ToList();

                if (enableCache)
                {
                    branches = pageRetriever.RetrieveAsync(
                        pageQuery,
                        cache => cache
                            .Key($"{nameof(FooterRepository)}|{nameof(GetBranchList)}|{nodeAliasPath}")
                            // Include path dependency to flush cache when a new child page is created or page order is changed.
                            .Dependencies((_, builder) => builder.PagePath(nodeAliasPath, PathTypeEnum.Children).PageOrder()),
                        new CancellationToken())?.Result.ToList();
                }
                else
                {
                    branches = pageRetriever.RetrieveAsync(
                        pageQuery)?.Result.ToList();
                }

                //bind local model
                foreach (var badge in branches)
                {
                    branchList.Add(BranchesViewModel.GetModel(badge));
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return branchList;
        }

        private List<SocialMediaIconViewModel> GetSocialMediaList(string nodeAliasPath)
        {
            List<SocialMediaIconViewModel> socialMediaList = new List<SocialMediaIconViewModel>();
            List<SocialMediaIcons> socialMediaPage = new List<SocialMediaIcons>();
            try
            {
                Action<DocumentQuery<SocialMediaIcons>> pageQuery = query => query.Published(true)
                           .OnSite(SiteContext.CurrentSiteName)
                           .Columns(
                                "SocialAltText", "SocialMediaIcon", "SocialMediaURL", "IsActive",
                                "NodeAliasPath", "IconWidth", "SocialMediaRedirectURL", "NodeOrder"
                            )
                           .OrderBy("NodeOrder")
                           .Path(nodeAliasPath, PathTypeEnum.Children)
                           .WhereEquals("IsActive", true)
                           .ToList();

                if (enableCache)
                {
                    socialMediaPage = pageRetriever.RetrieveAsync(
                        pageQuery,
                        cache => cache
                            .Key($"{nameof(FooterRepository)}|{nameof(GetSocialMediaList)}")
                            // Include path dependency to flush cache when a new child page is created or page order is changed.
                            .Dependencies((_, builder) => builder.PagePath("/", PathTypeEnum.Single).PageOrder()),
                        new CancellationToken())?.Result.ToList();
                }
                else
                {
                    socialMediaPage = pageRetriever.RetrieveAsync(
                        pageQuery)?.Result.ToList();
                }

                foreach (SocialMediaIcons menuItem in socialMediaPage)
                {
                    socialMediaList.Add(SocialMediaIconViewModel.GetModel(menuItem));
                }

                return socialMediaList;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
