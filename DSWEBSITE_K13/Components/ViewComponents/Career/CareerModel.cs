using CMS.DocumentEngine.Types.DotStarK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DSWEBSITE_K13.Components.ViewComponents
{
    public class CareerModel
    {
        public string Title { get; set; }
        public static CareerModel GetCareerModel(Career career)
        {
            var data = career == null ? null : new CareerModel()
            {
                Title = career.Fields.Title
            };

            return data;
        }
    }
}
