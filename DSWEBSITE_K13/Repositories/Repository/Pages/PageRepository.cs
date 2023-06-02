using CMS.DocumentEngine;
using CMS.DocumentEngine.Types.DotStarK;
using CMS.SiteProvider;
using DSWEBSITE_K13.Libraries.Infrastructure;
using Kentico.Content.Web.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace DSWEBSITE_K13.Repositories.Repository
{
    public interface IPageRepository
    {

    }

    public partial class PageRepository : IPageRepository
    {
        private readonly IPageRetriever pageRetriever;
        private readonly RepositoryCacheHelper repositoryCacheHelper;

        /// <summary>
        /// Initializes a new instance of the <see cref="HomeRepository"/> class that returns home page sections. 
        /// </summary>
        /// <param name="pageRetriever">Retriever for pages based on given parameters.</param>
        internal PageRepository(IPageRetriever pageRetriever,
            RepositoryCacheHelper _repositoryCacheHelper)
        {
            this.pageRetriever = pageRetriever;
            this.repositoryCacheHelper = _repositoryCacheHelper;
        }

        public Task<IEnumerable<Blogs>> GetHeaders(string nodeAliasPath, bool disableCache, CancellationToken cancellationToken)
        {
            try
            {
                if (disableCache)
                {
                    //IEnumerable<BannerSection> related = Enumerable.Empty<BannerSection>();
                    return pageRetriever.RetrieveAsync<Blogs>(
                        query => query
                            .Path(nodeAliasPath, PathTypeEnum.Children)
                            .Published(true)
                            .OnSite(SiteContext.CurrentSiteName)
                            //.CombineWithDefaultCulture()
                            .TopN(5)
                            .OrderBy("NodeOrder")
                            .ToList());
                    //related = Enumerable.Cast<BannerSection>(data.Result);
                }
                else
                {
                    var data = pageRetriever.RetrieveAsync<Blogs>(
                        query => query
                            .Path(nodeAliasPath, PathTypeEnum.Children)
                            .Published(true)
                            .OnSite(SiteContext.CurrentSiteName)
                            //.CombineWithDefaultCulture()
                            .OrderBy("NodeOrder")
                            .ToList(),
                        cache => cache
                            .Key($"{nameof(PageRepository)}|{nameof(GetHeaders)}|{nodeAliasPath}")
                            // Include path dependency to flush cache when a new child page is created or page order is changed.
                            .Dependencies((_, builder) => builder.PagePath(nodeAliasPath, PathTypeEnum.Children).PageOrder()),
                        cancellationToken);
                    return data;
                }
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }
    }
}
