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
    public class PageHeadRepository
    {
        private readonly IPageRetriever pageRetriever;
        private readonly BreadcrumbRepository breadcrumbRepository;
        private readonly CareerRepository careerRepository;
        private readonly bool enableCache;

        /// <summary>
        /// Constructor for inner page header to instanciate, initialized readonly instaces
        /// </summary>
        /// <param name="_pageRetriever"></param>
        /// <param name="_breadcrumbRepository"></param>
        public PageHeadRepository(IPageRetriever _pageRetriever,
                                  BreadcrumbRepository _breadcrumbRepository,
                                  CareerRepository _careerRepository)
        {
            pageRetriever = _pageRetriever;
            breadcrumbRepository = _breadcrumbRepository;
            careerRepository = _careerRepository;
            enableCache = SettingsKeyInfoProvider.GetBoolValue(SiteContext.CurrentSiteName + Constants.EnableCache);
        }

        /// <summary>
        /// Get inner page heading (banner) (for other then home page banner)
        /// </summary>
        /// <param name="pageClassName"></param>
        /// <param name="nodeAliasPath"></param>
        /// <returns></returns>
        public InnerPageHeadModel GetInnerPageHead(string pageClassName, string nodeAliasPath)
        {
            InnerPageHeadModel model = new InnerPageHeadModel();
            // Initializaton of InnerPageHead instance
            InnerPageHead innerPageHead = new InnerPageHead();
            try
            {
                //Set common query for cache and non cache condition 
                Action<DocumentQuery<InnerPageHead>> pageQuery =
                        query => query
                                .Columns(
                                    "SubTitle", "BannerTitle", "BannerImage", "NodeParentID"
                                )
                                .Path(nodeAliasPath, PathTypeEnum.Single)
                                .NestingLevel(1).FirstOrDefault();

                // Get inner page head detail from tree node
                if (pageClassName == InnerPageHead.CLASS_NAME)
                {
                    if (enableCache)
                    {
                        innerPageHead = pageRetriever.Retrieve(
                            pageQuery,
                            cache => cache
                                .Key($"{nameof(PageHeadRepository)}|{nameof(GetInnerPageHead)}|{nodeAliasPath}")
                                .Dependencies((_, builder) => builder.PagePath(nodeAliasPath, PathTypeEnum.Children))
                        ).FirstOrDefault();
                    }
                    else
                    {
                        innerPageHead = pageRetriever.Retrieve(
                           pageQuery
                        ).FirstOrDefault();
                    }
                }

                var pageModel = InnerPageHeadModel.GetModel(innerPageHead);

                pageModel.LstBreadcrumb = breadcrumbRepository.GetBreadcrumbs(innerPageHead.NodeParentID);

                return pageModel;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Get career page heading (banner) (for other then inner/home page banner)
        /// </summary>
        /// <param name="pageClassName"></param>
        /// <param name="nodeAliasPath"></param>
        /// <returns></returns>
        public CareerPageHeadModel GetCareerPageHead(string pageClassName, string nodeAliasPath)
        {
            CareerPageHeadModel model = new CareerPageHeadModel();
            // Initializaton of InnerPageHead instance
            CareerPageHead careerPageHead = new CareerPageHead();
            try
            {
                //Set common query for cache and non cache condition 
                Action<DocumentQuery<CareerPageHead>> pageQuery =
                        query => query
                                .Columns(
                                    "Description", "SubTitle", "BannerTitle", "BannerImage", "NodeParentID", "FormEnabled", "FormTitle", "ShortDescription"
                                )
                                .Path(nodeAliasPath, PathTypeEnum.Single)
                                .NestingLevel(1).FirstOrDefault();

                // Get inner page head detail from tree node
                if (pageClassName == CareerPageHead.CLASS_NAME)
                {
                    if (enableCache)
                    {
                        careerPageHead = pageRetriever.Retrieve(
                            pageQuery,
                            cache => cache
                                .Key($"{nameof(PageHeadRepository)}|{nameof(GetCareerPageHead)}|{nodeAliasPath}")
                                .Dependencies((_, builder) => builder.PagePath(nodeAliasPath, PathTypeEnum.Children))
                        ).FirstOrDefault();
                    }
                    else
                    {
                        careerPageHead = pageRetriever.Retrieve(
                           pageQuery
                        ).FirstOrDefault();
                    }
                }

                var pageModel = CareerPageHeadModel.GetModel(careerPageHead);

                pageModel.LstBreadcrumb = breadcrumbRepository.GetBreadcrumbs(careerPageHead.NodeParentID);

                pageModel.CurrentOpenings = careerRepository.GetCurrentOpenings(careerPageHead.Parent.Parent.NodeAliasPath);

                return pageModel;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Get general details of page
        /// </summary>
        /// <param name="nodeAliasPath"></param>
        /// <returns></returns>
        public GeneralInformationSectionModel GetPageGeneralInformationSectionData(string pageClassName, string nodeAliasPath)
        {
            GeneralInformationSectionModel model = new GeneralInformationSectionModel();
            // Initializaton of InnerPageHead instance
            GeneralInformationSection generalInformationSection = new GeneralInformationSection();
            try
            {
                //Set common query for cache and non cache condition 
                Action<DocumentQuery<GeneralInformationSection>> pageQuery =
                        query => query
                                .Columns(
                                    "Description", "NodeParentID"
                                )
                                .Path(nodeAliasPath, PathTypeEnum.Single)
                                .NestingLevel(1).FirstOrDefault();

                // Get inner page head detail from tree node
                if (pageClassName == GeneralInformationSection.CLASS_NAME)
                {
                    if (enableCache)
                    {
                        generalInformationSection = pageRetriever.Retrieve(
                            pageQuery,
                            cache => cache
                                .Key($"{nameof(PageHeadRepository)}|{nameof(GetPageGeneralInformationSectionData)}|{nodeAliasPath}")
                                .Dependencies((_, builder) => builder.PagePath(nodeAliasPath, PathTypeEnum.Children))
                        ).FirstOrDefault();
                    }
                    else
                    {
                        generalInformationSection = pageRetriever.Retrieve(
                           pageQuery
                        ).FirstOrDefault();
                    }
                }

                var pageModel = GeneralInformationSectionModel.GetModel(generalInformationSection);

                return pageModel;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        /// <summary>
        /// Get general details of page
        /// </summary>
        /// <param name="nodeAliasPath"></param>
        /// <returns></returns>
        public GeneralInformationSectionWithTitleModel GetPageGeneralInformationSectionWithTitleData(string pageClassName, string nodeAliasPath)
        {
            GeneralInformationSectionWithTitleModel model = new GeneralInformationSectionWithTitleModel();
            // Initializaton of InnerPageHead instance
            GeneralInformationSectionWithTitle generalInformationSection = new GeneralInformationSectionWithTitle();
            try
            {
                //Set common query for cache and non cache condition 
                Action<DocumentQuery<GeneralInformationSectionWithTitle>> pageQuery =
                        query => query
                                .Columns(
                                    "Title", "Description", "NodeParentID"
                                )
                                .Path(nodeAliasPath, PathTypeEnum.Single)
                                .NestingLevel(1).FirstOrDefault();

                // Get inner page head detail from tree node
                if (pageClassName == GeneralInformationSectionWithTitle.CLASS_NAME)
                {
                    if (enableCache)
                    {
                        generalInformationSection = pageRetriever.Retrieve(
                            pageQuery,
                            cache => cache
                                .Key($"{nameof(PageHeadRepository)}|{nameof(GetPageGeneralInformationSectionWithTitleData)}|{nodeAliasPath}")
                                .Dependencies((_, builder) => builder.PagePath(nodeAliasPath, PathTypeEnum.Children))
                        ).FirstOrDefault();
                    }
                    else
                    {
                        generalInformationSection = pageRetriever.Retrieve(
                           pageQuery
                        ).FirstOrDefault();
                    }
                }

                var pageModel = GeneralInformationSectionWithTitleModel.GetModel(generalInformationSection);

                return pageModel;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}