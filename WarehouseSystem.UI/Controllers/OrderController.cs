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
    public class OrderController : Controller
    {
        private readonly IOrderHelper orderHelper;

        public OrderController(IOrderHelper orderHelper)
        {
            this.orderHelper = orderHelper;
        }

        public ActionResult Index()
        {
            return View(orderHelper.GetOrders());
        }
    }
}