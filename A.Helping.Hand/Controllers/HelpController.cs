using AHelpingHand.Data;
using AHelpingHand.Models;
using AHelpingHand.Service;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace A.Helping.Hand.Controllers
{
    [Authorize]
    public class HelpController : Controller
    {
        public ActionResult Index()
        {
            var userID = Guid.Parse(User.Identity.GetUserId());
            var service = new HelpService(userID);
            var model = service.GetHelps();
            return View(model);
        }
        public ActionResult Create()
        {
            GetCategories();
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(HelpCreate model)
        {
            if (!ModelState.IsValid) return View(model);

            var service = CreateHelpService();

            if (service.CreateHelp(model))
            {
                TempData["SaveResult"] = "Help created successfully.";
                return RedirectToAction("Index");
            };
            ModelState.AddModelError("", "Help could not be created.");
            return View(model);
        }
        public ActionResult Details(int id)
        {
            var model = CreateHelpService().GetProvider(id);

            return View(model);
        }
        public ActionResult Edit(int id)
        {
            GetCategories();
            var detail = CreateHelpService().GetHelpById(id);
            var model =
                new HelpEdit
                {
                    HelpID = detail.HelpID,
                    Category = detail.Category,
                    Subcategory = detail.Subcategory,
                    Experience = detail.Experience,
                    Rate = detail.Rate,
                    NewClients = detail.NewClients,
                };
            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, HelpEdit model)
        {
            if (!ModelState.IsValid) return View(model);

            if (model.HelpID != id)
            {
                ModelState.AddModelError("", "ID Mismatch");
                return View(model);
            }

            var service = CreateHelpService();

            if (service.UpdateHelp(model))
            {
                TempData["SaveResult"] = "Help was updated.";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Your account could not be updated.");
            return View();
        }
        [ActionName("Delete")]
        public ActionResult Delete(int id)
        {
            var model = CreateHelpService().GetHelpById(id);

            return View(model);
        }
        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeletePost(int id)
        {
            var service = CreateHelpService();

            service.DeleteHelp(id);

            TempData["SaveResult"] = "Account was deleted";

            return RedirectToAction("Index");
        }
        private HelpService CreateHelpService()
        {
            var userID = Guid.Parse(User.Identity.GetUserId());
            var service = new HelpService(userID);
            return service;
        }
        public ActionResult GetCategories()
        {
            List<SelectListItem> categories = new List<SelectListItem>();
            categories.Add(new SelectListItem { Text = "Select", Value = "0" });
            categories.Add(new SelectListItem { Text = "Music", Value = "Music" });
            categories.Add(new SelectListItem { Text = "Education", Value = "Education" });
            categories.Add(new SelectListItem { Text = "Home", Value = "Home" });
            categories.Add(new SelectListItem { Text = "Cleaning", Value = "Cleaning" });

            ViewData["category"] = categories;

            return View();
        }
        public JsonResult GetSubcategories(string id)
        {
            List<SelectListItem> subcatgories = new List<SelectListItem>();
            switch (id)
            {
                case "Music":
                    subcatgories.Add(new SelectListItem { Text = "Select", Value = "0" });
                    subcatgories.Add(new SelectListItem { Text = "Piano", Value = "Piano" });
                    subcatgories.Add(new SelectListItem { Text = "Guitar", Value = "Guitar" });
                    subcatgories.Add(new SelectListItem { Text = "Violin", Value = "Violin" });
                    subcatgories.Add(new SelectListItem { Text = "Percussion", Value = "Percussion" });
                    subcatgories.Add(new SelectListItem { Text = "Trumpet", Value = "Trumpet" });
                    subcatgories.Add(new SelectListItem { Text = "Trombone", Value = "Trombone" });
                    subcatgories.Add(new SelectListItem { Text = "Cello", Value = "Cello" });
                    subcatgories.Add(new SelectListItem { Text = "Flute", Value = "Flute" });
                    subcatgories.Add(new SelectListItem { Text = "French Horn", Value = "French Horn" });
                    subcatgories.Add(new SelectListItem { Text = "Voice", Value = "Voice" });
                    subcatgories.Add(new SelectListItem { Text = "Triangle", Value = "Triangle" });
                    subcatgories.Add(new SelectListItem { Text = "Bells", Value = "Bells" });
                    subcatgories.Add(new SelectListItem { Text = "Guitar", Value = "Guitar" });
                    subcatgories.Add(new SelectListItem { Text = "Oboe", Value = "Oboe" });
                    subcatgories.Add(new SelectListItem { Text = "Harp", Value = "Harp" });
                    break;
                case "Education":
                    subcatgories.Add(new SelectListItem { Text = "Select", Value = "0" });
                    subcatgories.Add(new SelectListItem { Text = "Math", Value = "Math" });
                    subcatgories.Add(new SelectListItem { Text = "Writing", Value = "Writing" });
                    subcatgories.Add(new SelectListItem { Text = "Reading", Value = "Reading" });
                    subcatgories.Add(new SelectListItem { Text = "Science", Value = "Science" });
                    subcatgories.Add(new SelectListItem { Text = "History", Value = "History" });
                    subcatgories.Add(new SelectListItem { Text = "Geography", Value = "Geography" });
                    subcatgories.Add(new SelectListItem { Text = "Economics", Value = "Economics" });
                    subcatgories.Add(new SelectListItem { Text = "Business", Value = "Business" });
                    break;
                case "Home":
                    subcatgories.Add(new SelectListItem { Text = "Select", Value = "0" });
                    subcatgories.Add(new SelectListItem { Text = "General Contracting", Value = "General Contracting" });
                    subcatgories.Add(new SelectListItem { Text = "Remodeling", Value = "Remodeling" });
                    subcatgories.Add(new SelectListItem { Text = "Roofing", Value = "Roofing" });
                    subcatgories.Add(new SelectListItem { Text = "Siding", Value = "Siding" });
                    subcatgories.Add(new SelectListItem { Text = "Plumbing", Value = "Plumbing" });
                    subcatgories.Add(new SelectListItem { Text = "HVAC", Value = "HVAC" });
                    subcatgories.Add(new SelectListItem { Text = "Concrete/Masonry", Value = "Concrete/Masonry" });
                    subcatgories.Add(new SelectListItem { Text = "Landscaping", Value = "Landscaping" });
                    break;
                case "Cleaning":
                    subcatgories.Add(new SelectListItem { Text = "Select", Value = "0" });
                    subcatgories.Add(new SelectListItem { Text = "Residence", Value = "Residence" });
                    subcatgories.Add(new SelectListItem { Text = "Office", Value = "Office" });
                    subcatgories.Add(new SelectListItem { Text = "Construction", Value = "Construction" });
                    subcatgories.Add(new SelectListItem { Text = "Auto", Value = "Auto" });
                    break;
            }
            return Json(new SelectList(subcatgories, "Value", "Text"));
        }
    }
}