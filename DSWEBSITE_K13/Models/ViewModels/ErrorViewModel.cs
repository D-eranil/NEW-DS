using CMS.DocumentEngine.Types.DotStarK;

namespace DSWEBSITE_K13.Models.ViewModels
{
    public class ErrorViewModel
    {
        public string PageName { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        public string ImageAltText { get; set; }
        public string LinkText { get; set; }
        public string LinkUrl { get; set; }


        public static ErrorViewModel GetViewModel(Error error)
        {
            var data = error == null ? null : new ErrorViewModel()
            {
                PageName = error.DocumentName,
                Title = error.Fields.Title,
                Description = error.Fields.Description,
                Image = error.Fields.Image,
                ImageAltText = error.Fields.ImageAltText,
                LinkText = error.Fields.LinkText,
                LinkUrl = error.Fields.LinkUrl
            };

            return data;
        }
    }
}
