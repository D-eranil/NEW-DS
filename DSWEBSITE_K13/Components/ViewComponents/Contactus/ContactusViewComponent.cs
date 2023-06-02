using CMS.DocumentEngine;
using CMS.DocumentEngine.Types.DotStarK;
using DSWEBSITE_K13.Models.ViewModels;
using DSWEBSITE_K13.Repositories.Repository;
using Kentico.Content.Web.Mvc;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace DSWEBSITE_K13.Components.ViewComponents
{
    public class ContactusViewComponent : ViewComponent
    {
        private readonly IPageRetriever pageRetriever;
        private readonly ContactusRepository contactusRepository;

        public ContactusViewComponent(IPageRetriever _pageRetriever, ContactusRepository _contactusRepository)
        {
            pageRetriever = _pageRetriever;
            contactusRepository = _contactusRepository;
        }
        public IViewComponentResult Invoke(TreeNode page)
        {
            //banner
            var contactus = new ContactusViewModel();

            //// Get inner page head detail from tree node
            //if (page.ClassName == Contactus.CLASS_NAME)
            //{
            //    //bind blog banner
            //    var _contactus = contactusRepository.GetContactus();
            //    if (_contactus != null)
            //    {
            //        contactus = _contactus;

            //        contactus.ContactusSourceList = new List<ContactusSourceViewModel>();
            //        //bind about us source
            //        var _sources = contactusRepository.GetContactusSource();
            //        if(_sources != null && _sources.Count > 0)
            //        {
            //            foreach (var _source in _sources)
            //            {
            //                contactus.ContactusSourceList.Add(_source);
            //            }
            //        }
            //    }
            //}

            contactus = contactusRepository.GetContactus();

            return View("/Components/ViewComponents/Contactus/Contactus.cshtml", contactus);

        }
    }
}
