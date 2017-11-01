using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WarehouseSystem.Repository;
using WarehouseSystem.UI.Helpers;
using WarehouseSystem.UI.Helpers.Interfaces;
using WarehouseSystem.UI.Models;

namespace WarehouseSystem.UI.Controllers
{
    [Authorize]
    public class ManufacturerController : Controller
    {
        private readonly IManufacturerHelper manufacturerHelper;

        public ManufacturerController(IManufacturerHelper manufacturerHelper)
        {
            this.manufacturerHelper = manufacturerHelper;
        }

        public ActionResult Index()
        {      
            return View(manufacturerHelper.GetManufacturers());
        }

        [AuthRole(Roles = "ADMIN")]
        public ActionResult Edit(long? id)
        {
            if (id.HasValue)
            {
                var manufacturer = manufacturerHelper.GetManufacturer(id.Value);

                if (manufacturer == null)
                {
                    return View("Error");
                }

                return View(manufacturerHelper.GetManufacturer(id.Value));
            }

            return View(new ManufacturerView());
        }

        [HttpPost]
        [AuthRole(Roles = "ADMIN")]
        public ActionResult Edit(ManufacturerView manufacturerView)
        {
            if (!ModelState.IsValid)
            {
                return View(manufacturerView);
            }

            manufacturerHelper.Save(manufacturerView);
            return RedirectToAction("Index");
        }
    }
}