using CMS.DataEngine;
using CMS.DocumentEngine;
using CMS.DocumentEngine.Types.DotStarK;
using CMS.SiteProvider;
using DSWEBSITE_K13.Components.ViewComponents;
using DSWEBSITE_K13.Libraries.Infrastructure;
using DSWEBSITE_K13.Models.ViewModels;
using Kentico.Content.Web.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace DSWEBSITE_K13.Repositories.Repository
{
    public class ClienteleRepository
    {

        private readonly IPageRetriever pageRetriever;
        private readonly RepositoryCacheHelper repositoryCacheHelper;

        /// <summary>
        /// Initializes a new instance of the <see cref="HomeRepository"/> class that returns home page sections. 
        /// </summary>
        /// <param name="pageRetriever">Retriever for pages based on given parameters.</param>
        public ClienteleRepository(IPageRetriever pageRetriever,
            RepositoryCacheHelper _repositoryCacheHelper)
        {
            this.pageRetriever = pageRetriever;
            this.repositoryCacheHelper = _repositoryCacheHelper;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public ClienteleContainerModel GetHomePageClienteles()
        {
            try
            {
                bool enableCache = SettingsKeyInfoProvider.GetBoolValue(SiteContext.CurrentSiteName + ".EnableCache");
                string[] cols = { "Name", "ContentText", "ClientImage", "ClientImageAltText", "ClientImageURL", "IsActive", "OrderNumber", "ClientDesignation", "ClientFullName", "ClientLocation" };
                var clienteleList = new List<Clientele>();
                var clienteles = new ClienteleContainerModel();

                if (!enableCache)
                {
                    //IEnumerable<BannerSection> related = Enumerable.Empty<BannerSection>();
                    clienteleList = pageRetriever.RetrieveAsync<Clientele>(
                        query => query
                            .Published(true)
                            .OnSite(SiteContext.CurrentSiteName)
                             .Columns(cols)
                            .TopN(10)
                            .OrderByDescending(x => x.DocumentCreatedWhen)
                            .ToList())?.Result.ToList();
                    //related = Enumerable.Cast<BannerSection>(data.Result);
                }
                else
                {
                    clienteleList = pageRetriever.RetrieveAsync<Clientele>(
                        query => query
                            .Published(true)
                            .OnSite(SiteContext.CurrentSiteName)
                             .Columns(cols)
                             .TopN(10)
                            .OrderByDescending(x => x.DocumentCreatedWhen)
                            .ToList(),
                        cache => cache
                            .Key($"{nameof(ClienteleRepository)}|{nameof(GetHomePageClienteles)}")
                            // Include path dependency to flush cache when a new child page is created or page order is changed.
                            .Dependencies((_, builder) => builder.PagePath("", PathTypeEnum.Children).PageOrder()),
                        new CancellationToken())?.Result.ToList();

                }

                if (clienteleList != null && clienteleList.Count > 0)
                {
                    clienteles.Clienteles = new List<ClienteleViewModel>();
                    foreach (var clientele in clienteleList)
                    {
                        clienteles.Heading = GetHeadings();
                        clienteles.Clienteles.Add(ClienteleViewModel.GetModel(clientele));
                    }
                }

                return clienteles;
            }
            catch (System.Exception ex)
            {
                EventLogManager.LogError(ex.Source, "100000021", ex.Message);
                throw ex;
            }
        }

        private string GetHeadings()
        {
            try
            {
                bool enableCache = SettingsKeyInfoProvider.GetBoolValue(SiteContext.CurrentSiteName + ".EnableCache");
                string[] cols = { "Heading" };
                var heading = new ClienteleContainer();
                string _heading = "";

                if (!enableCache)
                {
                    //IEnumerable<BannerSection> related = Enumerable.Empty<BannerSection>();
                    heading = pageRetriever.RetrieveAsync<ClienteleContainer>(
                        query => query
                            .Published(true)
                            .OnSite(SiteContext.CurrentSiteName)
                             .Columns(cols)
                            .TopN(1)
                            .FirstOrDefault())?.Result.FirstOrDefault();
                }
                else
                {
                    heading = pageRetriever.RetrieveAsync<ClienteleContainer>(
                        query => query
                            .Published(true)
                            .OnSite(SiteContext.CurrentSiteName)
                             .Columns(cols)
                             .TopN(1)
                            .ToList(),
                        cache => cache
                            .Key($"{nameof(ClienteleRepository)}|{nameof(GetHeadings)}")
                            // Include path dependency to flush cache when a new child page is created or page order is changed.
                            .Dependencies((_, builder) => builder.PagePath("", PathTypeEnum.Children).PageOrder()),
                        new CancellationToken())?.Result.FirstOrDefault();

                }

                if (heading != null)
                    _heading = heading.Heading;

                return _heading;
            }
            catch (System.Exception ex)
            {
                EventLogManager.LogError(ex.Source, "100000022", ex.Message);
                throw ex;
            }
        }
    }
}