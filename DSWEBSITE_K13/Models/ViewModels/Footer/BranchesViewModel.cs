using CMS.DocumentEngine.Types.DotStarK;

namespace DSWEBSITE_K13.Models.ViewModels.Footer
{
    public class BranchesViewModel
    {
        public string BranchName { get; set; }
        public string BranchAddress { get; set; }
        public string BranchImage { get; set; }
        public string ImageAltText { get; set; }
        public bool IsActive { get; set; }

        public static BranchesViewModel GetModel(Branches branch)
        {
            var data = branch == null ? null : new BranchesViewModel()
            {
                BranchName = branch.Fields.BranchName,
                BranchAddress = branch.Fields.BranchAddress,
                IsActive = branch.Fields.IsActive,
                BranchImage = branch.Fields?.BranchImage,
                ImageAltText = branch.Fields?.ImageAltText,
            };
            return data;
        }
    }
}
