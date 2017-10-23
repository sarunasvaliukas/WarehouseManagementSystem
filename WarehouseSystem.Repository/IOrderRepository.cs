using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarehouseSystem.DataAccess;

namespace WarehouseSystem.Repository
{
    public interface IOrderRepository
    {
        IList<Order> GetOrders();

        Order GetOrder(long id);

        void Save(Order order);

        void Delete(Order order);
    }
}
