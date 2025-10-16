using Microsoft.AspNetCore.Mvc;
using SimpleMarketApp.Data;
using SimpleMarketApp.Models;
using System.Linq;
using System.Collections.Generic;

namespace SimpleMarketApp.Controllers
{
    public class MarketController : Controller
    {
        private readonly AppDbContext _context;
        private static List<Item> cartItems = new List<Item>(); // ✅ renamed

        public MarketController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var items = _context.Items.ToList();
            return View(items);
        }

        [HttpPost]
        public IActionResult AddToCart(int id)
        {
            var item = _context.Items.Find(id);
            if (item != null)
                cartItems.Add(item);

            return RedirectToAction("Cart");
        }

        public IActionResult Cart()
        {
            ViewBag.Total = cartItems.Sum(i => i.Price);
            return View(cartItems);
        }

        [HttpPost]
        public IActionResult Purchase()
        {
            cartItems.Clear();
            ViewBag.Message = "Purchase Successful!";
            return View("Cart", cartItems);
        }
    }
}
