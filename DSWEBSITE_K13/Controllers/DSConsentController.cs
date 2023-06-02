using CMS.ContactManagement;
using CMS.Core;
using CMS.DataProtection;
using CMS.Helpers;
using DSWEBSITE_K13.Controllers;
using DSWEBSITE_K13.Models.ViewModels;
using Kentico.Content.Web.Mvc.Routing;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;

namespace DSWEBSITE_K13.Controllers
{
    public class DSConsentController : Controller
    {
        private readonly IConsentAgreementService consentAgreementService;
        private readonly ICurrentCookieLevelProvider currentCookieLevelProvider;
        private readonly IConsentInfoProvider consentInfoProvider;


        public DSConsentController(IConsentAgreementService consentAgreementService,
                                 ICurrentCookieLevelProvider currentCookieLevelProvider,
                                 IConsentInfoProvider consentInfoProvider)
        {
            this.consentAgreementService = consentAgreementService;
            this.currentCookieLevelProvider = currentCookieLevelProvider;
            this.consentInfoProvider = consentInfoProvider;
        }



        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Accept(string returnUrl)
        {

            ConsentInfo consent = consentInfoProvider.Get("DsCookieConsent");           
            if (consent != null)
            {
                currentCookieLevelProvider.SetCurrentCookieLevel(CookieLevel.All);

                var contact = ContactManagementContext.CurrentContact;
                if (contact != null)
                {
                    consentAgreementService.Agree(contact, consent);
                }                
                return Redirect(returnUrl);
            }

            return new StatusCodeResult(StatusCodes.Status400BadRequest);
        }



        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Revoke(string returnUrl)
        {            
            ConsentInfo consent = consentInfoProvider.Get("DsCookieConsent");

            var contact = ContactManagementContext.CurrentContact;
            if (contact != null)
            {
                consentAgreementService.Agree(contact, consent);
            }
            
            return Redirect(returnUrl);
        }

    }
}
