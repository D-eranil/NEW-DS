using CMS.DataEngine;
using CMS.DocumentEngine;
using CMS.DocumentEngine.Types.DotStarK;
using CMS.SiteProvider;
using DSWEBSITE_K13.Components.ViewComponents;
using DSWEBSITE_K13.Models;
using Kentico.Content.Web.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DSWEBSITE_K13.Repositories.Repository
{
    public class NewslatterRepository : IPageRepository
    {
        private readonly IPageRetriever pageRetriever;
        private readonly bool enableCache;

        /// <summary>
        /// Constructor for newsletter (subscribe) Section of home page will instanciate, initialized readonly instaces
        /// </summary>
        /// <param name="pageRetriever"></param>
        public NewslatterRepository(IPageRetriever pageRetriever)
        {
            this.pageRetriever = pageRetriever;
            this.enableCache = SettingsKeyInfoProvider
                                .GetBoolValue(SiteContext.CurrentSiteName + Constants.EnableCache);
        }


        public NewsletterModel GetNewslatter(string nodeAliasPath)
        {

            NewsletterModel model = new NewsletterModel();
            // Initializaton of InnerPageHead instance
            Newsletter newsletter = new Newsletter();
            try
            {
                //Set common query for cache and non cache condition 
                Action<DocumentQuery<Newsletter>> pageQuery =
                        query => query
                                .Columns(
                                    "NewsletterName", "BackgroundImage", "BackgroundImageURL", "TitleText",
                                    "ContentText", "EmailTextboxName", "ButtonText", "AgreedCheckbox",
                                    "CheckboxText", "ButtonRedirectURL", "NodeGUID"
                                )
                                .Path(nodeAliasPath, PathTypeEnum.Single)
                                .NestingLevel(1).FirstOrDefault();

                // Get inner page head detail from tree node
                if (enableCache)
                {
                    newsletter = pageRetriever.Retrieve(
                        pageQuery,
                        cache => cache
                            .Key($"{nameof(NewslatterRepository)}|{nameof(GetNewslatter)}|{nodeAliasPath}")
                            .Dependencies((_, builder) => builder.PagePath(nodeAliasPath, PathTypeEnum.Children))
                    ).FirstOrDefault();
                }
                else
                {
                    newsletter = pageRetriever.Retrieve(
                       pageQuery
                    ).FirstOrDefault();
                }

                //Bind model data from kentico page
                var pageModel = NewsletterModel.GetModel(newsletter);

                return pageModel;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
