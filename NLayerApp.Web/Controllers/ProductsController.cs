using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using NLayerApp.Core.DTOs;
using NLayerApp.Core.Entities;
using NLayerApp.Web.Filters;
using NLayerApp.Web.Services;

namespace NLayerApp.Web.Controllers
{
    public class ProductsController : Controller
    {
        private readonly ProductApiService _productApiService;
        private readonly CategoryApiService _categoryApiService;

        public ProductsController(ProductApiService productApiService, CategoryApiService categoryApiService)
        {
            _productApiService = productApiService;
            _categoryApiService = categoryApiService;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _productApiService.GetProductsWithCategory());

        }
        public async Task<IActionResult> Save()
        {
            var categories = await _categoryApiService.GetAllAsync();

            ViewBag.categories = new SelectList(categories, nameof(CategoryDto.Id), nameof(CategoryDto.Name));

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Save(ProductDto productDto)
        {
            if (ModelState.IsValid)
            {
                await _productApiService.Save(productDto);

                return RedirectToAction("Index");
            }

            var categories = await _categoryApiService.GetAllAsync();

            ViewBag.categories = new SelectList(categories, nameof(CategoryDto.Id), nameof(CategoryDto.Name));

            return View();
        }

        [ServiceFilter(typeof(NotFoundFilter<Product>))]
        public async Task<IActionResult> Update(int id)
        {
            var product = await _productApiService.GetById(id);

            var categories = await _categoryApiService.GetAllAsync();

            ViewBag.categories = new SelectList(categories, nameof(CategoryDto.Id), nameof(CategoryDto.Name));

            return View(product);
        }

        [HttpPost]
        public async Task<IActionResult> Update(ProductDto productDto)
        {
            if (ModelState.IsValid)
            {
                await _productApiService.Update(productDto);

                return RedirectToAction("Index");
            }

            var categories = await _categoryApiService.GetAllAsync();

            ViewBag.categories = new SelectList(categories, nameof(CategoryDto.Id), nameof(CategoryDto.Name));

            return View();
        }

        [ServiceFilter(typeof(NotFoundFilter<Product>))]
        public async Task<IActionResult> Remove(int id)
        {
            await _productApiService.Remove(id);

            return RedirectToAction("Index");
        }

    }
}
