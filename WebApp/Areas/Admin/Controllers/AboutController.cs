using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Entities.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using System;
using System.IO;
using System.Linq;

namespace WebApp.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AboutController : Controller
    {
        private IAboutService _aboutService;

        private AboutValidator aboutValidator = new AboutValidator();
        private ValidationResult validation;

        public AboutController(IAboutService aboutService)
        {
            _aboutService = aboutService;
        }

        public IActionResult Index()
        {
            var result = _aboutService.GetAll().OrderByDescending(x => x.AboutId).ToList();

            return View(result);
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(About about)
        {
            if (Request.Form.Files["AboutImage"] is not null && Request.Form.Files["AboutThumbnailImage"] is not null)
            {
                string fileName = Guid.NewGuid().ToString() + Path.GetExtension(Request.Form.Files[0].FileName);
                string path = Path.Combine(Directory.GetCurrentDirectory(), Defaults.DEFAULT_IMAGE_UPLOAD_PATH, fileName);

                var stream = new FileStream(path, FileMode.Create);
                Request.Form.Files["AboutImage"].CopyTo(stream);

                about.AboutImageUrl = Defaults.DEFAULT_IMAGE_URL_PATH + fileName;

                fileName = Guid.NewGuid().ToString() + Path.GetExtension(Request.Form.Files[1].FileName);
                path = Path.Combine(Directory.GetCurrentDirectory(), Defaults.DEFAULT_IMAGE_UPLOAD_PATH, fileName);

                stream = new FileStream(path, FileMode.Create);
                Request.Form.Files["AboutThumbnailImage"].CopyTo(stream);

                about.AboutThumbnailImageUrl = Defaults.DEFAULT_IMAGE_URL_PATH + fileName;

                stream.Close();
            }

            validation = aboutValidator.Validate(about);

            if (validation.IsValid)
            {
                _aboutService.Add(about);

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
            var result = _aboutService.GetById(id);

            return View(result);
        }

        [HttpPost]
        public IActionResult Update(About about)
        {
            var result = _aboutService.GetById(about.AboutId);

            if (Request.Form.Files["AboutImage"] is null)
                about.AboutImageUrl = result.AboutImageUrl;

            if (Request.Form.Files["AboutThumbnailImage"] is null)
                about.AboutThumbnailImageUrl = result.AboutThumbnailImageUrl;

            if (Request.Form.Files["AboutImage"] is not null && Request.Form.Files["AboutThumbnailImage"] is not null)
            {
                string fileName = Guid.NewGuid().ToString() + Path.GetExtension(Request.Form.Files[0].FileName);
                string path = Path.Combine(Directory.GetCurrentDirectory(), Defaults.DEFAULT_IMAGE_UPLOAD_PATH, fileName);

                var stream = new FileStream(path, FileMode.Create);
                Request.Form.Files["AboutImage"].CopyTo(stream);

                about.AboutImageUrl = Defaults.DEFAULT_IMAGE_URL_PATH + fileName;

                fileName = Guid.NewGuid().ToString() + Path.GetExtension(Request.Form.Files[1].FileName);
                path = Path.Combine(Directory.GetCurrentDirectory(), Defaults.DEFAULT_IMAGE_UPLOAD_PATH, fileName);

                stream = new FileStream(path, FileMode.Create);
                Request.Form.Files["AboutThumbnailImage"].CopyTo(stream);

                about.AboutThumbnailImageUrl = Defaults.DEFAULT_IMAGE_URL_PATH + fileName;

                stream.Close();
            }

            validation = aboutValidator.Validate(about);

            if (validation.IsValid)
            {
                _aboutService.Update(about);

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
            var result = _aboutService.GetById(id);

            result.AboutStatus = !result.AboutStatus;

            _aboutService.Update(result);

            return RedirectToAction("Index");
        }
    }
}
