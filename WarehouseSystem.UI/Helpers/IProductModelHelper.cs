using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarehouseSystem.UI.Models;

namespace WarehouseSystem.UI.Helpers
{
    public interface IOrderHelper
    {
        IList<OrderView> GetOrders();
    }
}
