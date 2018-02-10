using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace Taxi.Models
{
    public class OrderRepository: IOrderRepository
    {
        private OrderDBContext orderDb = new OrderDBContext();

        public void addOrder(Order order)
        {
            order.status = "Available";
            orderDb.orders.Add(order);
            orderDb.SaveChanges();
        }

        public void changeOrderStatus(int id, string orderStatus)
        {
            Order order = orderDb.orders.Find(id);
            order.status = orderStatus;
            orderDb.Entry(order).State = EntityState.Modified;
            orderDb.SaveChanges();
        }

        public void deleteOrder(int id)
        {
            Order order = orderDb.orders.Find(id);
            orderDb.orders.Remove(order);
            orderDb.SaveChanges();
        }

        public void editOrderDetails(Order order)
        {
            order.status = "Available";
            orderDb.Entry(order).State = EntityState.Modified;
            orderDb.SaveChanges();
        }

        public Order getOrder(int id)
        {
            return orderDb.orders.Find(id);
        }

        public List<Order> getOrders()
        {
            return orderDb.orders.ToList();
        }
    }
}
