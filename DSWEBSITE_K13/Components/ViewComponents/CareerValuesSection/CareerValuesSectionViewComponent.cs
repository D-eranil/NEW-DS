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
    public class CareerValuesSectionViewComponent : ViewComponent
    {
        private readonly CareerRepository careerRepository;

        public CareerValuesSectionViewComponent(CareerRepository _careerRepository)
        {
            careerRepository = _careerRepository;
        }
        public IViewComponentResult Invoke(TreeNode page)
        {
            // Initializaton of InnerPageHead instance
            CareerValuesSectionModel careerValuesSectionModel = new CareerValuesSectionModel();

            // Get inner page head detail from tree node
            if (page.ClassName == CareerValuesSection.CLASS_NAME)
            {
                careerValuesSectionModel = careerRepository.GetCareerValuesSection(page.ClassName, page.NodeAliasPath);
            }

            return View("/Components/ViewComponents/CareerValuesSection/CareerValuesSection.cshtml", careerValuesSectionModel);
        }
    }
}
