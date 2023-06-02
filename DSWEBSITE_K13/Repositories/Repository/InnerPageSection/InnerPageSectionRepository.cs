using CMS.DataEngine;
using CMS.DocumentEngine;
using CMS.DocumentEngine.Types.DotStarK;
using CMS.SiteProvider;
using DSWEBSITE_K13.Components.ViewComponents;
using DSWEBSITE_K13.Models;
using DSWEBSITE_K13.Models.ViewModels;
using Kentico.Content.Web.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace DSWEBSITE_K13.Repositories.Repository
{
    public class InnerPageSectionRepository
    {
        private readonly IPageRetriever pageRetriever;
        private readonly bool enableCache;
        private readonly ActivitiesRepository activitiesRepository;

        // Contains an instance of the IPageAttachmentUrlRetriever  service (e.g., obtained via dependency injection)
        private readonly IPageAttachmentUrlRetriever attachmentUrlRetriever;

        /// <summary>
        /// Constructor for inner page section to instanciate, initialized readonly instaces
        /// </summary>
        /// <param name="_pageRetriever"></param>
        /// <param name="_activitiesRepository"></param>
        public InnerPageSectionRepository(IPageRetriever _pageRetriever, ActivitiesRepository _activitiesRepository, IPageAttachmentUrlRetriever _attachmentUrlRetriever)
        {
            pageRetriever = _pageRetriever;
            activitiesRepository = _activitiesRepository;
            attachmentUrlRetriever = _attachmentUrlRetriever;
            enableCache = SettingsKeyInfoProvider.GetBoolValue(SiteContext.CurrentSiteName + Constants.EnableCache);
        }

        public InnerPageSectionModel GetInnerPageSection(string nodeAliasPath)
        {
            //Columns to retrive from the InnerPageSection page type
            string[] cols = { "DocumentName", "Title", "Description", "Image", "IsH3Section","NodeOrder",
                    "ThemesColor", "IsCategoryBreadcrumbs","NodeAliasPath" };

            InnerPageSectionModel pageModel = new InnerPageSectionModel();
            InnerPageSection innerPageSection = new InnerPageSection();
            try
            {
                //Set common query for cache and non cache condition 
                Action<DocumentQuery<InnerPageSection>> pageQuery =
                        query => query
                                .Columns(cols)
                                .Path(nodeAliasPath, PathTypeEnum.Single)
                                .NestingLevel(1)
                                .OrderBy("NodeOrder")
                                .FirstOrDefault();

                // Get inner page section from tree node
                if (enableCache)
                {
                    innerPageSection = pageRetriever.Retrieve(
                            pageQuery,
                            cache => cache
                                .Key($"{nameof(InnerPageSectionRepository)}|{nameof(GetInnerPageSection)}|{nodeAliasPath}")
                                .Dependencies((_, builder) => builder.PagePath(nodeAliasPath, PathTypeEnum.Single))
                        ).FirstOrDefault();
                }
                else
                {
                    innerPageSection = pageRetriever.Retrieve(
                           pageQuery
                        ).FirstOrDefault();
                }
                pageModel = InnerPageSectionModel.GetModel(innerPageSection);
                pageModel.Activities = activitiesRepository.GetActivities(innerPageSection.NodeAliasPath);

                //Industrries
                var industries = GetIndustryLinks(innerPageSection.NodeAliasPath);
                if (industries != null && industries.Count > 0)
                {

                    pageModel.Industries = new List<LinkItemViewModel>();
                    foreach (var industry in industries)
                    {
                        pageModel.Industries.Add(industry);
                    }
                }
                else
                {
                    pageModel.Industries = new List<LinkItemViewModel>();
                }

                //Strengths
                var strengths = GetStrengthLinks(innerPageSection.NodeAliasPath);
                if (strengths != null && strengths.Count > 0)
                {
                    pageModel.Strengths = new List<StrengthViewModel>();
                    foreach (var strength in strengths)
                    {
                        pageModel.Strengths.Add(strength);
                    }
                }
                else
                {
                    pageModel.Strengths = new List<StrengthViewModel>();
                }

                //Activities
                var activities = GetActivities(innerPageSection.NodeAliasPath, attachmentUrlRetriever);
                if (activities != null && activities.Count > 0)
                {
                    pageModel.Activities = new List<ActivitiesModel>();
                    foreach (var activity in activities)
                    {
                        pageModel.Activities.Add(activity);
                    }
                }
                else
                {
                    pageModel.Activities = new List<ActivitiesModel>();
                }

                return pageModel;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<LinkItemViewModel> GetIndustryLinks(string nodeAliasPath)
        {
            List<LinkItemViewModel> linkModel = new List<LinkItemViewModel>();
            List<LinkItem> linkPages = new List<LinkItem>();
           
            try
            {
                Action<DocumentQuery<LinkItem>> pageQuery = query => query.Published(true)
                           .OnSite(SiteContext.CurrentSiteName)
                           .Columns(
                                "LinkItemText", "LinkItemUrl", "NodeOrder"
                           )
                           .OrderBy("NodeOrder")
                           .Path(nodeAliasPath, PathTypeEnum.Children)
                           .ToList();

                if (enableCache)
                {
                    linkPages = pageRetriever.RetrieveAsync(
                        pageQuery,
                        cache => cache
                            .Key($"{nameof(InnerPageSectionRepository)}|{nameof(GetIndustryLinks)}|{nodeAliasPath}")
                            // Include path dependency to flush cache when a new child page is created or page order is changed.
                            .Dependencies((_, builder) => builder.PagePath(nodeAliasPath, PathTypeEnum.Children).PageOrder()),
                        new CancellationToken())?.Result.ToList();
                }
                else
                {
                    linkPages = pageRetriever.RetrieveAsync(
                        pageQuery)?.Result.ToList();
                }

                //bind local model
                foreach (var linkItem in linkPages)
                {
                    linkModel.Add(LinkItemViewModel.GetModel(linkItem));
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }


            return linkModel;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<StrengthViewModel> GetStrengthLinks(string nodeAliasPath)
        {
            List<StrengthViewModel> strengths = new List<StrengthViewModel>();
            List<Strength> _strengths = new List<Strength>();
            try
            {
                Action<DocumentQuery<Strength>> pageQuery = query => query.Published(true)
                           .OnSite(SiteContext.CurrentSiteName)
                           .Columns(
                                "Name", "ShortDescription", "NodeOrder"
                           )
                           .OrderBy("NodeOrder")
                           .Path(nodeAliasPath, PathTypeEnum.Children)
                           .ToList();

                if (enableCache)
                {
                    _strengths = pageRetriever.RetrieveAsync(
                        pageQuery,
                        cache => cache
                            .Key($"{nameof(InnerPageSectionRepository)}|{nameof(GetStrengthLinks)}|{nodeAliasPath}")
                            // Include path dependency to flush cache when a new child page is created or page order is changed.
                            .Dependencies((_, builder) => builder.PagePath(nodeAliasPath, PathTypeEnum.Children).PageOrder()),
                        new CancellationToken())?.Result.ToList();
                }
                else
                {
                    _strengths = pageRetriever.RetrieveAsync(
                        pageQuery)?.Result.ToList();
                }

                //bind local model
                foreach (var _strength in _strengths)
                {
                    strengths.Add(StrengthViewModel.GetModel(_strength));
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }


            return strengths;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="parentNodeAlias"></param>
        /// <returns></returns>
        public List<ActivitiesModel> GetActivities(string parentNodeAlias, IPageAttachmentUrlRetriever attachmentUrlRetriever)
        {
            //Columns to retrive from the activities page type
            string[] cols = { "Name", "Date", "Image", "ActivitySliderName", "Attachments", "NodeOrder" };

            List<ActivitiesModel> pageModel = new List<ActivitiesModel>();
            List<Activities> activities = new List<Activities>();
            try
            {

                //Set common query for cache and non cache condition 
                Action<DocumentQuery<Activities>> pageQuery =
                        query => query
                                .Columns(cols)
                                .Path(parentNodeAlias, PathTypeEnum.Children)
                                .Published(true)
                                .OrderBy("NodeOrder")
                                .ToList();

                // Get inner page section from tree node
                if (enableCache)
                {
                    activities = pageRetriever.Retrieve(
                            pageQuery,
                            cache => cache
                                .Key($"{nameof(InnerPageSectionRepository)}|{nameof(GetActivities)}|{parentNodeAlias}")
                                .Dependencies((_, builder) => builder.PagePath(parentNodeAlias, PathTypeEnum.Children))
                        ).ToList();
                }
                else
                {
                    activities = pageRetriever.Retrieve(
                           pageQuery
                        ).ToList();
                }
                int group = 1;
                int count = 0;
                foreach (var activity in activities)
                {
                    var activitiesModel = ActivitiesModel.GetModel(activity, attachmentUrlRetriever);
                    activitiesModel.Group = group;
                    pageModel.Add(activitiesModel);
                    count++;
                    if(count == 4)
                        group++;

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
