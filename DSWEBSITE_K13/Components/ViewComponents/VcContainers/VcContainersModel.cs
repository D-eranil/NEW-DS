using CMS.DocumentEngine;
using CMS.DocumentEngine.Types.DotStarK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DSWEBSITE_K13.Components.ViewComponents
{
    public class VcContainersModel
    {
        public TreeNode Page { get; set; }
        public List<VcContainerModel> VcContainers { get; set; } = new List<VcContainerModel>();
    }
    public class VcContainerModel
    {
        public VcContainers Container { get; set; } = new VcContainers();
        public List<TreeNode> Vcs { get; set; } = new List<TreeNode>();
    }
}
