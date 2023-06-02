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
    public partial class TilesRepository
    {
        private readonly IPageRetriever pageRetriever;
        private readonly RepositoryCacheHelper repositoryCacheHelper;

        /// <summary>
        /// Initializes a new instance of the <see cref="HomeRepository"/> class that returns home page sections. 
        /// </summary>
        /// <param name="pageRetriever">Retriever for pages based on given parameters.</param>
        public TilesRepository(IPageRetriever pageRetriever,
            RepositoryCacheHelper _repositoryCacheHelper)
        {
            this.pageRetriever = pageRetriever;
            this.repositoryCacheHelper = _repositoryCacheHelper;
        }

        public TileContainerModel GetHomePageTiles()
        {
            try
            {
                bool enableCache = SettingsKeyInfoProvider.GetBoolValue(SiteContext.CurrentSiteName + ".EnableCache");
                string[] cols = { "Name", "ImageAltText", "ImageURL", "Title", "ContentText", "ButtonText", "ButtonRedirectURL", "ThemesColor" };

                var tileList = new List<Tiles>();
                var tiles = new TileContainerModel();

                if (!enableCache)
                {
                    //IEnumerable<BannerSection> related = Enumerable.Empty<BannerSection>();
                    tileList = pageRetriever.RetrieveAsync<Tiles>(
                        query => query
                            .Published(true)
                            .OnSite(SiteContext.CurrentSiteName)
                            .Columns(cols)
                            .TopN(2)
                            .OrderByDescending(x => x.DocumentCreatedWhen)
                            .ToList())?.Result.ToList();
                    //related = Enumerable.Cast<BannerSection>(data.Result);
                }
                else
                {
                    tileList = pageRetriever.RetrieveAsync<Tiles>(
                        query => query
                            .Published(true)
                            .OnSite(SiteContext.CurrentSiteName)
                            .Columns(cols)
                             .TopN(2)
                            .OrderByDescending(x => x.DocumentCreatedWhen)
                            .ToList(),
                        cache => cache
                            .Key($"{nameof(TilesRepository)}|{nameof(GetHomePageTiles)}")
                            // Include path dependency to flush cache when a new child page is created or page order is changed.
                            .Dependencies((_, builder) => builder.PagePath("", PathTypeEnum.Children).PageOrder()),
                        new CancellationToken())?.Result.ToList();

                }

                if (tileList != null && tileList.Count > 0)
                {
                    tiles.Tiles = new List<TileViewModel>();
                    foreach (var tile in tileList)
                    {
                        tiles.Tiles.Add(TileViewModel.GetModel(tile));
                    }
                }

                return tiles;
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }
    }
}

