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

namespace DSWEBSITE_K13.Repositories.Repository
{
    public class TopSectionRepository
    {

        private readonly IPageRetriever pageRetriever;
        private readonly bool enableCache;

        /// <summary>
        /// Constructor for Top Section of home page will instanciate, initialized readonly instaces
        /// </summary>
        /// <param name="pageRetriever"></param>
        public TopSectionRepository(IPageRetriever pageRetriever)
        {
            this.pageRetriever = pageRetriever;
            this.enableCache = SettingsKeyInfoProvider.GetBoolValue(SiteContext.CurrentSiteName + Constants.EnableCache);
        }

        public TopSectionModel GetTopSection(string nodeAliasPath, string pageClassName)
        {
            TopSectionModel model = new TopSectionModel();
            // Initializaton of InnerPageHead instance
            TopSection topSection = new TopSection();
            try
            {
                //Set common query for cache and non cache condition 
                Action<DocumentQuery<TopSection>> pageQuery =
                        query => query
                                .Columns(
                                    "ImageURL", "ImageAltText", "ClientCaptionText", "ClientCaptionCount",
                                    "ButtonHoverText", "ButtonRedirectURL", "ButtonText", "HeadingContentText",
                                    "MainTitle"
                                )
                                .Path(nodeAliasPath, PathTypeEnum.Single)
                                .NestingLevel(1).FirstOrDefault();

                // Get inner page head detail from tree node
                if (pageClassName == TopSection.CLASS_NAME)
                {
                    if (enableCache)
                    {
                        topSection = pageRetriever.Retrieve(
                            pageQuery,
                            cache => cache
                                .Key($"{nameof(PageHeadRepository)}|{nameof(GetTopSection)}|{nodeAliasPath}")
                                .Dependencies((_, builder) => builder.PagePath(nodeAliasPath, PathTypeEnum.Children))
                        ).FirstOrDefault();
                    }
                    else
                    {
                        topSection = pageRetriever.Retrieve(
                           pageQuery
                        ).FirstOrDefault();
                    }
                }

                //Bind model data from kentico page
                var pageModel = TopSectionModel.GetModel(topSection);
                pageModel.BrandList = GetTopSectionBrands(topSection.NodeAliasPath);

                return pageModel;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private List<LinkIconViewModel> GetTopSectionBrands(string nodeAliasPath)
        {
            List<LinkIconViewModel> pageModel = new List<LinkIconViewModel>();
            // Initializaton of InnerPageHead instance
            List<LinkIcon> brands = new List<LinkIcon>();
            try
            {
                //Set common query for cache and non cache condition 
                Action<DocumentQuery<LinkIcon>> pageQuery =
                        query => query
                                .Columns(
                                    "IconAltText", "Icon", "IconUrl", "NodeParentID"
                                )
                                .Path(nodeAliasPath, PathTypeEnum.Children)
                                .ToList();

                // Get inner page head detail from tree node

                if (enableCache)
                {
                    brands = pageRetriever.Retrieve(
                        pageQuery,
                        cache => cache
                            .Key($"{nameof(PageHeadRepository)}|{nameof(GetTopSectionBrands)}|{nodeAliasPath}")
                            .Dependencies((_, builder) => builder.PagePath(nodeAliasPath, PathTypeEnum.Children))
                    ).ToList();
                }
                else
                {
                    brands = pageRetriever.Retrieve(
                       pageQuery
                    ).ToList();
                }

                //Bind model data from kentico page
                foreach (var brand in brands)
                {
                    pageModel.Add(LinkIconViewModel.GetViewModel(brand));
                }

                return pageModel;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
