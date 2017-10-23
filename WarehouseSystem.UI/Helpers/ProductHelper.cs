using System;
using System.Collections.Generic;
using System.Linq;
using WarehouseSystem.DataAccess;
using WarehouseSystem.Repository;
using WarehouseSystem.UI.Models;

namespace WarehouseSystem.UI.Helpers
{
    public class ProductHelper : IProductHelper
    {
        private readonly IProductRepository productRepository;
        private readonly IManufacturerRepository manufacturerRepository;
        private readonly IWarehouseRepository warehouseRepository;

        public ProductHelper(IProductRepository productRepository, 
            IManufacturerRepository manufacturerRepository, 
            IWarehouseRepository warehouseRepository)
        {
            this.productRepository = productRepository;
            this.manufacturerRepository = manufacturerRepository;
            this.warehouseRepository = warehouseRepository;
        }

        public IList<ProductView> GetProducts()
        {
            return productRepository.GetProducts().Select(CreateProductView).ToList();
        }

        public IList<ProductModelView> GetProductModels()
        {
            return productRepository.GetProductModels().Select(CreateProductModelView).ToList();
        }

        public IList<ProductView> GetProductsByModel(long modelId)
        {
            return productRepository.GetProductsByModel(modelId).Select(CreateProductView).ToList();
        }

        public ProductView GetProduct(long id)
        {
            return CreateProductView(productRepository.GetProduct(id));
        }

        public ProductModelView GetProductModel(long id)
        {
            return CreateProductModelView(productRepository.GetProductModel(id));
        }

        public IList<WarehouseView> GetWarehouses()
        {
            return warehouseRepository.GetWarehouses().Select(CreateWarehouselView).ToList();
        }

        public void Save(ProductView productView)
        {
            Product product = productView.Id.HasValue ? Get(productView.Id.Value) : new Product();
            UpdateProduct(product, productView);
            productRepository.Save(product);
        }

        public void SaveModel(ProductModelView productModelView)
        {
            ProductModel productModel = productModelView.Id.HasValue ? GetModel(productModelView.Id.Value) : new ProductModel();
            UpdateProductModel(productModel, productModelView);
            productRepository.SaveModel(productModel);
        }

        public WarehouseView GetWarehouse(long id)
        {
            return CreateWarehouselView(warehouseRepository.GetWarehouse(id));
        }

        public void Delete(long id)
        {
            productRepository.Delete(Get(id));
        }

        private Product Get(long id)
        {
            return productRepository.GetProduct(id);
        }

        private ProductModel GetModel(long id)
        {
            return productRepository.GetProductModel(id);
        }

        private ProductView CreateProductView(Product product)
        {
            return new ProductView
            {
                Id = product.Id,
                ProductModelId = product.ProductModelId,
                SerialNumber = product.SerialNumber,
                Location = CreateLocationView(product.Location)
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

        private LocationView CreateLocationView(Location location)
        {
            return new LocationView()
            {
                Id = location.Id,
                Room = location.Room,
                Section = location.Section,
                WarehouseId = location.WarehouseId
            };
        }

        private void UpdateProductModel(ProductModel productModel, ProductModelView productModelView)
        {
            productModel.Id = productModelView.Id;
            productModel.Description = productModelView.Description;
            productModel.ModelNumber = productModelView.ModelNumber;
            productModel.Title = productModelView.Title;
            productModel.Manufacturer = manufacturerRepository.GetManufacturer(productModelView.ManufacturerId.Value);
        }

        private void UpdateLocation(Location location, LocationView locationView)
        {
            location.Id = locationView.Id;
            location.Room = locationView.Room;
            location.Section = locationView.Section;
            location.Warehouse = warehouseRepository.GetWarehouse(locationView.WarehouseId.Value);
        }

        private void UpdateProduct(Product product, ProductView productView)
        {
            if (product.Location == null)
            {
                product.Location = new Location();   
            }

            product.Id = productView.Id;
            product.SerialNumber = productView.SerialNumber;
            UpdateLocation(product.Location, productView.Location);
            product.DateCreated = DateTime.Today;
            product.DateModified = DateTime.Today;
            product.ProductModelId = productView.ProductModelId;
            product.ProductModel = GetModel(productView.ProductModelId.Value);
        }

        private WarehouseView CreateWarehouselView(Warehouse warehouse)
        {
            return new WarehouseView()
            {
                Id = warehouse.Id,
                Name = warehouse.Name
            };
        }
    }
}