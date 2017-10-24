using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WarehouseSystem.API.Models;
using WarehouseSystem.DataAccess;
using WarehouseSystem.Repository;
using WarehouseSystem.Repository.Interfaces;

namespace WarehouseSystem.API.Controllers
{
    public class ProductController : ApiController
    {
        private readonly IProductRepository productRepository;

        public ProductController(IProductRepository productRepository)
        {
            this.productRepository = productRepository;
        }

        public List<ProductManufacturerModel> Get()
        {
            return GetProductModels();
        }

        public ProductManufacturerModel Get(int id)
        {
            return GetProductModel(id);
        }

        private List<ProductManufacturerModel> GetProductModels()
        {
            return productRepository.GetProductModelsWithManufacturers().Select(CreateModel).ToList();
        }

        private ProductManufacturerModel GetProductModel(long id)
        {
            return CreateModel(productRepository.GetProductModelWithManufacturer(id));
        }

        private ProductManufacturerModel CreateModel(ProductModel productModel)
        {
            return new ProductManufacturerModel()
            {
                Id = productModel.Id,
                Manufacturer = productModel.Manufacturer.Tittle,
                ModelNumber = productModel.ModelNumber,
                ProductQuantity = productRepository.GetProductCount(productModel.Id.Value)
            };
        }
    }
}
