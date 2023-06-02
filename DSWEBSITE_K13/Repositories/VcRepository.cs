using CMS.DocumentEngine;
using CMS.DocumentEngine.Types.DotStarK;
using DSWEBSITE_K13.Libraries.Infrastructure;
using Kentico.Content.Web.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace custom.Repository
{
    public class VcRepository
    {
        private readonly IPageRetriever pageRetriever;
        private readonly RepositoryCacheHelper repositoryCacheHelper;

        public VcRepository(IPageRetriever pageRetriever, RepositoryCacheHelper repositoryCacheHelper)
        {
            this.pageRetriever = pageRetriever;
            this.repositoryCacheHelper = repositoryCacheHelper;
        }


        public IEnumerable<TreeNode> GetVcNodes(string path)
        {
            return pageRetriever.RetrieveMultiple(
                multiDocumentQuery => multiDocumentQuery
                    .Path(path, PathTypeEnum.Children)
                    .NestingLevel(1)
                    .WithCoupledColumns()
                    .OrderBy(nameof(VcContainers.NodeOrder)),
                cache => cache
                    .Key($"{nameof(VcRepository)}|{nameof(GetVcNodes)}|{path}")
                    .Dependencies((_, builder) => builder.PagePath(path, PathTypeEnum.Children))
            );
        }


        public IEnumerable<VcContainers> GetVcsContainers(string path)
        {
            return pageRetriever.Retrieve<VcContainers>(
                query => query
                    .Columns(
                        nameof(VcContainers.NodeSiteID),
                        nameof(VcContainers.NodeID),
                        nameof(VcContainers.NodeAliasPath),
                        nameof(VcContainers.DocumentName)
                    )
                    .Path(path, PathTypeEnum.Children)
                    .NestingLevel(1)
                    .OrderBy(nameof(VcContainers.NodeOrder)),
                cache => cache
                    .Key($"{nameof(VcRepository)}|{nameof(GetVcsContainers)}|{path}")
                    .Dependencies((_, builder) => builder.PagePath(path, PathTypeEnum.Children))
            );
        }
    }
}
