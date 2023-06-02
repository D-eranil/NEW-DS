using CMS.DataEngine;
using CMS.DocumentEngine;
using CMS.DocumentEngine.Types.DotStarK;
using CMS.SiteProvider;
using DSWEBSITE_K13.Components.ViewComponents;
using DSWEBSITE_K13.Models;
using Kentico.Content.Web.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DSWEBSITE_K13.Repositories.Repository
{
    public class ExpertRepository
    {
        private readonly IPageRetriever pageRetriever;
        private readonly bool enableCache;

        /// <summary>
        /// Constructor for expert to instanciate, initialized readonly instaces
        /// </summary>
        /// <param name="_pageRetriever"></param>
        public ExpertRepository(IPageRetriever _pageRetriever)
        {
            pageRetriever = _pageRetriever;
            enableCache = SettingsKeyInfoProvider.GetBoolValue(SiteContext.CurrentSiteName + Constants.EnableCache);
        }

        /// <summary>
        /// Get expertise for home page
        /// </summary>
        /// <param name="pageClassName"></param>
        /// <param name="nodeAliasPath"></param>
        /// <returns></returns>
        public ExpertContainerModel GetHomePageExperties(string pageClassName, string nodeAliasPath)
        {

            ExpertContainerModel model = new ExpertContainerModel();
            // Initializaton of InnerPageHead instance
            ExpertContainer expertise = new ExpertContainer();
            try
            {
                // Get inner page head detail from tree node
                if (pageClassName == ExpertContainer.CLASS_NAME)
                {
                    //Set common query for cache and non cache condition 
                    Action<DocumentQuery<ExpertContainer>> pageQuery =
                        query => query
                                .Path(nodeAliasPath, PathTypeEnum.Single)
                                .NestingLevel(1)
                                .FirstOrDefault();


                    if (enableCache)
                    {
                        expertise = pageRetriever.Retrieve(
                            pageQuery,
                            cache => cache
                                .Key($"{nameof(ExpertRepository)}|{nameof(GetHomePageExperties)}|{nodeAliasPath}")
                                .Dependencies((_, builder) => builder.PagePath(nodeAliasPath, PathTypeEnum.Single))
                        ).FirstOrDefault();
                    }
                    else
                    {
                        expertise = pageRetriever.Retrieve(
                           pageQuery
                        ).FirstOrDefault();
                    }
                }
                model.Experties = new List<ExpertModel>();
                foreach (var item in expertise.Fields.Expertise)
                {
                    model.Experties.Add(ExpertModel.GetHomeModel(item));
                }

                return model;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Get expertise details for expertise page
        /// </summary>
        /// <param name="pageClassName"></param>
        /// <param name="nodeAliasPath"></param>
        /// <returns></returns>
        public ExpertModel GetExperties(string pageClassName, string nodeAliasPath)
        {
            string[] cols = { "Name", "ShortDescription", "Points", "Image", "IsCategoryBreadcrumbs", "NodeOrder", "ThemesColor" };

            ExpertModel model = new ExpertModel();
            // Initializaton of Expert instance
            Expert expertise = new Expert();

            try
            {
                // Get expert page detail from tree node page alias
                if (pageClassName == Expert.CLASS_NAME)
                {
                    //Set common query for cache and non cache condition 
                    Action<DocumentQuery<Expert>> pageQuery =
                        query => query
                                .Columns(cols)
                                .Path(nodeAliasPath, PathTypeEnum.Single)
                                .OrderBy("NodeOrder");


                    if (enableCache)
                    {
                        expertise = pageRetriever.Retrieve(
                            pageQuery,
                            cache => cache
                                .Key($"{nameof(ExpertRepository)}|{nameof(GetExperties)}|{nodeAliasPath}")
                                .Dependencies((_, builder) => builder.PagePath(nodeAliasPath, PathTypeEnum.Single))
                        ).FirstOrDefault();
                    }
                    else
                    {
                        expertise = pageRetriever.Retrieve(
                           pageQuery
                        ).FirstOrDefault();
                    }
                }
                model = ExpertModel.GetExperties(expertise);

                return model;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
