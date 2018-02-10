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
    public class UserController : Controller
    {
        private IOrderRepository orderRepository = new OrderRepository();

        public ActionResult Index()
        {
            return View(orderRepository.getOrders());
        }

        public ActionResult CreateOrder()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateOrder(Order order)
        {
            if (ModelState.IsValid)
            {
                orderRepository.addOrder(order);
                return RedirectToAction("Index");
            }

            return View(order);
        }

        public ActionResult EditOrder(int id = 0)
        {
            Order order = orderRepository.getOrder(id);
            if (order == null)
            {
                return HttpNotFound();
            }
            return View(order);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditOrder(Order order)
        {
            if (ModelState.IsValid)
            {
                orderRepository.editOrderDetails(order);
                return RedirectToAction("Index");
            }
            return View(order);
        }

        public ActionResult DeleteOrder(int id = 0)
        {
            Order order = orderRepository.getOrder(id);
            if (order == null)
            {
                return HttpNotFound();
            }
            return View(order);
        }

        [HttpPost, ActionName("DeleteOrder")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            orderRepository.deleteOrder(id);
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
        }
    }
}
