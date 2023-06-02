using DSWEBSITE_K13.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DSWEBSITE_K13.Components.ViewComponents
{
    public class BiodataSubmissionFormModel
    {
        public string FullName { get; set; }
        public string Email { get; set; }
        public string CountryCode { get; set; }
        public string MobileNumber { get; set; }
        public string ApplyFor { get; set; }
        public string YearOfExperience { get; set; }
        public object Biodata { get; set; }
        public List<CareerOpeningModel> CurrentOpenings { get; set; }
        public List<YearOfExperienceModel> YearOfExperienceList { get; set; }
    }
}
