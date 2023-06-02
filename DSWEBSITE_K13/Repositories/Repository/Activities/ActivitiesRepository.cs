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
    public class ActivitiesRepository
    {
        private readonly IPageRetriever pageRetriever;
        private readonly bool enableCache;

        /// <summary>
        /// Constructor for inner page section to instanciate, initialized readonly instaces
        /// </summary>
        /// <param name="_pageRetriever"></param>
        public ActivitiesRepository(IPageRetriever _pageRetriever)
        {
            pageRetriever = _pageRetriever;
            enableCache = SettingsKeyInfoProvider.GetBoolValue(SiteContext.CurrentSiteName + Constants.EnableCache);
        }

        public List<ActivitiesModel> GetActivities(string parentNodeAlias)
        {
            //Columns to retrive from the activities page type
            string[] cols = { "Name", "Date", "Image", "NodeOrder" };

            List<ActivitiesModel> pageModel = new List<ActivitiesModel>();
            List<Activities> activities = new List<Activities>();
            try
            {

                //Set common query for cache and non cache condition 
                Action<DocumentQuery<Activities>> pageQuery =
                        query => query
                                .Columns(cols)
                                .Path(parentNodeAlias, PathTypeEnum.Children)
                                .OrderBy("NodeOrder")
                                .ToList();

                // Get inner page section from tree node
                if (enableCache)
                {
                    activities = pageRetriever.Retrieve(
                            pageQuery,
                            cache => cache
                                .Key($"{nameof(ActivitiesRepository)}|{nameof(GetActivities)}|{parentNodeAlias}")
                                .Dependencies((_, builder) => builder.PagePath(parentNodeAlias, PathTypeEnum.Children))
                        ).ToList();
                }
                else
                {
                    activities = pageRetriever.Retrieve(
                           pageQuery
                        ).ToList();
                }

                foreach (var activity in activities)
                {
                   // pageModel.Add(ActivitiesModel.GetModel(activity,attachmentUrlRetriever));
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return pageModel;
        }
    }
}
