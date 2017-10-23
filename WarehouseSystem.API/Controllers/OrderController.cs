using System.Web.Http;
using WarehouseSystem.API.Models;
using WarehouseSystem.DataAccess;
using WarehouseSystem.Repository;

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

        public OrderModel Get(long id)
        {
            return GetOrderModel(id);
        }

        public void Put(long id, [FromBody]OrderModel orderModel)
        {
            Order order = orderRepository.GetOrder(id);
            UpdateOrder(order, orderModel);
            orderRepository.Save(order);
        }

        public void Post([FromBody]OrderModel orderModel)
        {
            Order order = new Order();
            UpdateOrder(order, orderModel);
            orderRepository.Save(order);
        }

        public void Delete(long id)
        {
            Order order = orderRepository.GetOrder(id);
            orderRepository.Delete(order);
        }

        private OrderModel GetOrderModel(long id)
        {
            return CreateModel(orderRepository.GetOrder(id));
        }

        private void UpdateOrder(Order order, OrderModel orderModel)
        {
            order.ProductModelId = orderModel.ProductModelId;
            order.StoreName = orderModel.StoreName;
            order.ProductQuantity = orderModel.ProductQuantity;
            order.ProductModel = productRepository.GetProductModel(orderModel.ProductModelId.Value);
        }

        private OrderModel CreateModel(Order order)
        {
            return new OrderModel
            {
                StoreName = order.StoreName,
                ProductModelId = order.ProductModelId,
                ProductQuantity = order.ProductQuantity
            };
        }
    }
}
