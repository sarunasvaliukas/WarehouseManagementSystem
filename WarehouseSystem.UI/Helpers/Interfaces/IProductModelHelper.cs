using System.Collections.Generic;
using WarehouseSystem.UI.Models;

namespace WarehouseSystem.UI.Helpers.Interfaces
{
    public interface IOrderHelper
    {
        IList<OrderView> GetOrders();
    }
}
