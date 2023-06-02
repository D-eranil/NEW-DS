using CMS.DataEngine;
using CMS.DocumentEngine;
using CMS.DocumentEngine.Types.DotStarK;
using CMS.SiteProvider;
using DSWEBSITE_K13.Components.ViewComponents;
using DSWEBSITE_K13.Models;
using DSWEBSITE_K13.Models.ViewModels.Headers;
using Kentico.Content.Web.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace DSWEBSITE_K13.Repositories.Repository
{
    public class HeaderRepository
    {

        private readonly IPageRetriever pageRetriever;
        private readonly bool enableCache;

        /// <summary>
        /// Initializes a new instance of the <see cref="HomeRepository"/> class that returns home page sections. 
        /// </summary>
        /// <param name="pageRetriever">Retriever for pages based on given parameters.</param>
        public HeaderRepository(IPageRetriever pageRetriever)
        {
            this.pageRetriever = pageRetriever;
            this.enableCache = SettingsKeyInfoProvider.GetBoolValue(SiteContext.CurrentSiteName + Constants.EnableCache);
        }

        /// <summary>
        /// Get header details from header page type
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public HeaderViewModel GetHeaders(CancellationToken cancellationToken)
        {
            HeaderViewModel headerViewModel = new HeaderViewModel();
            Header headerPage = new Header();
            try
            {
                Action<DocumentQuery<Header>> pageQuery = query => query
                            .Published(true)
                            .Columns(
                                "Name", "Logo", "LogoAltText", "LogoUrl", "HoverTitle", "NodeAliasPath", 
                                "NodeOrder"
                            )
                            .OnSite(SiteContext.CurrentSiteName)
                            .OrderBy("NodeOrder")
                            .ToList();

                if (enableCache)
                {
                    headerPage = pageRetriever.RetrieveAsync(
                        pageQuery,
                        cache => cache
                            .Key($"{nameof(HeaderRepository)}|{nameof(GetHeaders)}")
                            // Include path dependency to flush cache when a new child page is created or page order is changed.
                            .Dependencies((_, builder) => builder.PagePath("/", PathTypeEnum.Children).PageOrder()),
                        cancellationToken)?.Result.FirstOrDefault();
                }
                else
                {
                    headerPage = pageRetriever.RetrieveAsync(
                        pageQuery)?.Result.FirstOrDefault();
                }

                headerViewModel = HeaderViewModel.GetViewModel(headerPage);
                headerViewModel.MainNavMenus = GetNavMenu();
                headerViewModel.LinkIcons = GetHeaderLinkIcons(headerPage.NodeAliasPath);

                return headerViewModel;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Get main navigation from pages page type
        /// </summary>
        /// <returns></returns>
        public List<NavLinkModel> GetNavMenu()
        {
            List<NavLinkModel> navLinkModels = new List<NavLinkModel>();
            List<Pages> menuNavItems = new List<Pages>();
            try
            {
                Action<DocumentQuery<Pages>> pageQuery = query => query.Published(true)
                           .OnSite(SiteContext.CurrentSiteName)
                           .Columns(
                                "PageName", "NodeAliasPath", "NodeOrder", "ShowInHeader", "ShowInFooter"
                            )
                           .OrderBy("NodeOrder")
                           .Where(x => x.ShowInHeader == true)
                           .ToList();

                if (enableCache)
                {
                    menuNavItems = pageRetriever.RetrieveAsync<Pages>(
                        pageQuery,
                        cache => cache
                            .Key($"{nameof(HeaderRepository)}|{nameof(GetNavMenu)}")
                            // Include path dependency to flush cache when a new child page is created or page order is changed.
                            .Dependencies((_, builder) => builder.PagePath("/", PathTypeEnum.Single).PageOrder()),
                        new CancellationToken())?.Result.ToList();
                }
                else
                {
                    menuNavItems = pageRetriever.RetrieveAsync<Pages>(
                        pageQuery)?.Result.ToList();
                }

                foreach (Pages menuItem in menuNavItems)
                {
                    if (menuItem.ShowInHeader == true)
                    {
                        navLinkModels.Add(new NavLinkModel()
                        {
                            NavItemName = menuItem.Fields.PageName,
                            NavItemUrl = menuItem.NodeAliasPath
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

        /// <summary>
        /// Get right section link icons
        /// </summary>
        /// <param name="nodeAliasPath"></param>
        /// <returns></returns>
        public List<LinkIconViewModel> GetHeaderLinkIcons(string nodeAliasPath)
        {
            List<LinkIconViewModel> linkIcons = new List<LinkIconViewModel>();
            List<LinkIcon> pagelinkIcons = new List<LinkIcon>();
            try
            {
                Action<DocumentQuery<LinkIcon>> pageQuery = query => query.Published(true)
                           .OnSite(SiteContext.CurrentSiteName)
                           .Path(nodeAliasPath, PathTypeEnum.Children)
                           .OrderBy("NodeOrder")
                           .ToList();

                if (enableCache)
                {
                    pagelinkIcons = pageRetriever.RetrieveAsync(
                        pageQuery,
                        cache => cache
                            .Key($"{nameof(HeaderRepository)}|{nameof(GetHeaderLinkIcons)}|{nodeAliasPath}")
                            // Include path dependency to flush cache when a new child page is created or page order is changed.
                            .Dependencies((_, builder) => builder.PagePath(nodeAliasPath, PathTypeEnum.Children).PageOrder()),
                        new CancellationToken())?.Result.ToList();
                }
                else
                {
                    pagelinkIcons = pageRetriever.RetrieveAsync(
                        pageQuery)?.Result.ToList();
                }

                foreach (LinkIcon menuItem in pagelinkIcons)
                {
                    linkIcons.Add(LinkIconViewModel.GetViewModel(menuItem));
                }

                return linkIcons;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
