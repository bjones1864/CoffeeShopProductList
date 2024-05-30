using CoffeeShopProductList.Models;
using Microsoft.AspNetCore.Mvc;

namespace CoffeeShopProductList.Controllers
{
    public class ProductController : Controller
    {
        ProductsDbContext productsDB = new ProductsDbContext();

        public IActionResult Index()
        {
            return View(productsDB.Products.OrderBy(p => p.Category).ThenBy(p => p.Name).ToList());
        }

        public IActionResult Details(int id)
        {
            return View(productsDB.Products.FirstOrDefault(p => p.Id == id));
        }

        public IActionResult CategoryDetails(int id)
        {
            Product prod = productsDB.Products.FirstOrDefault(p => p.Id == id);

            return View(productsDB.Products.Where(p => p.Category.ToLower() == prod.Category.ToLower()).ToList());
        }
    }
}
