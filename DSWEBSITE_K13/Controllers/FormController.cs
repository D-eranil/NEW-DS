using CMS.Core;
using CMS.DataEngine;
using CMS.OnlineForms;
using CMS.SiteProvider;
using DSWEBSITE_K13.Components.ViewComponents;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace DSWEBSITE_K13.Controllers
{
    public class FormController : Controller
    {
        private readonly IBizFormInfoProvider bizFormInfoProvider;

        public FormController(
          IBizFormInfoProvider _bizFormInfoProvider)
        {
            this.bizFormInfoProvider = _bizFormInfoProvider;
        }

        [HttpPost]
        public string Newsletter(NewsletterModel newsletterModel)
        {
            string result = string.Empty;
            try
            {
                if (newsletterModel != null)
                {
                    BizFormInfo bizFormInfo = bizFormInfoProvider.Get("Newslatter", SiteContext.CurrentSiteID);
                    if (bizFormInfo != null)
                    {
                        DataClassInfo formClass = DataClassInfoProvider.GetDataClassInfo(bizFormInfo.FormClassID);
                        string formClassName = formClass.ClassName;

                        BizFormItem newFormItem = BizFormItem.New(formClassName);
                        newFormItem.SetValue("txtEmailInput", newsletterModel.EmailTextboxName);
                        newFormItem.SetValue("chkAgree", newsletterModel.AgreedCheckbox);

                        newFormItem.Insert();
                        result = bizFormInfo.FormDisplayText;

                        IBizFormMailSenderFactory senderFactory = Service.Resolve<IBizFormMailSenderFactory>();
                        IBizFormMailSender sender = senderFactory.GetFormMailSender(bizFormInfo, newFormItem);

                        // Sends a notification email to users (as specified on the form's 'Email notification' tab)
                        sender.SendNotificationEmail();

                        // Sends a confirmation email to the submitter (based on the form's autoresponder settings)
                        sender.SendConfirmationEmail();
                    }
                }
            }
            catch (Exception ex)
            {
                Service.Resolve<IEventLogService>().LogException("FormController", "Newsletter", ex);
            }
            return result;
        }

        [HttpPost]
        public string CandidateBiodata(BiodataSubmissionFormModel biodataSubmissionFormModel)
        {
            string result = string.Empty;
            try
            {
                if (biodataSubmissionFormModel != null)
                {
                    BizFormInfo bizFormInfo = bizFormInfoProvider.Get("CandidateBiodata", SiteContext.CurrentSiteID);
                    if (bizFormInfo != null)
                    {
                        DataClassInfo formClass = DataClassInfoProvider.GetDataClassInfo(bizFormInfo.FormClassID);
                        string formClassName = formClass.ClassName;

                        BizFormItem newFormItem = BizFormItem.New(formClassName);
                        newFormItem.SetValue("FullName", biodataSubmissionFormModel.FullName);
                        newFormItem.SetValue("Email", biodataSubmissionFormModel.Email);
                        newFormItem.SetValue("MobileNumber", biodataSubmissionFormModel.CountryCode + " " + biodataSubmissionFormModel.MobileNumber);
                        newFormItem.SetValue("ApplyFor", biodataSubmissionFormModel.ApplyFor);
                        newFormItem.SetValue("YearOfExperience", biodataSubmissionFormModel.YearOfExperience);
                        if (Request.Form.Files.Count > 0)
                        {
                            newFormItem.SetValue("Biodata", UploadBizFormFile(Request.Form.Files[0]));
                        }
                        newFormItem.Insert();

                        result = bizFormInfo.FormDisplayText;

                        IBizFormMailSenderFactory senderFactory = Service.Resolve<IBizFormMailSenderFactory>();
                        IBizFormMailSender sender = senderFactory.GetFormMailSender(bizFormInfo, newFormItem, null, (bizFormInfo.FormEmailAttachUploadedDocs ?  new string[] { "Biodata" } : null));
                        
                        // Sends a notification email to users (as specified on the form's 'Email notification' tab)
                        sender.SendNotificationEmail();

                        // Sends a confirmation email to the submitter (based on the form's autoresponder settings)
                        sender.SendConfirmationEmail();
                       
                    }
                }
            }
            catch (Exception ex)
            {
                Service.Resolve<IEventLogService>().LogException("FormController", "CandidateBiodata", ex);
            }
            return result;
        }


        [HttpPost]
        public string ContactUsForm(ContactusModel contactusModel)
        {
            string result = string.Empty;
            try
            {
                if (contactusModel != null)
                {
                    BizFormInfo bizFormInfo = bizFormInfoProvider.Get("ContactUs", SiteContext.CurrentSiteID);
                    if (bizFormInfo != null)
                    {
                        DataClassInfo formClass = DataClassInfoProvider.GetDataClassInfo(bizFormInfo.FormClassID);
                        string formClassName = formClass.ClassName;

                        BizFormItem newFormItem = BizFormItem.New(formClassName);
                        newFormItem.SetValue("FullName", contactusModel.FullName);
                        newFormItem.SetValue("EmailAddress", contactusModel.EmailAddress);
                        newFormItem.SetValue("MobileNumber", contactusModel.CountryCode + " " + contactusModel.MobileNumber);
                        newFormItem.SetValue("Message", contactusModel.Message);
                        newFormItem.SetValue("HearAboutUs", contactusModel.HearAboutUs);
                        
                        newFormItem.Insert();

                        result = bizFormInfo.FormDisplayText;

                        IBizFormMailSenderFactory senderFactory = Service.Resolve<IBizFormMailSenderFactory>();
                        IBizFormMailSender sender = senderFactory.GetFormMailSender(bizFormInfo, newFormItem);

                        // Sends a notification email to users (as specified on the form's 'Email notification' tab)
                        sender.SendNotificationEmail();

                        // Sends a confirmation email to the submitter (based on the form's autoresponder settings)
                        sender.SendConfirmationEmail();

                    }
                }
            }
            catch (Exception ex)
            {
                Service.Resolve<IEventLogService>().LogException("FormController", "ContactUsForm", ex);
            }
            return result;
        }

        private string UploadBizFormFile(IFormFile formFile)
        {
            string returnValue = string.Empty;
            try
            {
                string uploadPath = SettingsKeyInfoProvider.GetValue(SiteContext.CurrentSiteName + ".BizFormFilePath");
                string uploadSitePath = SettingsKeyInfoProvider.GetValue(SiteContext.CurrentSiteName + ".BizFormFilePath_Frontend");
                Guid newGuid = Guid.NewGuid();
                string fileName = formFile.FileName;
                string fileExtension = fileName.Substring(fileName.LastIndexOf('.'));
                
                if (formFile.Length > 0)    
                {
                    #region Upload file on CMS
                    if (!Directory.Exists(uploadPath))
                        Directory.CreateDirectory(uploadPath);

                    string filePath = Path.Combine(uploadPath, newGuid + fileExtension);
                    using (Stream fileStream = new FileStream(filePath, FileMode.Create))
                    {
                        formFile.CopyTo(fileStream);

                    }
                    #endregion

                    #region Upload file on Frontend
                    if (!Directory.Exists(uploadSitePath))
                        Directory.CreateDirectory(uploadSitePath);

                    filePath = Path.Combine(uploadSitePath, newGuid + fileExtension);
                    using (Stream fileStream = new FileStream(filePath, FileMode.Create))
                    {
                        formFile.CopyTo(fileStream);
                    }
                    #endregion

                    returnValue = newGuid + fileExtension + "/" + fileName;
                }
                return returnValue;
            }
            catch (Exception ex)
            {
                Service.Resolve<IEventLogService>().LogException("FormController", "UploadBizFormFile", ex);
                return returnValue;
            }
        }


    }
}
