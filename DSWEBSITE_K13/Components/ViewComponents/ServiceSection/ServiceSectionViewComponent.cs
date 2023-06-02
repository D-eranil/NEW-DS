using CMS.DocumentEngine;
using CMS.DocumentEngine.Types.DotStarK;
using DSWEBSITE_K13.Repositories.Repository;
using Microsoft.AspNetCore.Mvc;

namespace DSWEBSITE_K13.Components.ViewComponents
{
    public class ServiceSectionViewComponent : ViewComponent
    {
        private readonly ServiceRepository serviceRepository;

        public ServiceSectionViewComponent(ServiceRepository _serviceRepository)
        {
            serviceRepository = _serviceRepository;
        }
        public IViewComponentResult Invoke(TreeNode page)
        {
            // Initializaton of InnerPageHead instance
            ServiceSectionModel serviceSectionModel = new ServiceSectionModel();

            // Get inner page head detail from tree node
            if (page.ClassName == ServiceSection.CLASS_NAME)
            {
                serviceSectionModel = serviceRepository.GetServices(page.ClassName, page.NodeAliasPath);
            }

            return View("/Components/ViewComponents/ServiceSection/ServiceSection.cshtml", serviceSectionModel);
        }
    }
}
