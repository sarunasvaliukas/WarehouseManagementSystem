using System.Collections.Generic;
using WarehouseSystem.DataAccess;

namespace WarehouseSystem.Repository.Interfaces
{
    public interface IOrderRepository
    {
        IList<Order> GetOrders();

        Order GetOrder(long id);

        void Save(Order order);

        void Delete(Order order);
    }
}
