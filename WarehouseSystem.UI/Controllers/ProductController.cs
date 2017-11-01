using System.Web.Mvc;
using WarehouseSystem.UI.Helpers.Interfaces;
using WarehouseSystem.UI.Models;

namespace WarehouseSystem.UI.Controllers
{
    [Authorize]
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

        [AuthRole(Roles = "ADMIN")]
        public ActionResult Edit(long? id)
        {
            ProductView productView;

            if (id.HasValue)
            {
                productView = productHelper.GetProduct(id.Value);

                if (productView == null)
                {
                    return View("Error");
                }
            }
            else
            {
                productView = new ProductView();
            }

            ViewBag.ProductModelId = new SelectList(productHelper.GetProductModels(), "Id", "Title", productView.ProductModelId);
            ViewBag.WarehouseId = new SelectList(productHelper.GetWarehouses(), "Id", "Name", productView.Location.WarehouseId);
            return View(productView);
        }

        [AuthRole(Roles = "ADMIN")]
        public ActionResult Delete(long? id)
        {
            if (id.HasValue)
            {
                productHelper.Delete(id.Value);
            }

            return RedirectToAction("Index");
        }

        [HttpPost]
        [AuthRole(Roles = "ADMIN")]
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