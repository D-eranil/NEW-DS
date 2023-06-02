using CMS.Core;
using CMS.DocumentEngine;
using DSWEBSITE_K13.Repositories.Repository;
using Microsoft.AspNetCore.Mvc;
using System;

namespace DSWEBSITE_K13.Components.ViewComponents
{
    public class FooterViewComponent : ViewComponent
    {
        private readonly FooterRepository footerRepository;
        public FooterViewComponent(
            FooterRepository _footerRepository
            )
        {
            this.footerRepository = _footerRepository;
        }

        public IViewComponentResult Invoke()
        {
            var viewModel = new FooterModel();
            try
            {
                viewModel = footerRepository.GetFooter();
            }
            catch (Exception ex)
            {
                Service.Resolve<IEventLogService>().LogException("HeaderViewComponent", "Invoke", ex);
            }

            return View("~/Components/ViewComponents/Footer/Footer.cshtml", viewModel);
        }
    }
}
