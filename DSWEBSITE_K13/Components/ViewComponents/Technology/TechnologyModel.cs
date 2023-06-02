using DSWEBSITE_K13.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DSWEBSITE_K13.Components.ViewComponents
{
    public class TechnologyModel
    {
        public TechnologyViewModel Technology { get; set; }
        public List<TechnologiesViewModel> Technologies { get; set; }
       
    }
}
