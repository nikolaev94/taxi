using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Taxi.Models;

namespace Taxi.Controllers
{
    public class DriverController : Controller
    {
        private IOrderRepository orderRepository = new OrderRepository();

        public ActionResult Index()
        {
            return View(orderRepository.getOrders());
        }

        public ActionResult ShowOrderDetails(int id = 0)
        {
            Order order = orderRepository.getOrder(id);
            if (order == null)
            {
                return HttpNotFound();
            }
            return View(order);
        }

        public ActionResult TakeOrder(int id = 0)
        {
            orderRepository.changeOrderStatus(id, "Taken");
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
        }
    }
}
