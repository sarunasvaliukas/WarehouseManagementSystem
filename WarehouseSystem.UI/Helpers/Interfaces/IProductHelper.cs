using System.Collections.Generic;
using WarehouseSystem.UI.Models;

namespace WarehouseSystem.UI.Helpers.Interfaces
{
    public interface IProductHelper
    {
        IList<ProductView> GetProducts();

        ProductView GetProduct(long id);

        ProductModelView GetProductModel(long id);

        IList<ProductModelView> GetProductModels();

        WarehouseView GetWarehouse(long id);

        IList<WarehouseView> GetWarehouses();

        void Delete(long id);

        void Save(ProductView productView);

        void SaveModel(ProductModelView productModelView);

        IList<ProductView> GetProductsByModel(long modelId);
    }
}
