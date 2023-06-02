using CMS.DataEngine;
using CMS.DocumentEngine;
using CMS.DocumentEngine.Types.DotStarK;
using CMS.SiteProvider;
using DSWEBSITE_K13.Components.ViewComponents;
using DSWEBSITE_K13.Libraries.Infrastructure.Provider;
using DSWEBSITE_K13.Models;
using System.Collections.Generic;
using System.Linq;

namespace DSWEBSITE_K13.Repositories.Repository
{
    public class BreadcrumbRepository
    {

        public List<BreadcrumbModel> GetBreadcrumbs(int parentNodeId)
        {
            string allowPageType = SettingsKeyInfoProvider.GetValue(SiteContext.CurrentSiteName + Constants.AllowBreadcrumbs);
            var allowTypes = allowPageType.Split(';');

            var docs = DocumentHelper.GetDocuments()
                                .Types(allowTypes)
                                .Where(x => x.NodeParentID == parentNodeId)
                                .OrderBy(o => o.NodeOrder);

            var LstBreadcrumb = new List<BreadcrumbModel>();
            foreach (var doc in docs)
            {
                if (doc.ColumnNames.Contains("IsCategoryBreadcrumbs"))
                {
                    bool isBreadcrumb = false;
                    isBreadcrumb = doc.GetBooleanValue("IsCategoryBreadcrumbs", isBreadcrumb);
                    if (isBreadcrumb)
                    {
                        var titleVal = doc.GetStringValue("Title", string.Empty);
                        var pageTitle = !string.IsNullOrEmpty(titleVal) ? titleVal : doc.DocumentName;
                        var item = new BreadcrumbModel()
                        {
                            ItemName = doc.DocumentName,
                            ItemUrl = CommonHelper.GetDashedCodeWithClassName("#" + pageTitle, doc.ClassName)
                        };
                        LstBreadcrumb.Add(item);
                    }
                }
            }

            return LstBreadcrumb;
        }
    }
}
