using CMS.DocumentEngine.Types.DotStarK;
using DSWEBSITE_K13.Controllers;
using DSWEBSITE_K13.Models.ViewModels;
using Kentico.Content.Web.Mvc;
using Kentico.Content.Web.Mvc.Routing;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

[assembly:RegisterPageRoute(StaticPage.CLASS_NAME,typeof(StaticPageController))]
namespace DSWEBSITE_K13.Controllers
{
    public class StaticPageController : Controller
    {
        private readonly IPageDataContextRetriever pageDataContextRetriever;
        private readonly IPageDataContextInitializer pageDataContextInitializer;

        public StaticPageController(IPageDataContextRetriever _pageDataContextRetriever,
            IPageDataContextInitializer _pageDataContextInitializer)
        {
            pageDataContextRetriever = _pageDataContextRetriever;
            pageDataContextInitializer = _pageDataContextInitializer;
        }

        public IActionResult Index()
        {
            try
            {
                // Retrive page of Home page type based on request URL 
                var page = pageDataContextRetriever.Retrieve<StaticPage>().Page;
                if (page == null)
                {
                    return NotFound();
                }
                //Initialize home page for page builder options
                pageDataContextInitializer.Initialize(page);

                var viewModel = StaticPageViewModel.GetViewModel(page);

                return View(viewModel);
            }
            catch (Exception ex)
            {
                return StatusCode(500);
                throw ex;
            }
        }
    }

}
