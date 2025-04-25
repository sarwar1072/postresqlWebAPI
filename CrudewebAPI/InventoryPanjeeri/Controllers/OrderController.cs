using InventoryPanjeeri.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;

namespace InventoryPanjeeri.Controllers
{
    public class OrderController : Controller
    {
        private readonly ApplicationDbContext _context;
        private const string SessionKey = "OrderItems";

        public OrderController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var model = new OrderViewModel
            {
                Items = HttpContext.Session.GetObject<List<OrderItems>>(SessionKey) ?? new()
            };
            return View(model);
        }
        
        [HttpPost]
        public IActionResult AddItem(OrderViewModel model)
        {
            var itemList = HttpContext.Session.GetObject<List<OrderItems>>(SessionKey) ?? new();
            itemList.Add(model.NewItem);
            HttpContext.Session.SetObject(SessionKey, itemList);

            return RedirectToAction("Index");
        }
       
        public IActionResult RemoveItem(int index)
        {
            var itemList = HttpContext.Session.GetObject<List<OrderItems>>(SessionKey);
            if (itemList != null && index >= 0 && index < itemList.Count)
            {
                itemList.RemoveAt(index);
                HttpContext.Session.SetObject(SessionKey, itemList);
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> SaveOrder(OrderViewModel model)
        {
            var order = new Order
            {
                OrderNo = model.OrderNo,
                Date = model.Date,
                CustomerName = model.CustomerName,
                Items = HttpContext.Session.GetObject<List<OrderItems>>(SessionKey)
            };

            _context.Orders.Add(order);
            await _context.SaveChangesAsync();
            HttpContext.Session.Remove(SessionKey);

            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> UpdateOrder(OrderViewModel model)
        {
            var existing = await _context.Orders.Include(o => o.Items)
                .FirstOrDefaultAsync(o => o.OrderNo == model.OrderNo);

            if (existing == null)
                return NotFound();

            existing.Date = model.Date;
            existing.CustomerName = model.CustomerName;

            _context.OrderItems.RemoveRange(existing.Items);
            existing.Items = HttpContext.Session.GetObject<List<OrderItems>>(SessionKey);

            await _context.SaveChangesAsync();
            HttpContext.Session.Remove(SessionKey);

            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> DeleteOrder(OrderViewModel model)
        {
            var existing = await _context.Orders.Include(o => o.Items)
                .FirstOrDefaultAsync(o => o.OrderNo == model.OrderNo);

            if (existing == null)
                return NotFound();

            _context.OrderItems.RemoveRange(existing.Items);
            _context.Orders.Remove(existing);

            await _context.SaveChangesAsync();
            HttpContext.Session.Remove(SessionKey);

            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> Find(OrderViewModel model)
        {
            var order = await _context.Orders
                .Include(o => o.Items)
                .FirstOrDefaultAsync(o => o.OrderNo == model.OrderNo);

            if (order == null)
                return RedirectToAction("Index");

            var viewModel = new OrderViewModel
            {
                OrderNo = order.OrderNo,
                Date = order.Date,
                CustomerName = order.CustomerName,
                Items = order.Items
            };

            HttpContext.Session.SetObject(SessionKey, order.Items);
            return View("Index", viewModel);
        }

    }
}
