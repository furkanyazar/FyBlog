using Business.Abstract;
using Business.ValidationRules.FluentValidation;
using Entities.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Linq;

namespace WebApp.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class NotificationController : Controller
    {
        private INotificationService _notificationService;
        private INotificationTypeService _notificationTypeService;

        private NotificationValidator notificationValidator = new NotificationValidator();
        private ValidationResult validation;

        public NotificationController(INotificationService notificationService, INotificationTypeService notificationTypeService)
        {
            _notificationService = notificationService;
            _notificationTypeService = notificationTypeService;
        }

        public IActionResult Index()
        {
            var result = _notificationService.GetAllWithIncludes();

            return View(result);
        }

        [HttpGet]
        public IActionResult Add()
        {
            ViewBag.Types = GetTypesSeletListItems();

            return View();
        }

        [HttpPost]
        public IActionResult Add(Notification notification)
        {
            validation = notificationValidator.Validate(notification);

            if (validation.IsValid)
            {
                _notificationService.Add(notification);

                return RedirectToAction("Index");
            }

            foreach (var item in validation.Errors)
            {
                ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
            }

            ViewBag.Types = GetTypesSeletListItems();

            return View();
        }

        [HttpGet]
        public IActionResult Update(int id)
        {
            var result = _notificationService.GetById(id);

            ViewBag.Types = GetTypesSeletListItems();

            return View(result);
        }

        [HttpPost]
        public IActionResult Update(Notification notification)
        {
            validation = notificationValidator.Validate(notification);

            if (validation.IsValid)
            {
                _notificationService.Update(notification);

                return RedirectToAction("Index");
            }

            foreach (var item in validation.Errors)
            {
                ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
            }

            ViewBag.Types = GetTypesSeletListItems();

            return View();
        }

        public IActionResult Delete(int id)
        {
            var result = _notificationService.GetById(id);

            result.NotificationStatus = !result.NotificationStatus;

            _notificationService.Update(result);

            return RedirectToAction("Index");
        }

        public ICollection<SelectListItem> GetTypesSeletListItems()
        {
            return (from x in _notificationTypeService.GetAll()
                    select new SelectListItem
                    {
                        Text = x.NotificationTypeName,
                        Value = x.NotificationTypeId.ToString()
                    }).ToList();
        }
    }
}
