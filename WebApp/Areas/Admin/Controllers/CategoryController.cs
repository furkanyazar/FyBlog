using Business.Abstract;
using Business.ValidationRules.FluentValidation;
using Entities.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;

namespace WebApp.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CategoryController : Controller
    {
        private ICategoryService _categoryService;

        private CategoryValidator categoryValidator = new CategoryValidator();
        private ValidationResult validation;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        public IActionResult Index()
        {
            var result = _categoryService.GetAll();

            return View(result);
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(Category category)
        {
            validation = categoryValidator.Validate(category);

			if (validation.IsValid)
			{
                _categoryService.Add(category);

                return RedirectToAction("Index");
			}

            foreach (var item in validation.Errors)
            {
                ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
            }

            return View();
        }

        [HttpGet]
        public IActionResult Update(int id)
        {
            var result = _categoryService.GetById(id);

            return View(result);
        }

        [HttpPost]
        public IActionResult Update(Category category)
        {
            validation = categoryValidator.Validate(category);

            if (validation.IsValid)
            {
                _categoryService.Update(category);

                return RedirectToAction("Index");
            }

            foreach (var item in validation.Errors)
            {
                ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
            }

            return View();
        }

        public IActionResult Delete(int id)
		{
            var result = _categoryService.GetById(id);

            result.CategoryStatus = !result.CategoryStatus;

            _categoryService.Update(result);

            return RedirectToAction("Index");
		}
    }
}
