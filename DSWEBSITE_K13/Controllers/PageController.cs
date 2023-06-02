using CMS.DocumentEngine.Types.DotStarK;
using DSWEBSITE_K13.Controllers;
using DSWEBSITE_K13.Models.ViewModels;
using Kentico.Content.Web.Mvc;
using Kentico.Content.Web.Mvc.Routing;
using Microsoft.AspNetCore.Mvc;
using System;

[assembly: RegisterPageRoute(Pages.CLASS_NAME, typeof(PageController))]

namespace DSWEBSITE_K13.Controllers
{

    public class PageController : BaseController
    {
        private readonly IPageDataContextRetriever pageDataContextRetriever;
        private readonly IPageDataContextInitializer pageDataContextInitializer;

        public PageController(IPageDataContextRetriever _pageDataContextRetriever,
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
                var page = pageDataContextRetriever.Retrieve<Pages>().Page;
                if (page == null)
                {
                    return NotFound();
                }
                //Initialize home page for page builder options
                pageDataContextInitializer.Initialize(page);

                var viewModel = new PageBaseViewModel(page);

                return View(viewModel);

            }
            catch (Exception ex)
            {
                return StatusCode(500);
                throw ex;
            }
            //return View("/Views/Pages/Index.cshtml", viewModel);
            //string str = unitOfWork.PageService.TestProvider("Yes, Get sucess");
            //var data = unitOfWork.PageService.GetPages();
            // return View();
        }

        //[HttpPost]
        //public IActionResult BlogDetails(Components.ViewComponents.BlogDetailsModel blogDetails)
        //{

        //    return View("/Components/ViewComponents/BlogDetails/BlogDetails.cshtml", blogDetails);

        //}
    }
}
