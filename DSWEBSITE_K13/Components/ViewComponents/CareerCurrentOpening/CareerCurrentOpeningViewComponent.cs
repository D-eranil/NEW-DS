using CMS.DocumentEngine;
using CMS.DocumentEngine.Types.DotStarK;
using DSWEBSITE_K13.Repositories.Repository;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DSWEBSITE_K13.Components.ViewComponents
{
    public class CareerCurrentOpeningViewComponent : ViewComponent
    {
        private readonly CareerRepository careerRepository;

        public CareerCurrentOpeningViewComponent(CareerRepository _careerRepository)
        {
            careerRepository = _careerRepository;
        }
        public IViewComponentResult Invoke(TreeNode page)
        {
            // Initializaton of InnerPageHead instance
            CareerCurrentOpeningModel currentOpeningViewModel = new CareerCurrentOpeningModel();

            // Get inner page head detail from tree node
            if (page.ClassName == CareerCurrentOpening.CLASS_NAME)
            {
                currentOpeningViewModel = careerRepository.GetCareerCurrentOpeningData(page.ClassName, page.NodeAliasPath);
            }

            return View("/Components/ViewComponents/CareerCurrentOpening/CareerCurrentOpening.cshtml", currentOpeningViewModel);
        }
    }
}
