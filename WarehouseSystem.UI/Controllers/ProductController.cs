using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WarehouseSystem.Repository;
using WarehouseSystem.UI.Helpers;
using WarehouseSystem.UI.Models;

namespace WarehouseSystem.UI.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductHelper productHelper;

        public ProductController(IProductHelper productHelper)
        {
            this.productHelper = productHelper;
        }

        public ActionResult Index(long? modelId)
        {
            ViewBag.ProductModels = new SelectList(productHelper.GetProductModels(), "Id", "Title", modelId);

            if (modelId.HasValue)
            {
                return View(productHelper.GetProductsByModel(modelId.Value));
            }

            return View(productHelper.GetProducts());
        }

        public ActionResult Edit(long? id)
        {
            ProductView productView;

            if (id.HasValue)
            {
                productView = productHelper.GetProduct(id.Value);
            }
            else
            {
                productView = new ProductView();
            }

            ViewBag.ProductModelId = new SelectList(productHelper.GetProductModels(), "Id", "Title", productView.ProductModelId);
            ViewBag.WarehouseId = new SelectList(productHelper.GetWarehouses(), "Id", "Name", productView.Location.WarehouseId);
            return View(productView);
        }

        public ActionResult Delete(long? id)
        {
            if (id.HasValue)
            {
                productHelper.Delete(id.Value);
            }

            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult Edit(ProductView productView)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.ProductModelId = new SelectList(productHelper.GetProductModels(), "Id", "Title", productView.ProductModelId);
                ViewBag.WarehouseId = new SelectList(productHelper.GetWarehouses(), "Id", "Name", productView.Location.WarehouseId);
                return View(productView);
            }

            productHelper.Save(productView);
            return RedirectToAction("Index");
        }
    }
}