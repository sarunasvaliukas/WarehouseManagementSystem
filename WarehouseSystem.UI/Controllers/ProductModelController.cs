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
    public class ProductModelController : Controller
    {
        private readonly IProductHelper productHelper;
        private readonly IManufacturerHelper manufacturerHelper;

        public ProductModelController(IProductHelper productHelper, IManufacturerHelper manufacturerHelper)
        {
            this.productHelper = productHelper;
            this.manufacturerHelper = manufacturerHelper;
        }

        [AuthRole(Roles = "ADMIN")]
        public ActionResult Edit(long? id)
        {
            ProductModelView productModelView;

            if (id.HasValue)
            {
                productModelView = productHelper.GetProductModel(id.Value);

                if (productModelView == null)
                {
                    return View("Error");
                }               
            }
            else
            {
                productModelView = new ProductModelView();
            }

            ViewBag.ManufacturerId = new SelectList(manufacturerHelper.GetManufacturers(), "Id", "Tittle", productModelView.ManufacturerId);
            return View(productModelView);
        }

        public ActionResult Details(long? modelId)
        {
            ViewBag.ProductModels = new SelectList(productHelper.GetProductModels(), "Id", "Title", modelId);

            if (modelId.HasValue)
            {
                return View(productHelper.GetProductModel(modelId.Value));
            }

            return View(new ProductModelView());
        }

        [HttpPost]
        [AuthRole(Roles = "ADMIN")]
        public ActionResult Edit(ProductModelView productModelView)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.ManufacturerId = new SelectList(manufacturerHelper.GetManufacturers(), "Id", "Tittle", productModelView.ManufacturerId);
                return View(productModelView);
            }

            productHelper.SaveModel(productModelView);
            return RedirectToAction("Index", "Product");
        }
    }
}