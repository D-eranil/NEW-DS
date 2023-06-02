using CMS.DocumentEngine.Types.DotStarK;
using DSWEBSITE_K13.Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DSWEBSITE_K13.Services.Service
{
    public partial class PageService : PagesProvider, IPageService
    {
        public string TestProvider(string value)
        {

            return value;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<Pages> GetPages()
        {
            string[] cols = { "PagesID", "PageName" };
            try
            {
                return PagesProvider.GetPages()
                                  .CombineWithDefaultCulture()
                                  .Columns(cols)
                                  .OrderBy("NodeOrder")
                                  .AsParallel()
                                  .ToList();

            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }
    }
}
