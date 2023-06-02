using CMS.DocumentEngine;
using Kentico.Content.Web.Mvc;
using System;
using System.Collections.Generic;

namespace DSWEBSITE_K13.Libraries.Infrastructure.Provider
{
    public class CommonHelper
    {
        public static string GetDashedCodeFromName(string Name)
        {
            var dashedString = Name.Replace(" ", "-").Replace("&", "-").Replace(" ", "");
            return dashedString?.ToLower();
        }
        public static string GetDashedCodeWithClassName(string Name, string ClassName)
        {
            var dashedString = GetDashedCodeFromName(Name);
            return dashedString;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="attachments"></param>
        /// <returns></returns>
        public static List<string> GetURLFromAttachments(IEnumerable<DocumentAttachment> attachments, IPageAttachmentUrlRetriever attachmentUrlRetriever)
        {
            var _attachments = new List<string>();
            foreach (var attachment in attachments)
            {

                // Resolves a URL for an attachment stored in the 'Attachment' field of the 'Article' page type
                IPageAttachmentUrl attachmentUrl = attachmentUrlRetriever.Retrieve(attachment);
                _attachments.Add(attachmentUrl.RelativePath);

            }
            return _attachments;
        }

        /// <summary>
        /// this funcation is use for counvert comma seprate string to list
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static List<string> GetListFormString(string str)
        {
            var collection = new List<string>();
            try
            {
                string[] items = str.Split(",");
                if (items != null && items.Length > 0)
                {
                    foreach (string item in items)
                    {
                        collection.Add(item);
                    }
                }
                
            }
            catch (System.Exception ex)
            {
                Console.Write(ex.Message);
            }
            return collection;

        }
    }
}
