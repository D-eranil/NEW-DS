using CMS.DocumentEngine;
using CMS.DocumentEngine.Types.DotStarK;
using DSWEBSITE_K13.Models.ViewModels;
using DSWEBSITE_K13.Repositories.Repository;
using Kentico.Content.Web.Mvc;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace DSWEBSITE_K13.Components.ViewComponents
{
    public class ClienteleContainerViewComponent : ViewComponent
    {
        private readonly IPageRetriever pageRetriever;
        private readonly ClienteleRepository clienteleRepository;

        public ClienteleContainerViewComponent(IPageRetriever _pageRetriever, ClienteleRepository _clienteleRepository)
        {
            pageRetriever = _pageRetriever;
            clienteleRepository = _clienteleRepository;
        }
        public IViewComponentResult Invoke(TreeNode page)
        {
            // Initializaton of InnerPageHead instance
            ClienteleContainerModel clienteleSection = new ClienteleContainerModel();

            // Get inner page head detail from tree node
            if (page.ClassName == ClienteleContainer.CLASS_NAME)
            {
                clienteleSection = clienteleRepository.GetHomePageClienteles();
            }


            return View("/Components/ViewComponents/ClienteleContainer/ClienteleContainer.cshtml", clienteleSection);

        }
    }
}
