using CMS.DocumentEngine.Types.DotStarK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DSWEBSITE_K13.Models.ViewModels
{
    public class ProcessListViewModel
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public int Sequence { get; set; }



        public static ProcessListViewModel GetModel(ProcessList processList)
        {
            var data = processList == null ? null : new ProcessListViewModel()
            {
                Title = processList.Fields.Title,
                Description = processList.Fields.Description,
                Sequence = processList.Fields.Sequence
            };

            return data;
        }
    }
}
