using CMS.DocumentEngine.Types.DotStarK;
using DSWEBSITE_K13.Libraries.Infrastructure;
using Kentico.Content.Web.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DSWEBSITE_K13.Repositories
{
    public partial class LayoutRepository : ILayoutRepository
    {


        private readonly IPageRetriever pageRetriever;
        private readonly RepositoryCacheHelper repositoryCacheHelper;

        /// <summary>
        /// Initializes a new instance of the <see cref="HomeRepository"/> class that returns home page sections. 
        /// </summary>
        /// <param name="pageRetriever">Retriever for pages based on given parameters.</param>
        internal LayoutRepository(IPageRetriever pageRetriever,
            RepositoryCacheHelper _repositoryCacheHelper)
        {
            this.pageRetriever = pageRetriever;
            this.repositoryCacheHelper = _repositoryCacheHelper;
        }

        //public LayoutRepository()
        //{

        //}
        //public IEnumerable<LinkIcon> GetLinkIcon(string NodeAliasPath, bool DisableCache)
        //{
        //    return RepositoryCacheHelper.CacheObjects(() =>
        //    {
        //        IEnumerable<LinkIcon> related = BannerSectionProvider.GetBannerSections()
        //            .Path(NodeAliasPath, PathTypeEnum.Children)
        //            .Published(true)
        //            .OnSite(SiteContext.CurrentSiteName)
        //            //.CombineWithDefaultCulture()
        //            .OrderBy("NodeOrder")
        //            .TopN(3)
        //            .Where(x => x.IsActiveBanner == true)
        //            .ToList().AsEnumerable();

        //        return related;

        //    }, $"{nameof(HomeRepository)}|{nameof(GetBanners)}|{NodeAliasPath}", new[]
        //   {
        //        $"nodeid|{NodeAliasPath}",
        //        $"nodeid|{NodeAliasPath}|relationships"
        //    });
        //}
    }


}
