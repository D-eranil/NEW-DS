using DSWEBSITE_K13.Services.Service;
using DSWEBSITE_K13.Services.UnitOfWork;
using Kentico.Content.Web.Mvc;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DSWEBSITE_K13.Controllers
{
    public class BaseController : Controller
    {
        //Initialized interface object.
        //private DSWEBSITE_K13.Libraries.Infrastructure.IServiceProvider serviceProvider;
        //internal readonly IUnitOfWork unitOfWork;


        //internal BaseController() : this(new Libraries.Infrastructure.ServiceProvider<Object>()) { }

        //internal BaseController(Libraries.Infrastructure.ServiceProvider<Object> _serviceProvider)
        //{
        //    serviceProvider = _serviceProvider;
        //    unitOfWork = serviceProvider.CreateServiceInstance<UnitOfWork>();
        //}

    }

    //public class RetrieverController : BaseController
    //{
    //    private readonly IPageDataContextRetriever pageDataContextRetriever;
    //    private readonly IPageDataContextInitializer pageDataContextInitializer;

    //    public RetrieverController(IPageDataContextRetriever _pageDataContextRetriever,
    //        IPageDataContextInitializer _pageDataContextInitializer)
    //    {
    //        pageDataContextRetriever = _pageDataContextRetriever;
    //        pageDataContextInitializer = _pageDataContextInitializer;
    //    }
    //}
}
