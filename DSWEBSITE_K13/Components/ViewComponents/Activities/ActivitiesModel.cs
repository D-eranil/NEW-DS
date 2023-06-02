using CMS.DataEngine;
using CMS.DocumentEngine;
using CMS.DocumentEngine.Types.DotStarK;
using DSWEBSITE_K13.Libraries.Infrastructure.Provider;
using Kentico.Content.Web.Mvc;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace DSWEBSITE_K13.Components.ViewComponents
{
    public class ActivitiesModel
    {
        public string Name { get; set; }
        public DateTime Date { get; set; }
        public string DisplayDate { get; set; }
        public string Image { get; set; }
        public string ActivityTabID { get; set; }
        public int Group { get; set; }
        public List<string> Attachments { get; set; }

        public static ActivitiesModel GetModel(Activities activities, IPageAttachmentUrlRetriever attachmentUrlRetriever)
        {
            var data = activities == null ? null : new ActivitiesModel()
            {
                Date = activities.Fields.Date,
                Image = activities.Fields.Image,
                Name = activities.Fields.Name,
                ActivityTabID = activities.Fields.ActivitySliderName,
                DisplayDate = activities.Fields.Date.ToString("MMM dd, yyyy"),
                //Attachments = CommonHelper.GetURLFromAttachments(activities.Fields.Attachments, attachmentUrlRetriever),
                Attachments = GetAttachmentByDocumentID(activities, attachmentUrlRetriever),

            };
            return data;
        }

        private static List<string> GetAttachmentByDocumentID(Activities activities, IPageAttachmentUrlRetriever attachmentUrlRetriever)
        {
            try
            {
                List<string> list = new List<string>();
                var attachments = AttachmentInfo.Provider.Get().WhereEquals("AttachmentDocumentID", activities.DocumentID);

                foreach (var attachment in attachments)
                {
                    if (attachment != null && attachment.AttachmentID > 0)
                    {
                        list.Add(attachmentUrlRetriever.Retrieve(attachment).RelativePath);
                    }
                    //list.Add(attachment.GetPath());
                }
                return list;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
