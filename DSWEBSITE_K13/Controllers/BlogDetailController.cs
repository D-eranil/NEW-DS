using CMS.DocumentEngine.Types.DotStarK;
using DSWEBSITE_K13.Controllers;
using DSWEBSITE_K13.Models.ViewModels;
using Kentico.Content.Web.Mvc;
using Kentico.Content.Web.Mvc.Routing;
using Microsoft.AspNetCore.Mvc;
using System;



[assembly: RegisterPageRoute(Blogs.CLASS_NAME, typeof(BlogDetailController))]
namespace DSWEBSITE_K13.Controllers
{
    public class BlogDetailController : Controller
    {

        private readonly IPageDataContextRetriever pageDataContextRetriever;
        private readonly IPageDataContextInitializer pageDataContextInitializer;

        public BlogDetailController(IPageDataContextRetriever _pageDataContextRetriever,
            IPageDataContextInitializer _pageDataContextInitializer)
        {
            pageDataContextRetriever = _pageDataContextRetriever;
            pageDataContextInitializer = _pageDataContextInitializer;
        }

        public IActionResult Index()
        {

            try
            {
                var page = pageDataContextRetriever.Retrieve<Blogs>().Page;
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

        }
    }
}
