using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Taxi.Models
{
    public interface IOrderRepository
    {
        void addOrder(Order order);
        void changeOrderStatus(int id, string orderStatus);
        void deleteOrder(int id);
        void editOrderDetails(Order order);
        Order getOrder(int id);
        List<Order> getOrders();
    }
}
