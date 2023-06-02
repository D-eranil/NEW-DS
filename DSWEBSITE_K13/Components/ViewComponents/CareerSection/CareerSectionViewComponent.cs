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
    public class CareerSectionViewComponent : ViewComponent
    {
        private readonly CareerRepository careerRepository;

        public CareerSectionViewComponent(CareerRepository _careerRepository)
        {
            careerRepository = _careerRepository;
        }
        public IViewComponentResult Invoke(TreeNode page)
        {
            // Initializaton of InnerPageHead instance
            CareerSectionModel careerSectionModel = new CareerSectionModel();

            // Get inner page head detail from tree node
            if (page.ClassName == CareerSection.CLASS_NAME)
            {
                careerSectionModel = careerRepository.GetCareerSection(page.ClassName, page.NodeAliasPath);
            }

            return View("/Components/ViewComponents/CareerSection/CareerSection.cshtml", careerSectionModel);
        }
    }
}
