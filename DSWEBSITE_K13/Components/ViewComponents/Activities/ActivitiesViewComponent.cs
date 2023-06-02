using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace DSWEBSITE_K13.Components.ViewComponents
{
    public class ActivitiesViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke(List<ActivitiesModel> activitiesModels)
        {
            return View("/Components/ViewComponents/Activities/Activities.cshtml", activitiesModels);
        }
    }
}
