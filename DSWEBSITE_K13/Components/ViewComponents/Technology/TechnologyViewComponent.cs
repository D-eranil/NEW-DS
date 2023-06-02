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
    public class TechnologyViewComponent : ViewComponent
    {
        private readonly IPageRetriever pageRetriever;
        private readonly TechnologyRepository technologyRepository;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="_pageRetriever"></param>
        /// <param name="_technologyRepository"></param>
        public TechnologyViewComponent(IPageRetriever _pageRetriever, TechnologyRepository _technologyRepository)
        {
            pageRetriever = _pageRetriever;
            technologyRepository = _technologyRepository;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="page"></param>
        /// <returns></returns>
        public IViewComponentResult Invoke(TreeNode page)
        {
            // Aggregate ItemAccordionPanels
            Technology pageHead = new Technology();

            //Get page head detail from children
            if (page.ClassName == Technology.CLASS_NAME)
            {
                pageHead = pageRetriever.Retrieve<Technology>(
                query => query
                    .Path(page.NodeAliasPath, PathTypeEnum.Single)
                    .NestingLevel(1).FirstOrDefault(),
                cache => cache
                    .Key($"{nameof(TechnologyViewComponent)}|{nameof(Invoke)}|{page.NodeAliasPath}")
                    .Dependencies((_, builder) => builder.PagePath(page.NodeAliasPath, PathTypeEnum.Children))
            ).FirstOrDefault();
            }

            var technologyModel = new TechnologyModel();

            if (technologyRepository != null)
            {
                //init technology 1
                technologyModel.Technology = new TechnologyViewModel();

                //bind basic technology info
                if (technologyModel.Technology != null)
                {
                    technologyModel.Technology = technologyRepository.GetTechnology();
                }

                //init technologies
                technologyModel.Technologies = new List<TechnologiesViewModel>();

                //bild working technologies
                var technologies = technologyRepository.GetTechnologies();

                if (technologies != null && technologies.Count > 0)
                {
                    //bild working technology details
                    var technologyDetails = technologyRepository.GetTechnologyDetails();

                    foreach (var technology in technologies)
                    {
                        //get technology by name
                        var list = technologyDetails.Where(x => x.TechnologyName == technology.TechnologyName).ToList();

                        //init technology details
                        technology.TechnologyDetails = new List<TechnologyDetailViewModel>();

                        //bind technology
                        foreach (var item in list)
                        {
                            technology.TechnologyDetails.Add(item);
                        }

                        //bind technology
                        technologyModel.Technologies.Add(technology);
                    }
                }
            }

            return View("/Components/ViewComponents/Technology/Technology.cshtml", technologyModel);
        }
    }
}
