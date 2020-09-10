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
    public class CustomerController : Controller
    {
        public ActionResult Index()
        {
            var userID = Guid.Parse(User.Identity.GetUserId());
            var service = new CustomerService(userID);
            var model = service.GetCustomers();

            return View(model);
        }
        public ActionResult ViewHelp()
        {
            var service = CreateCustomerService();
            var model = service.GetAllHelp();
            return View(model);
        }
        public ActionResult HelpDetails(int id)
        {
            var model = CreateCustomerService().GetProvider(id);

            return View(model);
        }
        public ActionResult Create()
        {
            GetCategories();
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CustomerCreate model)
        {
            if (!ModelState.IsValid) return View(model);

            var service = CreateCustomerService();

            if (service.CreateCustomer(model))
            {
                TempData["SaveResult"] = "Customer created successfully.";
                return RedirectToAction("Index");
            };
            ModelState.AddModelError("", "Customer Account could not be created.");
            return View(model);
        }
        public ActionResult Details(int id)
        {
            var model = CreateCustomerService().GetCustomerById(id);

            return View(model);
        }
        public ActionResult Edit(int id)
        {
            GetCategories();
            var detail = CreateCustomerService().GetCustomerById(id);
            var model =
                new CustomerEdit
                {
                    CustomerID = detail.CustomerID,
                    Name = detail.Name,
                    Email = detail.Email,
                    Category = detail.Category,
                    Subcategory = detail.Subcategory,
                    Skill = detail.Skill,
                };
            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, CustomerEdit model)
        {
            if (!ModelState.IsValid) return View(model);

            if (model.CustomerID != id)
            {
                ModelState.AddModelError("", "ID Mismatch");
                return View(model);
            }

            var service = CreateCustomerService();

            if (service.UpdateCustomer(model))
            {
                TempData["SaveResult"] = "Customer was updated.";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Your account could not be updated.");
            return View();
        }
        [ActionName("Delete")]
        public ActionResult Delete(int id)
        {
            var model = CreateCustomerService().GetCustomerById(id);

            return View(model);
        }
        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeletePost(int id)
        {
            var service = CreateCustomerService();

            service.DeleteCustomer(id);

            TempData["SaveResult"] = "Account was deleted";

            return RedirectToAction("Index");
        }
        private CustomerService CreateCustomerService()
        {
            var userID = Guid.Parse(User.Identity.GetUserId());
            var service = new CustomerService(userID);
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