using CMS.ContactManagement;
using CMS.Core;
using CMS.DataProtection;
using CMS.Helpers;
using Microsoft.AspNetCore.Mvc;

namespace DSWEBSITE_K13.Components.ViewComponents.Consent
{
    public class DSConsentViewComponent : ViewComponent
    {
        private readonly IConsentAgreementService consentAgreementService;
        private readonly ICurrentCookieLevelProvider currentCookieLevelProvider;
        private readonly IConsentInfoProvider consentInfoProvider;

        public DSConsentViewComponent(IConsentAgreementService consentAgreementService,
                                         ICurrentCookieLevelProvider currentCookieLevelProvider,
                                         IConsentInfoProvider consentInfoProvider)
        {
            this.consentAgreementService = consentAgreementService;
            this.currentCookieLevelProvider = currentCookieLevelProvider;
            this.consentInfoProvider = consentInfoProvider;
        }

        public IViewComponentResult Invoke()
        {
            
           
            ConsentInfo consent = consentInfoProvider.Get("DsCookieConsent");
            ContactInfo currentContact = ContactManagementContext.GetCurrentContact();
            if ((currentContact != null) && !consentAgreementService.IsAgreed(currentContact, consent))
            {
                var defaultCookieLevel = currentCookieLevelProvider.GetDefaultCookieLevel();
                currentCookieLevelProvider.SetCurrentCookieLevel(defaultCookieLevel);
            }
           
            var consentModel = new DSConsentViewModel
            {
                // Adds the consent's short text to the model
                ShortText = consent.GetConsentText("en-US").ShortText,
                ConsentFullText = consent.GetConsentText("en-US").FullText,
                // Checks whether the current contact has given an agreement for the tracking consent
                IsAgreed = (currentContact != null) && consentAgreementService.IsAgreed(currentContact, consent)
            };
           
            return View("/Components/ViewComponents/Consent/CookieConsent.cshtml", consentModel);

        }
    }
}
