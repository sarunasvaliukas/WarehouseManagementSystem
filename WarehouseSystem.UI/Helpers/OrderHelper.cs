using System;
using System.Collections.Generic;
using System.Linq;
using WarehouseSystem.DataAccess;
using WarehouseSystem.Repository;
using WarehouseSystem.UI.Models;

namespace WarehouseSystem.UI.Helpers
{
    public class OrderHelper : IOrderHelper
    {
        private readonly IOrderRepository orderRepository;

        public OrderHelper(IOrderRepository orderRepository)
        {
            this.orderRepository = orderRepository;
        }

        public IList<OrderView> GetOrders()
        {
            return orderRepository.GetOrders().Select(CreateOrderView).ToList();
        }

        private OrderView CreateOrderView(Order order)
        {
            return new OrderView()
            {
                Id = order.Id,
                ProductQuantity = order.ProductQuantity,
                StoreName = order.StoreName,
                ProductModel = CreateProductModelView(order.ProductModel)
            };
        }

        private ProductModelView CreateProductModelView(ProductModel productModel)
        {
            return new ProductModelView
            {
                Description = productModel.Description,
                Id = productModel.Id,
                ModelNumber = productModel.ModelNumber,
                Title = productModel.Title
            };
        }
    }
}