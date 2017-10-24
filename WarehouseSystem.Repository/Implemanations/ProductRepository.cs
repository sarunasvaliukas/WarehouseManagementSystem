using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using WarehouseSystem.DataAccess;
using WarehouseSystem.Repository.Interfaces;

namespace WarehouseSystem.Repository.Implemanations
{
    public class ProductRepository : IProductRepository
    {
        public IList<Product> GetProducts()
        {           
            using (var dbContext = new WarehouseContext())
            {
                return dbContext.Products.Include(p => p.Location).ToList();
            }
        }

        public IList<ProductModel> GetProductModels()
        {
            using (var dbContext = new WarehouseContext())
            {
                return dbContext.ProductModels.ToList();
            }
        }

        public IList<Product> GetProductsByModel(long modelId)
        {
            using (var dbContext = new WarehouseContext())
            {
                return dbContext.Products.Include(p => p.Location).Where(p => p.ProductModelId == modelId).ToList();
            }
        }

        public Product GetProduct(long id)
        {
            using (var dbContext = new WarehouseContext())
            {
                return dbContext.Products.Include(p => p.Location).FirstOrDefault(p => p.Id == id);
            }
        }

        public ProductModel GetProductModel(long id)
        {
            using (var dbContext = new WarehouseContext())
            {
                return dbContext.ProductModels.FirstOrDefault(p => p.Id == id);
            }
        }

        public ProductModel GetProductModelWithManufacturer(long id)
        {
            using (var dbContext = new WarehouseContext())
            {
                return dbContext.ProductModels.Include(p => p.Manufacturer).FirstOrDefault(p => p.Id == id);
            }
        }

        public IList<ProductModel> GetProductModelsWithManufacturers()
        {
            using (var dbContext = new WarehouseContext())
            {
                return dbContext.ProductModels.Include(p => p.Manufacturer).ToList();
            }
        }

        public void Delete(Product product)
        {
            using (var dbContext = new WarehouseContext())
            {
                dbContext.Entry(product).State = EntityState.Deleted;
                dbContext.SaveChanges();
            }
        }

        public int GetProductCount(long productModelId)
        {
            using (var dbContext = new WarehouseContext())
            {
                return dbContext.Products.Count(p => p.ProductModelId == productModelId);
            }
        }

        public void Save(Product product)
        {
            using (var dbContext = new WarehouseContext())
            {
                if (product.Id.HasValue)
                {
                    dbContext.Entry(product).State = EntityState.Modified;

                    dbContext.Entry(product.Location.Warehouse).State = EntityState.Modified;
                }
                else
                {
                    dbContext.Products.Add(product);
                    dbContext.Entry(product.ProductModel).State = EntityState.Modified;
                    dbContext.Entry(product.ProductModel.Manufacturer).State = EntityState.Modified;
                    dbContext.Entry(product.Location.Warehouse).State = EntityState.Modified;
                }

                dbContext.SaveChanges();
            }
        }

        public void SaveModel(ProductModel productModel)
        {
            using (var dbContext = new WarehouseContext())
            {
                if (productModel.Id.HasValue)
                {
                    dbContext.Entry(productModel).State = EntityState.Modified;
                    dbContext.Entry(productModel.Manufacturer).State = EntityState.Modified;
                }
                else
                {
                    dbContext.ProductModels.Add(productModel);
                    dbContext.Entry(productModel.Manufacturer).State = EntityState.Modified;
                }

                dbContext.SaveChanges();
            }
        }
    }
}