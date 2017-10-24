using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using WarehouseSystem.DataAccess;
using WarehouseSystem.Repository.Interfaces;

namespace WarehouseSystem.Repository.Implemanations
{
    public class OrderRepository : IOrderRepository
    {
        public IList<Order> GetOrders()
        {
            using (var dbContext = new WarehouseContext())
            {
                return dbContext.Orders.Include(o => o.ProductModel).ToList();
            }
        }

        public Order GetOrder(long id)
        {
            using (var dbContext = new WarehouseContext())
            {
                return dbContext.Orders.FirstOrDefault(p => p.Id == id);
            }
        }

        public void Save(Order order)
        {
            using (var dbContext = new WarehouseContext())
            {
                if (order.Id.HasValue)
                {
                    dbContext.Entry(order).State = System.Data.Entity.EntityState.Modified;
                    dbContext.Entry(order.ProductModel).State = EntityState.Modified;
                    dbContext.Entry(order.ProductModel.Manufacturer).State = EntityState.Modified;
                }
                else
                {
                    dbContext.Orders.Add(order);
                    dbContext.Entry(order.ProductModel).State = EntityState.Modified;
                    dbContext.Entry(order.ProductModel.Manufacturer).State = EntityState.Modified;
                }

                dbContext.SaveChanges();
            }
        }

        public void Delete(Order order)
        {
            using (var dbContext = new WarehouseContext())
            {
                dbContext.Entry(order).State = EntityState.Deleted;
                dbContext.SaveChanges();
            }
        }
    }
}