using CMS.DocumentEngine.Types.DotStarK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DSWEBSITE_K13.Models.ViewModels
{
    public class StrengthViewModel
    {

        public string Name { get; set; }
        public string ShortDescription { get; set; }
        public bool IsActive { get; set; }

        public static StrengthViewModel GetModel(Strength strength)
        {
            var data = strength == null ? null : new StrengthViewModel()
            {
                Name = strength.Fields.Name,
                ShortDescription = strength.Fields.ShortDescription,
                IsActive = true,
            };

            

            if(!string.IsNullOrEmpty(data.Name))
            {
                string str = "<span>" + data.Name.Substring(0, 1) + "</span>" + data.Name.Substring(1, data.Name.Length - 1);
                data.Name = str;
            }



            return data;
        }
    }
}

