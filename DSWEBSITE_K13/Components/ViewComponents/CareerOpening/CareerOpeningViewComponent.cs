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
    public class CareerOpeningViewComponent : ViewComponent
    {
        private readonly CareerRepository careerRepository;

        public CareerOpeningViewComponent(CareerRepository _careerRepository)
        {
            careerRepository = _careerRepository;
        }
        public IViewComponentResult Invoke(TreeNode page)
        {
            // Initializaton of InnerPageHead instance
            CareerOpeningViewModel currentOpeningViewModel = new CareerOpeningViewModel();

            currentOpeningViewModel.CurrentOpeningModel = careerRepository.GetCurrentOpenings("/Career");

            return View("/Components/ViewComponents/CareerOpening/CareerOpening.cshtml", currentOpeningViewModel);
        }
    }
}
