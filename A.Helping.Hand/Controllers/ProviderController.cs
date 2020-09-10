using A.Helping.Hand.Data;
using AHelpingHand.Data;
using AHelpingHand.Models;
using AHelpingHand.Service;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace A.Helping.Hand.Controllers
{
    [Authorize]
    public class ProviderController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Edit(int id)
        {
            var detail = CreateProviderService().GetProviderByID(id);

            var model = new ProviderEdit
            {
                ProviderID = detail.ProviderID,
                Name = detail.Name,
                Company = detail.Company,
                Email = detail.Email,
                Phone = detail.Phone,
            };
            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, ProviderEdit model)
        {
            if (!ModelState.IsValid) return View(model);
            if (model.ProviderID != id)
            {
                ModelState.AddModelError("", "ID Mismatch");
                return View(model);
            }
            var service = CreateProviderService();

            if (service.EditProvider(model))
            {
                TempData["SaveResult"] = "Provider was updated";
                return RedirectToAction("Index", "Help");
            }
            ModelState.AddModelError("", "Provider could not be updated");
            return View(model);
        }
        public ActionResult Delete(int id)
        {
            var model = CreateProviderService().GetProviderByID(id);

            return View(model);
        }
        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteProvider(int id)
        {
            var service = CreateProviderService();

            service.DeleteProvider(id);

            TempData["SaveResult"] = "Provider Deleted";

            return RedirectToAction("Index", "Home");
        }
        private ProviderService CreateProviderService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new ProviderService(userId);
            return service;
        }
    }
}