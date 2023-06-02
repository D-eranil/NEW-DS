using CMS.DocumentEngine;
using DSWEBSITE_K13.Repositories.Repository;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DSWEBSITE_K13.Components.ViewComponents
{
    public class CareerViewComponent : ViewComponent
    {
        private readonly CareerRepository careerRepository;

        public CareerViewComponent(CareerRepository _careerRepository)
        {
            careerRepository = _careerRepository;
        }

        public IViewComponentResult Invoke(TreeNode page)
        {
            // Initializaton of InnerPageHead instance
            CareerModel careerContainerModel = new CareerModel();

            // Get inner page head detail from tree node
            if (page.ClassName == CMS.DocumentEngine.Types.DotStarK.Career.CLASS_NAME)
            {
                careerContainerModel = careerRepository.GetCareer(page.ClassName, page.NodeAliasPath);
            }

            return View("/Components/ViewComponents/Career/Career.cshtml", careerContainerModel);
        }
    }
}
