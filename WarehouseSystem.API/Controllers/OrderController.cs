using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Http;
using System.Web.Http.Description;
using WarehouseSystem.API.Models;
using WarehouseSystem.DataAccess;
using WarehouseSystem.Repository.Interfaces;

namespace WarehouseSystem.API.Controllers
{
    public class OrderController : ApiController
    {
        private readonly IOrderRepository orderRepository;
        private readonly IProductRepository productRepository;

        public OrderController(IOrderRepository orderRepository, IProductRepository productRepository)
        {
            this.orderRepository = orderRepository;
            this.productRepository = productRepository;
        }

        public IEnumerable<OrderModel> GetOrders()
        {
            var orders = orderRepository.GetOrders();
            var orderModels = new List<OrderModel>();

            foreach (var order in orders)
            {
                var orderModel = CreateModelWithProductModel(order);
                orderModels.Add(orderModel);
            }
            return orderModels;
        }

        [ResponseType(typeof(OrderModel))]
        public IHttpActionResult Get(long id)
        {
            var order = GetOrderModel(id);

            if (order == null)
            {
                return NotFound();
            }

            return Ok(order);
        }

        [ResponseType(typeof(void))]
        public IHttpActionResult Put(long id, [FromBody]OrderModel orderModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Order order = orderRepository.GetOrder(id);

            if (order == null)
            {
                return NotFound();
            }

            UpdateOrder(order, orderModel);
            orderRepository.Save(order);

            return StatusCode(HttpStatusCode.NoContent);
        }

        [ResponseType(typeof(Order))]
        public IHttpActionResult Post([FromBody]OrderModel orderModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Order order = new Order();
            UpdateOrder(order, orderModel);
            orderRepository.Save(order);

            return Ok(order);
        }

        [ResponseType(typeof(Order))]
        public IHttpActionResult Delete(long id)
        {
            Order order = orderRepository.GetOrder(id);

            if (order == null)
            {
                return NotFound();
            }

            orderRepository.Delete(order);
            return Ok(order);
        }

        private OrderModel GetOrderModel(long id)
        {
            var order = orderRepository.GetOrder(id);
            return order == null ? null : CreateModel(orderRepository.GetOrder(id));
        }

        private void UpdateOrder(Order order, OrderModel orderModel)
        {
            order.Id = orderModel.Id;
            order.ProductModelId = orderModel.ProductModelId;
            order.StoreName = orderModel.StoreName;
            order.ProductQuantity = orderModel.ProductQuantity;
            order.ProductModel = productRepository.GetProductModel(orderModel.ProductModelId.Value);
        }

        private OrderModel CreateModel(Order order)
        {
            return new OrderModel
            {
                Id = order.Id,
                StoreName = order.StoreName,
                ProductModelId = order.ProductModelId,
                ProductQuantity = order.ProductQuantity
            };
        }

        private OrderModel CreateModelWithProductModel(Order order)
        {
            return new OrderModel
            {
                Id = order.Id,
                StoreName = order.StoreName,
                ProductModelId = order.ProductModelId,
                ProductQuantity = order.ProductQuantity,
                ProductModel = CreateProductModel(order.ProductModel)
            };
        }

        private ProductManufacturerModel CreateProductModel(ProductModel productModel)
        {
            return new ProductManufacturerModel
            {
                Id = productModel.Id,
                Manufacturer = productModel.Manufacturer.Tittle,
                ModelNumber = productModel.ModelNumber
            };
        }
    }
}
