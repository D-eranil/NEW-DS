using CMS.DocumentEngine.Types.DotStarK;
using DSWEBSITE_K13.Controllers;
using DSWEBSITE_K13.Models.ViewModels;
using Kentico.Content.Web.Mvc;
using Kentico.Content.Web.Mvc.Routing;
using Microsoft.AspNetCore.Mvc;
using System;

[assembly: RegisterPageRoute(Error.CLASS_NAME, typeof(ErrorController))]
namespace DSWEBSITE_K13.Controllers
{
    public class ErrorController : Controller
    {
        private readonly IPageDataContextRetriever pageDataContextRetriever;
        private readonly IPageDataContextInitializer pageDataContextInitializer;

        public ErrorController(IPageDataContextRetriever _pageDataContextRetriever,
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
                var page = pageDataContextRetriever.Retrieve<Error>().Page;
                if (page == null)
                {
                    return NotFound();
                }
                //Initialize home page for page builder options
                pageDataContextInitializer.Initialize(page);

                var viewModel = ErrorViewModel.GetViewModel(page);
                
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
