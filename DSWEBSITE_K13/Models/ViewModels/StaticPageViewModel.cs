using CMS.DocumentEngine.Types.DotStarK;

namespace DSWEBSITE_K13.Models.ViewModels
{
    public class StaticPageViewModel
    {
        public string PageName { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }


        public static StaticPageViewModel GetViewModel(StaticPage staticPage)
        {
            var data = staticPage == null ? null : new StaticPageViewModel()
            {
                PageName = staticPage.DocumentName,
                Title = staticPage.Fields.Title,
                Description = staticPage.Fields.Description,

            };

            return data;
        }
    }
}
