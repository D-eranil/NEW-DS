using DSWEBSITE_K13.Repositories.Repository;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DSWEBSITE_K13.Components.ViewComponents
{
    public class BiodataSubmissionFormViewComponent : ViewComponent
    {
        private readonly CareerRepository careerRepository;

        public BiodataSubmissionFormViewComponent(CareerRepository _careerRepository)
        {
            careerRepository = _careerRepository;
        }
        public IViewComponentResult Invoke()
        {
            // Initializaton of InnerPageHead instance
            BiodataSubmissionFormModel biodataSubmissionFormModel = new BiodataSubmissionFormModel();
            biodataSubmissionFormModel.CurrentOpenings = careerRepository.GetCurrentOpenings("/Career");
            biodataSubmissionFormModel.YearOfExperienceList = careerRepository.GetYearOfExperience();
            return View("/Components/ViewComponents/BiodataSubmissionForm/BiodataSubmissionForm.cshtml", biodataSubmissionFormModel);
        }
    }
}
