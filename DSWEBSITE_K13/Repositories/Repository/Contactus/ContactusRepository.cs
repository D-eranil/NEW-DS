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
    public class ContactusRepository
    {

        private readonly IPageRetriever pageRetriever;
        private readonly RepositoryCacheHelper repositoryCacheHelper;

        /// <summary>
        /// Initializes a new instance of the <see cref="HomeRepository"/> class that returns home page sections. 
        /// </summary>
        /// <param name="pageRetriever">Retriever for pages based on given parameters.</param>
        public ContactusRepository(IPageRetriever pageRetriever,
            RepositoryCacheHelper _repositoryCacheHelper)
        {
            this.pageRetriever = pageRetriever;
            this.repositoryCacheHelper = _repositoryCacheHelper;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public ContactusViewModel GetContactus()
        {
            try
            {
                bool enableCache = SettingsKeyInfoProvider.GetBoolValue(SiteContext.CurrentSiteName + ".EnableCache");

                string[] cols = { "Name", "Title", "Subtitle", "ButtonText" };

                var contactus = new Contactus();
                var _contactus = new ContactusViewModel();

                if (!enableCache)
                {
                    //IEnumerable<BannerSection> related = Enumerable.Empty<BannerSection>();
                    contactus = pageRetriever.RetrieveAsync<Contactus>(
                        query => query
                            .Published(true)
                            .OnSite(SiteContext.CurrentSiteName)
                             .Columns(cols)
                            .OrderByDescending(x => x.DocumentCreatedWhen)
                            .ToList())?.Result.FirstOrDefault();
                    //related = Enumerable.Cast<BannerSection>(data.Result);
                }
                else
                {
                    contactus = pageRetriever.RetrieveAsync<Contactus>(
                        query => query
                            .Published(true)
                            .OnSite(SiteContext.CurrentSiteName)
                             .Columns(cols)
                            .OrderByDescending(x => x.DocumentCreatedWhen)
                            .ToList(),
                        cache => cache
                            .Key($"{nameof(ContactusRepository)}|{nameof(GetContactus)}")
                            // Include path dependency to flush cache when a new child page is created or page order is changed.
                            .Dependencies((_, builder) => builder.PagePath("", PathTypeEnum.Children).PageOrder()),
                        new CancellationToken())?.Result.FirstOrDefault();

                }

                if (contactus != null)
                {
                    _contactus = ContactusViewModel.GetModel(contactus);
                }

                return _contactus;
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<ContactusSourceViewModel> GetContactusSource()
        {
            try
            {
                bool enableCache = SettingsKeyInfoProvider.GetBoolValue(SiteContext.CurrentSiteName + ".EnableCache");
                string[] cols = { "Name", "SourceName" };

                var sources = new List<ContactusSource>();
                var _sources = new List<ContactusSourceViewModel>();

                if (!enableCache)
                {
                    //IEnumerable<BannerSection> related = Enumerable.Empty<BannerSection>();
                    sources = pageRetriever.RetrieveAsync<ContactusSource>(
                        query => query
                            .Published(true)
                            .OnSite(SiteContext.CurrentSiteName)
                             .Columns(cols)
                            .OrderByDescending(x => x.DocumentCreatedWhen)
                            .ToList())?.Result.ToList();
                    //related = Enumerable.Cast<BannerSection>(data.Result);
                }
                else
                {
                    sources = pageRetriever.RetrieveAsync<ContactusSource>(
                        query => query
                            .Published(true)
                            .OnSite(SiteContext.CurrentSiteName)
                             .Columns(cols)
                            .OrderByDescending(x => x.DocumentCreatedWhen)
                            .ToList(),
                        cache => cache
                            .Key($"{nameof(ContactusRepository)}|{nameof(GetContactusSource)}")
                            // Include path dependency to flush cache when a new child page is created or page order is changed.
                            .Dependencies((_, builder) => builder.PagePath("", PathTypeEnum.Children).PageOrder()),
                        new CancellationToken())?.Result.ToList();

                }

                if (sources != null && sources.Count > 0)
                {
                    foreach (var source in sources)
                    {
                        _sources.Add(ContactusSourceViewModel.GetModel(source));
                    }
                }

                return _sources;
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }
    }
}