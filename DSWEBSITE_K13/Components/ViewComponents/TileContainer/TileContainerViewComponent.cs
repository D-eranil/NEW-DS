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
    public class TileContainerViewComponent : ViewComponent
    {
        private readonly IPageRetriever pageRetriever;
        private readonly TilesRepository tilesRepository;

        public TileContainerViewComponent(IPageRetriever _pageRetriever, TilesRepository _tilesRepository)
        {
            pageRetriever = _pageRetriever;
            tilesRepository = _tilesRepository;
        }
        public IViewComponentResult Invoke(TreeNode page)
        {
            // Initializaton of InnerPageHead instance
            TileContainerModel tilesSection = new TileContainerModel();

            // Get inner page head detail from tree node
            if (page.ClassName == TileContainer.CLASS_NAME)
            {
                tilesSection = tilesRepository.GetHomePageTiles();
            }

            return View("/Components/ViewComponents/TileContainer/TileContainer.cshtml", tilesSection);


        }
    }
}
