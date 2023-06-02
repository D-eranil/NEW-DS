using CMS.DocumentEngine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DSWEBSITE_K13.Models.ViewModels
{
    public class PageBaseViewModel
    {
        #region  Fields

        public TreeNode Node { get; set; }

        #endregion

        public PageBaseViewModel(TreeNode node)
        {
            Node = node;
        }
    }
}
