using CMS.DocumentEngine;
using CMS.DocumentEngine.Types.DotStarK;
using DSWEBSITE_K13.Models.ViewModels;
using DSWEBSITE_K13.Repositories.Repository;
using Kentico.Content.Web.Mvc;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace DSWEBSITE_K13.Components.ViewComponents
{
    public class ProcessViewComponent : ViewComponent
    {
        private readonly IPageRetriever pageRetriever;
        private readonly ProcessRepository processRepository;

        public ProcessViewComponent(IPageRetriever _pageRetriever, ProcessRepository _processRepository)
        {
            pageRetriever = _pageRetriever;
            processRepository = _processRepository;
        }

        /// <summary>
        /// this is invoke method for render view componant for process module
        /// </summary>
        /// <param name="page"></param>
        /// <returns></returns>
        public IViewComponentResult Invoke(TreeNode page)
        {
            // Aggregate ItemAccordionPanels
            Process pageHead = new Process();

            // Get page head detail from children
            if (page.ClassName == Process.CLASS_NAME)
            {
                pageHead = pageRetriever.Retrieve<Process>(
                query => query
                    .Path(page.NodeAliasPath, PathTypeEnum.Single)
                    .NestingLevel(1).FirstOrDefault(),
                cache => cache
                    .Key($"{nameof(PageHeadViewComponent)}|{nameof(Invoke)}|{page.NodeAliasPath}")
                    .Dependencies((_, builder) => builder.PagePath(page.NodeAliasPath, PathTypeEnum.Children))
            ).FirstOrDefault();

            }

            var processViewModel = processRepository.GetHomePageProcess();

            return View("/Components/ViewComponents/Processes/Process.cshtml", processViewModel);
        }
    }
}
