using CMS.CustomTables;
using CMS.CustomTables.Types.DotStarK;
using CMS.DataEngine;
using CMS.DocumentEngine;
using CMS.DocumentEngine.Types.DotStarK;
using CMS.Helpers;
using CMS.SiteProvider;
using DSWEBSITE_K13.Components.ViewComponents;
using DSWEBSITE_K13.Models;
using DSWEBSITE_K13.Models.ViewModels;
using Kentico.Content.Web.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace DSWEBSITE_K13.Repositories.Repository
{
    public class CareerRepository
    {
        private readonly IPageRetriever pageRetriever;
        private readonly bool enableCache;

        /// <summary>
        /// Constructor for career to instanciate, initialized readonly instaces
        /// </summary>
        /// <param name="_pageRetriever"></param>
        public CareerRepository(IPageRetriever _pageRetriever)
        {
            pageRetriever = _pageRetriever;
            enableCache = SettingsKeyInfoProvider.GetBoolValue(SiteContext.CurrentSiteName + Constants.EnableCache);
        }

        /// <summary>
        /// Get career details for career page
        /// </summary>
        /// <param name="pageClassName"></param>
        /// <param name="nodeAliasPath"></param>
        /// <returns></returns>
        public CareerModel GetCareer(string pageClassName, string nodeAliasPath)
        {
            string[] cols = { "Title" };

            CareerModel model = new CareerModel();
            // Initializaton of Expert instance
            Career career = new Career();

            try
            {
                // Get career page detail from tree node page alias
                if (pageClassName == Career.CLASS_NAME)
                {
                    //Set common query for cache and non cache condition 
                    Action<DocumentQuery<Career>> pageQuery =
                        query => query
                                .Columns(cols)
                                .Path(nodeAliasPath, PathTypeEnum.Single)
                                .OrderBy("NodeOrder");


                    if (enableCache)
                    {
                        career = pageRetriever.Retrieve(
                            pageQuery,
                            cache => cache
                                .Key($"{nameof(CareerRepository)}|{nameof(GetCareer)}|{nodeAliasPath}")
                                .Dependencies((_, builder) => builder.PagePath(nodeAliasPath, PathTypeEnum.Single))
                        ).FirstOrDefault();
                    }
                    else
                    {
                        career = pageRetriever.Retrieve(
                           pageQuery
                        ).FirstOrDefault();
                    }
                }
                model = CareerModel.GetCareerModel(career);

                return model;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Get current opening details for career page
        /// </summary>
        /// <param name="nodeAliasPath"></param>
        /// <returns></returns>
        public List<CareerOpeningModel> GetCurrentOpenings(string nodeAliasPath)
        {
            string[] cols = { "Name", "OpeningTitle", "Location", "RemoteWork", "NoOfVaccancies", "Description" };

            List<CareerOpeningModel> model = new List<CareerOpeningModel>();
            // Initializaton of Expert instance
            List<CareerOpening> careerOpening = new List<CareerOpening>();

            try
            {
                //Set common query for cache and non cache condition 
                Action<DocumentQuery<CareerOpening>> pageQuery =
                    query => query
                            .Columns(cols)
                            .Path(nodeAliasPath, PathTypeEnum.Children)
                            .OrderBy("NodeOrder");

                if (enableCache)
                {
                    careerOpening = pageRetriever.Retrieve(
                        pageQuery,
                        cache => cache
                            .Key($"{nameof(CareerRepository)}|{nameof(GetCurrentOpenings)}|{nodeAliasPath}")
                            .Dependencies((_, builder) => builder.PagePath(nodeAliasPath, PathTypeEnum.Single))
                    ).ToList();
                }
                else
                {
                    careerOpening = pageRetriever.Retrieve(
                       pageQuery
                    ).ToList();
                }

                model = careerOpening.Select(cOpening => CareerOpeningModel
                                                        .GetCareerOpenings(cOpening))
                                                        .ToList();

                return model;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        /// <summary>
        /// Get all career sections
        /// </summary>
        /// <param name="pageClassName"></param>
        /// <param name="nodeAliasPath"></param>
        /// <returns></returns>
        public CareerSectionModel GetCareerSection(string pageClassName, string nodeAliasPath)
        {
            //Columns to retrive from the ServiceSection page type
            string[] cols = { "Name", "Description", "Image", "ImageLocation", "IsCategoryBreadcrumbs" };

            try
            {
                CareerSectionModel model = new CareerSectionModel();
                // Initializaton of InnerPageHead instance
                CareerSection careerSection = new CareerSection();


                //Set common query for cache and non cache condition 
                Action<DocumentQuery<CareerSection>> pageQuery =
                        query => query
                                .Columns(cols)
                                .Path(nodeAliasPath, PathTypeEnum.Single)
                                .NestingLevel(1).FirstOrDefault();

                // Get inner page head detail from tree node
                if (pageClassName == CareerSection.CLASS_NAME)
                {
                    if (enableCache)
                    {
                        careerSection = pageRetriever.Retrieve(
                            pageQuery,
                            cache => cache
                                .Key($"{nameof(PageHeadRepository)}|{nameof(GetCareerSection)}|{nodeAliasPath}")
                                .Dependencies((_, builder) => builder.PagePath(nodeAliasPath, PathTypeEnum.Children))
                        ).FirstOrDefault();
                    }
                    else
                    {
                        careerSection = pageRetriever.Retrieve(
                           pageQuery
                        ).FirstOrDefault();
                    }
                }

                var pageModel = CareerSectionModel.GetModel(careerSection);

                return pageModel;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        /// <summary>
        /// Get career values sections
        /// </summary>
        /// <param name="pageClassName"></param>
        /// <param name="nodeAliasPath"></param>
        /// <returns></returns>
        public CareerValuesSectionModel GetCareerValuesSection(string pageClassName, string nodeAliasPath)
        {
            //Columns to retrive from the ServiceSection page type
            string[] cols = { "Name", "Description", "Image", "IsCategoryBreadcrumbs" };

            try
            {
                CareerValuesSectionModel model = new CareerValuesSectionModel();
                // Initializaton of InnerPageHead instance
                CareerValuesSection careerValuesSection = new CareerValuesSection();


                //Set common query for cache and non cache condition 
                Action<DocumentQuery<CareerValuesSection>> pageQuery =
                        query => query
                                .Columns(cols)
                                .Path(nodeAliasPath, PathTypeEnum.Single)
                                .NestingLevel(1).FirstOrDefault();

                // Get inner page head detail from tree node
                if (pageClassName == CareerValuesSection.CLASS_NAME)
                {
                    if (enableCache)
                    {
                        careerValuesSection = pageRetriever.Retrieve(
                            pageQuery,
                            cache => cache
                                .Key($"{nameof(PageHeadRepository)}|{nameof(GetCareerValuesSection)}|{nodeAliasPath}")
                                .Dependencies((_, builder) => builder.PagePath(nodeAliasPath, PathTypeEnum.Children))
                        ).FirstOrDefault();
                    }
                    else
                    {
                        careerValuesSection = pageRetriever.Retrieve(
                           pageQuery
                        ).FirstOrDefault();
                    }
                }

                var pageModel = CareerValuesSectionModel.GetModel(careerValuesSection);

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
        public CareerCurrentOpeningModel GetCareerCurrentOpeningData(string pageClassName, string nodeAliasPath)
        {
            CareerCurrentOpeningModel model = new CareerCurrentOpeningModel();
            // Initializaton of InnerPageHead instance
            CareerCurrentOpening generalInformationSection = new CareerCurrentOpening();
            try
            {
                //Set common query for cache and non cache condition 
                Action<DocumentQuery<CareerCurrentOpening>> pageQuery =
                        query => query
                                .Columns(
                                    "Title", "Description", "NodeParentID"
                                )
                                .Path(nodeAliasPath, PathTypeEnum.Single)
                                .NestingLevel(1).FirstOrDefault();

                // Get inner page head detail from tree node
                if (pageClassName == CareerCurrentOpening.CLASS_NAME)
                {
                    if (enableCache)
                    {
                        generalInformationSection = pageRetriever.Retrieve(
                            pageQuery,
                            cache => cache
                                .Key($"{nameof(PageHeadRepository)}|{nameof(GetCareerCurrentOpeningData)}|{nodeAliasPath}")
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

                var pageModel = CareerCurrentOpeningModel.GetModel(generalInformationSection);

                return pageModel;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Get 
        /// </summary>
        /// <returns></returns>
        public List<YearOfExperienceModel> GetYearOfExperience()
        {
            try
            {

                string[] cols = { "NumberOfYears"};

                var years = new List<CustomTableItem>();
                var _years = new List<YearOfExperienceModel>();

                // Prepares the code name (class name) of the custom table
                string customTableClassName = "DotStarK.YearOfExperience";

                // Gets the custom table
                DataClassInfo customTable = DataClassInfoProvider.GetDataClassInfo(customTableClassName);
                if (customTable != null)
                {
                    years = CustomTableItemProvider.GetItems(customTableClassName).Columns(cols)
                                                        //.WhereEquals("NumberOfYears", "NumberOfYears")
                                                        .ToList();
                }

                if (years != null && years.Count > 0)
                {
                    foreach (var year in years)
                    {
                        string item = ValidationHelper.GetString(year.GetValue("NumberOfYears"), "");
                        _years.Add(new YearOfExperienceModel() { Key = item, Value = item });
                    }
                }

                return _years;
            }
            catch (System.Exception ex)
            {
                EventLogManager.LogError(ex.Source, "100000013", ex.Message);
                throw ex;
            }
        }
    }
}
