using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web.Mvc;
using WarehouseSystem.API.Models;
using WarehouseSystem.UI.Helpers.Interfaces;
using System.Net.Http.Formatting.Internal;

namespace WarehouseSystem.UI.Controllers
{
    [Authorize]
    public class OrderController : Controller
    {
        private readonly IProductHelper productHelper;

        public OrderController(IProductHelper productHelper)
        {
            this.productHelper = productHelper;
        }

        public ActionResult Index()
        {
            string resultStr = GetClient().GetStringAsync("Order").Result;
            return View(JsonConvert.DeserializeObject<List<OrderModel>>(resultStr));
        }

        [AuthRole(Roles = "ADMIN")]
        public ActionResult Edit(long? id)
        {
            OrderModel orderModel;

            if (id.HasValue)
            {
                var response = GetClient().GetAsync("Order/" + id.Value).Result;

                if (response.StatusCode == HttpStatusCode.NotFound)
                {
                    return View("Error");
                }

                var result = response.Content.ReadAsStringAsync().Result;
                orderModel = JsonConvert.DeserializeObject<OrderModel>(result);
            }
            else
            {
                orderModel = new OrderModel();
            }

            ViewBag.ProductModelId = new SelectList(productHelper.GetProductModels(), "Id", "Title", orderModel.ProductModelId);
            return View(orderModel);
        }

        [HttpPost]
        [AuthRole(Roles = "ADMIN")]
        public ActionResult Edit(OrderModel orderModel)
        {
            if (orderModel.Id.HasValue)
            {
                var result = GetClient().PutAsJsonAsync("Order/" + orderModel.Id.Value, orderModel).Result;

                if (result.StatusCode == HttpStatusCode.BadRequest)
                {
                    ViewBag.ProductModelId = new SelectList(productHelper.GetProductModels(), "Id", "Title", orderModel.ProductModelId);
                    return View(orderModel);
                }

                if (result.StatusCode == HttpStatusCode.NotFound)
                {
                    return View("Error");
                }
            }
            else
            {
                var result = GetClient().PostAsJsonAsync("Order", orderModel).Result;

                if (result.StatusCode == HttpStatusCode.BadRequest)
                {
                    ViewBag.ProductModelId = new SelectList(productHelper.GetProductModels(), "Id", "Title", orderModel.ProductModelId);
                    return View(orderModel);
                }
            }

            return RedirectToAction("Index");
        }

        [AuthRole(Roles = "ADMIN")]
        public ActionResult Delete(long? id)
        {
            if (id.HasValue)
            {
                var result = GetClient().DeleteAsync("Order/" + id.Value).Result;

                if (result.StatusCode == HttpStatusCode.NotFound)
                {
                    return View("Error");
                }
            }

            return RedirectToAction("Index");
        }

        private HttpClient GetClient()
        {
            return new HttpClient {BaseAddress = new Uri("http://localhost:59094/api/")};
        }
    }
}