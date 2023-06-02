using Microsoft.AspNetCore.Mvc;

namespace DSWEBSITE_K13.Components.ViewComponents
{
    public class LinkIconsViewComponent:ViewComponent
    {
        public IViewComponentResult Invoke(LinkIconsModel iconsModel)
        {
            return View("~/Components/ViewComponents/LinkIcons/LinkIcons.cshtml", iconsModel);
        }
    }
}
