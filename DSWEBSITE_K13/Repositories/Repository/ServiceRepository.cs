using CMS.DataEngine;
using CMS.DocumentEngine;
using CMS.DocumentEngine.Types.DotStarK;
using CMS.SiteProvider;
using DSWEBSITE_K13.Components.ViewComponents;
using DSWEBSITE_K13.Models;
using Kentico.Content.Web.Mvc;
using System;
using System.Linq;

namespace DSWEBSITE_K13.Repositories.Repository
{
    public class ServiceRepository
    {
        private readonly IPageRetriever pageRetriever;
        private readonly bool enableCache;

        /// <summary>
        /// Constructor for services to instanciate, initialized readonly instaces
        /// </summary>
        /// <param name="_pageRetriever"></param>
        public ServiceRepository(IPageRetriever _pageRetriever)
        {
            pageRetriever = _pageRetriever;
            enableCache = SettingsKeyInfoProvider.GetBoolValue(SiteContext.CurrentSiteName + Constants.EnableCache);
        }

        /// <summary>
        /// Get all servie sections
        /// </summary>
        /// <param name="pageClassName"></param>
        /// <param name="nodeAliasPath"></param>
        /// <returns></returns>
        public ServiceSectionModel GetServices(string pageClassName, string nodeAliasPath)
        {
            //Columns to retrive from the ServiceSection page type
            string[] cols = { "Name", "Description", "Image", "IsCategoryBreadcrumbs" };

            try
            {
                ServiceSectionModel model = new ServiceSectionModel();
                // Initializaton of InnerPageHead instance
                ServiceSection serviceSection = new ServiceSection();


                //Set common query for cache and non cache condition 
                Action<DocumentQuery<ServiceSection>> pageQuery =
                        query => query
                                .Columns(cols)
                                .Path(nodeAliasPath, PathTypeEnum.Single)
                                .NestingLevel(1).FirstOrDefault();

                // Get inner page head detail from tree node
                if (pageClassName == ServiceSection.CLASS_NAME)
                {
                    if (enableCache)
                    {
                        serviceSection = pageRetriever.Retrieve(
                            pageQuery,
                            cache => cache
                                .Key($"{nameof(PageHeadRepository)}|{nameof(GetServices)}|{nodeAliasPath}")
                                .Dependencies((_, builder) => builder.PagePath(nodeAliasPath, PathTypeEnum.Children))
                        ).FirstOrDefault();
                    }
                    else
                    {
                        serviceSection = pageRetriever.Retrieve(
                           pageQuery
                        ).FirstOrDefault();
                    }
                }

                var pageModel = ServiceSectionModel.GetModel(serviceSection);

                return pageModel;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
