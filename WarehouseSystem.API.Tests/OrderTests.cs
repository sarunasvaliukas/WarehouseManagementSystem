using System;
using System.Collections.Generic;
using System.Net;
using System.Web.Http.Results;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using WarehouseSystem.API.Controllers;
using WarehouseSystem.API.Models;
using WarehouseSystem.DataAccess;
using WarehouseSystem.Repository.Interfaces;

namespace WarehouseSystem.API.Tests
{
    [TestClass]
    public class OrderTests
    {
        [TestMethod]
        public void GetAllOrders_ShouldReturnAllOrders()
        {
            var orderProducts = GetTestOrders();
            var orderMockRepository = new Mock<IOrderRepository>();
            var productMockRepository = new Mock<IProductRepository>();
            orderMockRepository.Setup(x => x.GetOrders()).Returns(orderProducts);

            var controller = new OrderController(orderMockRepository.Object, productMockRepository.Object);

            var result = controller.GetOrders() as List<OrderModel>;

            Assert.AreEqual(orderProducts.Count, result.Count);
        }

        [TestMethod]
        public void GetOrder_ShouldReturnCorrectOrder()
        {
            var order = GetTestOrder();
            var orderMockRepository = new Mock<IOrderRepository>();
            var productMockRepository = new Mock<IProductRepository>();
            orderMockRepository.Setup(x => x.GetOrder(1)).Returns(order);

            var controller = new OrderController(orderMockRepository.Object, productMockRepository.Object);

            var result = controller.Get(1) as OkNegotiatedContentResult<OrderModel>;

            Assert.IsNotNull(result);
            Assert.AreEqual(order.StoreName, result.Content.StoreName);
            Assert.AreEqual(order.ProductModelId, result.Content.ProductModelId);
            Assert.AreEqual(order.ProductQuantity, result.Content.ProductQuantity);
        }

        [TestMethod]
        public void GetOrder_ShouldNotFindOrder()
        {
            var order = GetTestOrder();
            var orderMockRepository = new Mock<IOrderRepository>();
            var productMockRepository = new Mock<IProductRepository>();
            orderMockRepository.Setup(x => x.GetOrder(1)).Returns(order);

            var controller = new OrderController(orderMockRepository.Object, productMockRepository.Object);

            var result = controller.Get(99);

            Assert.IsInstanceOfType(result, typeof(NotFoundResult));
        }

        [TestMethod]
        public void DeleteOrder_ShouldReturnOK()
        {
            var order = GetTestOrder();
            var orderMockRepository = new Mock<IOrderRepository>();
            var productMockRepository = new Mock<IProductRepository>();
            orderMockRepository.Setup(x => x.GetOrder(1)).Returns(order);

            var controller = new OrderController(orderMockRepository.Object, productMockRepository.Object);

            var result = controller.Delete(1) as OkNegotiatedContentResult<Order>;

            Assert.IsNotNull(result);
            Assert.AreEqual(order.Id, result.Content.Id);
        }

        [TestMethod]
        public void DeleteOrder_ShouldReturnNotFindOrder()
        {
            var order = GetTestOrder();
            var orderMockRepository = new Mock<IOrderRepository>();
            var productMockRepository = new Mock<IProductRepository>();
            orderMockRepository.Setup(x => x.GetOrder(1)).Returns(order);

            var controller = new OrderController(orderMockRepository.Object, productMockRepository.Object);

            var result = controller.Delete(99);

            Assert.IsInstanceOfType(result, typeof(NotFoundResult));
        }

        [TestMethod]
        public void PostOrder_ShouldReturnSameOrder()
        {
            var order = GetTestOrderModel();
            var productModel = GetTestProductModel();

            var orderMockRepository = new Mock<IOrderRepository>();
            var productMockRepository = new Mock<IProductRepository>();
            productMockRepository.Setup(x => x.GetProductModel(2)).Returns(productModel);

            var controller = new OrderController(orderMockRepository.Object, productMockRepository.Object);
            var result = controller.Post(order) as OkNegotiatedContentResult<Order>;

            Assert.IsNotNull(result);
            Assert.AreEqual(result.Content.ProductModel.Id, order.ProductModelId);
            Assert.AreEqual(order.Id, result.Content.Id);
            Assert.AreEqual(result.Content.StoreName, order.StoreName);
        }

        [TestMethod]
        public void PutOrder_ShouldReturnStatusCode()
        {
            var orderMoldel = GetTestOrderModel();
            var order = GetTestOrder();
            var productModel = GetTestProductModel();

            var orderMockRepository = new Mock<IOrderRepository>();
            var productMockRepository = new Mock<IProductRepository>();

            orderMockRepository.Setup(x => x.GetOrder(1)).Returns(order);
            productMockRepository.Setup(x => x.GetProductModel(2)).Returns(productModel);

            var controller = new OrderController(orderMockRepository.Object, productMockRepository.Object);
            var result = controller.Put(orderMoldel.Id.Value, orderMoldel) as StatusCodeResult;

            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(StatusCodeResult));
            Assert.AreEqual(HttpStatusCode.NoContent, result.StatusCode);
        }


        private IList<Order> GetTestOrders()
        {
            var testOrders = new List<Order>
            {
                new Order {Id = 1, StoreName = "Test1", ProductQuantity = 1, ProductModelId = 1,
                    ProductModel = new ProductModel {Id = 1, ModelNumber = "n1",
                        Manufacturer = new Manufacturer{Tittle = "m1"}}},
                new Order {Id = 2, StoreName = "Test2", ProductQuantity = 2, ProductModelId = 2,
                    ProductModel = new ProductModel {Id = 2, ModelNumber = "n2",
                        Manufacturer = new Manufacturer{Tittle = "m2"}}},
                new Order {Id = 3, StoreName = "Test3", ProductQuantity = 3, ProductModelId = 3,
                    ProductModel = new ProductModel {Id = 3, ModelNumber = "n3",
                        Manufacturer = new Manufacturer{Tittle = "m3"}}},
                new Order {Id = 4, StoreName = "Test4", ProductQuantity = 4, ProductModelId = 4,
                    ProductModel = new ProductModel {Id = 4, ModelNumber = "n4",
                        Manufacturer = new Manufacturer {Tittle = "m4"}}}
            };

            return testOrders;
        }

        private Order GetTestOrder()
        {
            return new Order
            {
                Id = 1,
                ProductModelId = 1,
                ProductQuantity = 5,
                StoreName = "Test"
            };
        }

        private OrderModel GetTestOrderModel()
        {
            return new OrderModel
            {
                ProductQuantity = 5,
                StoreName = "Test",
                ProductModelId = 2,
                Id = 1
            };
        }

        private ProductModel GetTestProductModel()
        {
            return new ProductModel
            {
                Id = 2,
                Description = "test",
                Manufacturer = new Manufacturer(),
                ManufacturerId = 1,
                ModelNumber = "Test",
                Title = "Test"
            };
        }

        private OrderModel GetTestInvalidOrderModel()
        {
            return new OrderModel
            {
                ProductModelId = 2
            };
        }
    }
}
