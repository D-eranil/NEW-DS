using CMS.DataEngine;
using CMS.DocumentEngine;
using CMS.DocumentEngine.Types.DotStarK;
using CMS.SiteProvider;
using DSWEBSITE_K13.Components.ViewComponents;
using DSWEBSITE_K13.Libraries.Infrastructure;
using DSWEBSITE_K13.Models.ViewModels;
using Kentico.Content.Web.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace DSWEBSITE_K13.Repositories.Repository
{
    public partial class TechnologyRepository
    {
        private readonly IPageRetriever pageRetriever;
        private readonly RepositoryCacheHelper repositoryCacheHelper;

        /// <summary>
        /// Initializes a new instance of the <see cref="HomeRepository"/> class that returns home page sections. 
        /// </summary>
        /// <param name="pageRetriever">Retriever for pages based on given parameters.</param>
        public TechnologyRepository(IPageRetriever pageRetriever,
            RepositoryCacheHelper _repositoryCacheHelper)
        {
            this.pageRetriever = pageRetriever;
            this.repositoryCacheHelper = _repositoryCacheHelper;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public TechnologyViewModel GetTechnology()
        {
            try
            {
                string[] cols = { "Heading", "SubHeading", "ContentText", "BannerImage", "ImageAltText", "Title", "IsActive" };

                bool enableCache = SettingsKeyInfoProvider.GetBoolValue(SiteContext.CurrentSiteName + ".EnableCache");

                var technology = new Technology();
                var _technology = new TechnologyViewModel();

                if (!enableCache)
                {
                    //IEnumerable<BannerSection> related = Enumerable.Empty<BannerSection>();
                    technology = pageRetriever.RetrieveAsync<Technology>(
                        query => query

                            .Published(true)
                            .OnSite(SiteContext.CurrentSiteName)
                             .Columns(cols)
                            .TopN(1)
                            .OrderByDescending(x => x.DocumentCreatedWhen)
                            .ToList())?.Result.FirstOrDefault();
                    //related = Enumerable.Cast<BannerSection>(data.Result);
                }
                else
                {
                    technology = pageRetriever.RetrieveAsync<Technology>(
                        query => query
                            .Published(true)
                            .OnSite(SiteContext.CurrentSiteName)
                             .Columns(cols)
                             .TopN(1)
                            .OrderByDescending(x => x.DocumentCreatedWhen)
                            .ToList(),
                        cache => cache
                            .Key($"{nameof(TechnologyRepository)}|{nameof(GetTechnology)}")
                            // Include path dependency to flush cache when a new child page is created or page order is changed.
                            .Dependencies((_, builder) => builder.PagePath("", PathTypeEnum.Children).PageOrder()),
                        new CancellationToken())?.Result.FirstOrDefault();

                }

                if (technology != null)
                {
                    _technology = TechnologyViewModel.GetModel(technology);
                }

                return _technology;
            }
            catch (System.Exception ex)
            {
                EventLogManager.LogError(ex.Source, "100000014", ex.Message);
                throw ex;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<TechnologiesViewModel> GetTechnologies()
        {
            try
            {
                string[] cols = { "TechnologyName", "TechnologyImage", "TechnologyDescription", "ImageAltText", "IsActive", "NodeOrder" };

                bool enableCache = SettingsKeyInfoProvider.GetBoolValue(SiteContext.CurrentSiteName + ".EnableCache");

                var technologyList = new List<Technologies>();
                var _technologyList = new List<TechnologiesViewModel>();

                if (!enableCache)
                {
                    //IEnumerable<BannerSection> related = Enumerable.Empty<BannerSection>();
                    technologyList = pageRetriever.RetrieveAsync<Technologies>(
                        query => query

                            .Published(true)
                            .OnSite(SiteContext.CurrentSiteName)
                             .Columns(cols)
                             .WhereEquals("IsActive", true)
                             .OrderBy("NodeOrder")
                            .ToList())?.Result.ToList();
                    //related = Enumerable.Cast<BannerSection>(data.Result);
                }
                else
                {
                    technologyList = pageRetriever.RetrieveAsync<Technologies>(
                        query => query
                            .Published(true)
                            .OnSite(SiteContext.CurrentSiteName)
                             .Columns(cols)
                             .WhereEquals("IsActive", true)
                             .OrderBy("NodeOrder")
                            .ToList(),
                        cache => cache
                            .Key($"{nameof(TechnologyRepository)}|{nameof(GetTechnologies)}")
                            // Include path dependency to flush cache when a new child page is created or page order is changed.
                            .Dependencies((_, builder) => builder.PagePath("", PathTypeEnum.Children).PageOrder()),
                        new CancellationToken())?.Result.ToList();

                }

                if (technologyList != null && technologyList.Count > 0)
                {
                    _technologyList = new List<TechnologiesViewModel>();
                    foreach (var technologie in technologyList)
                    {
                        _technologyList.Add(TechnologiesViewModel.GetModel(technologie));
                    }
                }

                return _technologyList;
            }
            catch (System.Exception ex)
            {
                EventLogManager.LogError(ex.Source, "100000015", ex.Message);
                throw ex;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<TechnologyDetailViewModel> GetTechnologyDetails()
        {
            try
            {
                string[] cols = { "TechnologyTitle", "TechnologyName", "BackgroundImage", "BackgroundImageAltText", "TechnologyLogo", "ContentText", "IsActive", "NodeOrder" };

                bool enableCache = SettingsKeyInfoProvider.GetBoolValue(SiteContext.CurrentSiteName + ".EnableCache");

                var technologyDetailList = new List<TechnologyDetails>();
                var _technologyList = new List<TechnologyDetailViewModel>();

                if (!enableCache)
                {
                    //IEnumerable<BannerSection> related = Enumerable.Empty<BannerSection>();
                    technologyDetailList = pageRetriever.RetrieveAsync<TechnologyDetails>(
                        query => query

                            .Published(true)
                            .OnSite(SiteContext.CurrentSiteName)
                             .Columns(cols)
                             .WhereEquals("IsActive", true)
                             .OrderBy("NodeOrder")
                            .ToList())?.Result.ToList();
                    //related = Enumerable.Cast<BannerSection>(data.Result);
                }
                else
                {
                    technologyDetailList = pageRetriever.RetrieveAsync<TechnologyDetails>(
                        query => query
                            .Published(true)
                            .OnSite(SiteContext.CurrentSiteName)
                             .Columns(cols)
                             .WhereEquals("IsActive", true)
                             .OrderBy("NodeOrder")
                            .ToList(),
                        cache => cache
                            .Key($"{nameof(TechnologyRepository)}|{nameof(GetTechnologyDetails)}")
                            // Include path dependency to flush cache when a new child page is created or page order is changed.
                            .Dependencies((_, builder) => builder.PagePath("", PathTypeEnum.Children).PageOrder()),
                        new CancellationToken())?.Result.ToList();

                }

                if (technologyDetailList != null && technologyDetailList.Count > 0)
                {
                    _technologyList = new List<TechnologyDetailViewModel>();
                    foreach (var technologie in technologyDetailList)
                    {
                        _technologyList.Add(TechnologyDetailViewModel.GetModel(technologie));
                    }
                }

                return _technologyList;
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }
    }
}

