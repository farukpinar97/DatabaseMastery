using DatabaseMastery.DinnerMenuPostgreSQL.Services.ProductServices;
using DatabaseMastery.DinnerMenuPostgreSQL.Services.CategoryServices;
using Microsoft.AspNetCore.Mvc;

namespace DatabaseMastery.DinnerMenuPostgreSQL.Controllers
{
    public class MenuController : Controller
    {
        private readonly IProductService _productService;
        private readonly ICategoryService _categoryService;

        public MenuController(IProductService productService, ICategoryService categoryService)
        {
            _productService = productService;
            _categoryService = categoryService;
        }

        public async Task<IActionResult> Index(int? categoryId)
        {
            var products = await _productService.GetAllProductsAsync();
            var categories = await _categoryService.GetAllCategoriesAsync();

            ViewBag.Categories = categories;
            ViewBag.SelectedCategoryId = categoryId;

            var filteredProducts = categoryId.HasValue
                ? products.Where(p => p.CategoryId == categoryId.Value && p.Status).ToList()
                : products.Where(p => p.Status).ToList();

            return View(filteredProducts);
        }
    }
}