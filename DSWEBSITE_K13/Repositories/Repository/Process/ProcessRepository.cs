using CMS.DataEngine;
using CMS.DocumentEngine;
using CMS.DocumentEngine.Types.DotStarK;
using CMS.SiteProvider;
using DSWEBSITE_K13.Components.ViewComponents;
using DSWEBSITE_K13.Libraries.Infrastructure;
using DSWEBSITE_K13.Models.ViewModels;
using Kentico.Content.Web.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace DSWEBSITE_K13.Repositories.Repository
{
    
    /// <summary>
    /// 
    /// </summary>
    public class ProcessRepository 
    {
        private readonly IPageRetriever pageRetriever;
        private readonly RepositoryCacheHelper repositoryCacheHelper;

        /// <summary>
        /// Initializes a new instance of the <see cref="HomeRepository"/> class that returns home page sections. 
        /// </summary>
        /// <param name="pageRetriever">Retriever for pages based on given parameters.</param>
        public ProcessRepository(IPageRetriever pageRetriever,
            RepositoryCacheHelper _repositoryCacheHelper)
        {
            this.pageRetriever = pageRetriever;
            this.repositoryCacheHelper = _repositoryCacheHelper;
        }

        /// <summary>
        /// this method is used for get home page process details 
        /// </summary>
        /// <returns></returns>
        public ProcessViewModel GetHomePageProcess()
        {
            try
            {
                bool enableCache = SettingsKeyInfoProvider.GetBoolValue(SiteContext.CurrentSiteName + ".EnableCache");
                string[] cols = { "Name", "Title", "ContentText", "ImageURL", "ImageAltText", "ImageHoverText" };

                var process = new Process();
                var _process = new ProcessViewModel();
                _process.Processes = new List<ProcessListViewModel>();

                if (!enableCache)
                {
                    process = pageRetriever.RetrieveAsync<Process>(
                        query => query

                            .Published(true)
                            .OnSite(SiteContext.CurrentSiteName)
                            .Columns(cols)
                            //.Where(x => x.IsActive == true)
                            .OrderByDescending(x => x.DocumentCreatedWhen)
                            .ToList())?.Result.FirstOrDefault();
                }
                else
                {
                    process = pageRetriever.RetrieveAsync<Process>(
                        query => query
                            .Published(true)
                            .OnSite(SiteContext.CurrentSiteName)
                            .Columns(cols)
                            //.Where(x=>x.IsActive == true)
                            .OrderByDescending(x => x.DocumentCreatedWhen)
                            .ToList(),
                        cache => cache
                            .Key($"{nameof(ProcessRepository)}|{nameof(GetHomePageProcess)}")
                            // Include path dependency to flush cache when a new child page is created or page order is changed.
                            .Dependencies((_, builder) => builder.PagePath("", PathTypeEnum.Children).PageOrder()),
                        new CancellationToken())?.Result.FirstOrDefault();

                }

                if (process != null)
                {
                    _process = ProcessViewModel.GetModel(process);

                    var collection = GetHomePageProcessList();

                    if (collection != null && collection.Count > 0)
                    {
                        _process.Processes = collection.OrderBy(x => x.Sequence).ToList();
                    }
                }

                return _process;
            }
            catch (System.Exception ex)
            {
                EventLogManager.LogError(ex.Source, "10000001", ex.Message);
                throw ex;
            }
        }

        /// <summary>
        /// this method is used for get process list 
        /// </summary>
        /// <returns></returns>
        public List<ProcessListViewModel> GetHomePageProcessList()
        {
            try
            {
                bool enableCache = SettingsKeyInfoProvider.GetBoolValue(SiteContext.CurrentSiteName + ".EnableCache");
                string[] cols = { "Title", "Sequence", "Description" };

                var processes = new List<ProcessList>();
                var _processes = new List<ProcessListViewModel>();

                if (!enableCache)
                {
                    processes = pageRetriever.RetrieveAsync<ProcessList>(
                        query => query

                            .Published(true)
                            .OnSite(SiteContext.CurrentSiteName)
                            .Columns(cols)
                            .ToList())?.Result.ToList();
                }
                else
                {
                    processes = pageRetriever.RetrieveAsync<ProcessList>(
                        query => query
                            .Published(true)
                            .OnSite(SiteContext.CurrentSiteName)
                            .Columns(cols)
                            .ToList(),
                        cache => cache
                            .Key($"{nameof(ProcessRepository)}|{nameof(GetHomePageProcessList)}")
                            // Include path dependency to flush cache when a new child page is created or page order is changed.
                            .Dependencies((_, builder) => builder.PagePath("", PathTypeEnum.Children).PageOrder()),
                        new CancellationToken())?.Result.ToList();

                }

                if (processes != null && processes.Count > 0)
                {
                    foreach (var process in processes)
                    {
                        _processes.Add(ProcessListViewModel.GetModel(process));
                    }

                }

                return _processes;
            }
            catch (System.Exception ex)
            {
                EventLogManager.LogError(ex.Source, "10000002", ex.Message);
                throw ex;
            }
        }
    }
}
