using DatabaseMastery.DinnerMenuPostgreSQL.Dtos.ContactDtos;
using DatabaseMastery.DinnerMenuPostgreSQL.Services.ProductServices;
using DatabaseMastery.DinnerMenuPostgreSQL.Services.CategoryServices;
using DatabaseMastery.DinnerMenuPostgreSQL.Services.ContactServices;
using Microsoft.AspNetCore.Mvc;

namespace DatabaseMastery.DinnerMenuPostgreSQL.Controllers
{
    public class HomeController : Controller
    {
        private readonly IProductService _productService;
        private readonly ICategoryService _categoryService;
        private readonly IContactService _contactService;

        public HomeController(
            IProductService productService,
            ICategoryService categoryService,
            IContactService contactService)
        {
            _productService = productService;
            _categoryService = categoryService;
            _contactService = contactService;
        }

        public async Task<IActionResult> Index()
        {
            var products = await _productService.GetAllProductsAsync();
            var categories = await _categoryService.GetAllCategoriesAsync();
            ViewBag.Categories = categories;
            return View(products);
        }

        public async Task<IActionResult> Gallery()
        {
            var products = await _productService.GetAllProductsAsync();
            return View(products);
        }

        [HttpGet]
        public IActionResult Contact()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Contact(CreateContactDto dto)
        {
            if (!ModelState.IsValid)
                return View(dto);

            await _contactService.CreateContactAsync(dto);

            TempData["Success"] = "Mesajýnýz alýndý, en kýsa sürede dönüþ yapacaðýz.";
            return RedirectToAction("Contact");
        }
    }
}