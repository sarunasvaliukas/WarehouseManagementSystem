using System.Collections.Generic;
using WarehouseSystem.DataAccess;

namespace WarehouseSystem.Repository.Interfaces
{
    public interface IProductRepository
    {
        IList<Product> GetProducts();

        Product GetProduct(long id);

        IList<Product> GetProductsByModel(long modelId);

        ProductModel GetProductModel(long id);

        IList<ProductModel> GetProductModels();

        ProductModel GetProductModelWithManufacturer(long id);

        IList<ProductModel> GetProductModelsWithManufacturers();

        void Delete(Product product);

        void Save(Product product);

        void SaveModel(ProductModel productModel);

        int GetProductCount(long productModelId);
    }
}
