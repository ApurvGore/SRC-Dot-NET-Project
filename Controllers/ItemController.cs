using CanteenManagement.Models;
using CanteenManagement.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CanteenManagement.Controllers
{
    public class ItemController : Controller
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly Cart _cart;
        public ItemController(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
            _cart = new Cart();
        }
        public IActionResult AllItems()
        {
            var items= _dbContext.Item.ToList();
            return View(items);
        }

        [HttpPost]
        public IActionResult AddItem(Item newItem)
        {
            if (ModelState.IsValid)
            {
                _dbContext.Item.Add(newItem);
                _dbContext.SaveChanges();

                return RedirectToAction("AllItems");
            }

            return View("AddItem", newItem);
        }

        [HttpGet]
        public async Task<IActionResult> DeleteItem(int Id)
        {
            var item =_dbContext.Item.FirstOrDefault(x => x.Id == Id);
            var result = _dbContext.Item.Remove(item);
            var res= _dbContext.SaveChanges();
            return RedirectToAction("AllItems", "Item");
        }

        [HttpGet]
        public async Task<IActionResult> EditItem(string Id)
        {
            var item = _dbContext.Item.FirstOrDefault(x => x.Id ==Convert.ToInt32(Id));
            Items items = new Items
            {
                Name = item.Name,
                Price = item.Price,
                AvailableItems = item.AvailableItems
            };

            return PartialView("_UpdateItem", items);
        }

        [HttpPost]
        public async Task<IActionResult> EditItem(Items item)
        {
            Item itm = _dbContext.Item.FirstOrDefault(x => x.Id == item.Id);
            itm.Name = item.Name;
            itm.Price = item.Price;
            itm.AvailableItems = item.AvailableItems;

            var update = _dbContext.Item.Update(itm);
            _dbContext.SaveChanges();
            return RedirectToAction("AllItems", "Item");
        }

        public IActionResult AddToCart(int productId)
        {
            var product = _dbContext.Item.Find(productId);

            if (product != null)
            {
                CartItem existingItem = _cart.Items.FirstOrDefault(item => item.Item.Id == productId);

                if (existingItem != null)
                {
                    existingItem.Quantity++;
                }
                else
                {
                    _cart.Items.Add(new CartItem { Item = product, Quantity = 1 });
                }
            }

            return RedirectToAction("Index");
        }

    }
}
