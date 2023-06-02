using CMS.DocumentEngine.Types.DotStarK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DSWEBSITE_K13.Services.Interface
{
    public interface IPageService
    {
        string TestProvider(string value);
        List<Pages> GetPages();
    }
}
