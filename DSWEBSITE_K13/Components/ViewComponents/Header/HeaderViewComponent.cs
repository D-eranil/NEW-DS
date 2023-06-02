using CMS.Core;
using DSWEBSITE_K13.Repositories.Repository;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading;

namespace DSWEBSITE_K13.Components.ViewComponents
{
    public class HeaderViewComponent : ViewComponent
    {
        private readonly HeaderRepository headerRepository;

        /// <summary>
        /// Constructor for header view-component to instanciate, initialized readonly instaces
        /// </summary>
        /// <param name="_headerRepository"></param>
        public HeaderViewComponent(HeaderRepository _headerRepository)
        {
            this.headerRepository = _headerRepository;
        }

        /// <summary>
        /// Invoke header view component
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public IViewComponentResult Invoke(CancellationToken cancellationToken)
        {
            var viewModel = new HeaderViewModel();
            try
            {
                viewModel = headerRepository.GetHeaders(cancellationToken);
            }
            catch (Exception ex)
            {
                Service.Resolve<IEventLogService>().LogException("HeaderViewComponent", "Invoke", ex);
            }

            return View("~/Components/ViewComponents/Header/Header.cshtml", viewModel);
        }
    }
}
