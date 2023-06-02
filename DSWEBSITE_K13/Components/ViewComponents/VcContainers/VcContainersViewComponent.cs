using CMS.DocumentEngine;
using CMS.DocumentEngine.Types.DotStarK;
using CMS.MediaLibrary;
using custom.Repository;
using Kentico.Content.Web.Mvc;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace DSWEBSITE_K13.Components.ViewComponents
{
    public class VcContainersViewComponent : ViewComponent
    {
        private readonly VcRepository vcRepository;
        private readonly IMediaFileUrlRetriever mediaFileUrlRetriever;
        private readonly IMediaLibraryInfoProvider mediaLibraryInfoProvider;
        private readonly IMediaFileInfoProvider mediaFileInfoProvider;

        public VcContainersViewComponent(
            VcRepository vcRepository,
            IMediaFileUrlRetriever mediaFileUrlRetriever,
            IMediaLibraryInfoProvider mediaLibraryInfoProvider,
            IMediaFileInfoProvider mediaFileInfoProvider
        )
        {
            this.vcRepository = vcRepository;
            this.mediaFileUrlRetriever = mediaFileUrlRetriever;
            this.mediaLibraryInfoProvider = mediaLibraryInfoProvider;
            this.mediaFileInfoProvider = mediaFileInfoProvider;
        }

        public IViewComponentResult Invoke(TreeNode page, bool direct)
        {

            var vcContainersModel = new VcContainersModel()
            {
                Page = page
            };

            // vcs can be placed directly under specific nodes without a container
            // EXAMPLE: Accordion Vc >> Accordion Panel >> Vc
            if (direct)
            {
                if (page.Children.Any())
                {
                    var vcContainer = new VcContainerModel()
                    {
                        Container = new VcContainers(),
                        Vcs = vcRepository.GetVcNodes(page.NodeAliasPath).ToList()
                    };

                    vcContainersModel.VcContainers.Add(vcContainer);
                }
            }

            // multiple vc containers can be placed on a page
            // EXAMPLE: Page >> Vc Container >> Vc
            else
            {
                if (page.Children.OfType<VcContainers>().Any())
                {

                    List<VcContainers> VcContainers = vcRepository.GetVcsContainers(page.NodeAliasPath).ToList();

                    foreach (VcContainers VcContainer in VcContainers)
                    {
                        if (VcContainer.Children.Any())
                        {
                            var vcContainer = new VcContainerModel()
                            {
                                Container = VcContainer,
                                Vcs = vcRepository.GetVcNodes(VcContainer.NodeAliasPath).ToList()
                            };
                            vcContainersModel.VcContainers.Add(vcContainer);
                        }
                    }
                }
            }

            return View("/Components/ViewComponents/VcContainers/VcContainers.cshtml", vcContainersModel);
        }
    }
}