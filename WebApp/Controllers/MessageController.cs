using Business.Abstract;
using Business.ValidationRules.FluentValidation;
using Entities.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;

namespace WebApp.Controllers
{
    public class MessageController : Controller
    {
        private IMessageService _messageService;
        private IWriterService _writerService;

        private MessageValidator messageValidator = new MessageValidator();
        private ValidationResult validation;

        public MessageController(IMessageService messageService, IWriterService writerService)
        {
            _messageService = messageService;
            _writerService = writerService;
        }

        public IActionResult Inbox(int userId)
        {
            var result = _messageService.GetAllByReceiverId(userId);

            return View(result);
        }

        public IActionResult Sendbox(int userId)
        {
            var result = _messageService.GetAllBySenderId(userId);

            return View(result);
        }

        public IActionResult Read(int messageId)
        {
            var result = _messageService.GetByMessageId(messageId);

            return View(result);
        }

        [HttpGet]
        public IActionResult NewMessage(int? receiverId, string? subject)
        {
            var message = receiverId != null && subject != null ? new Message { ReceiverUserId = receiverId, MessageSubject = subject } : null;

            ViewBag.Writers = GetWritersSeletListItems(Convert.ToInt32(User.Claims.SingleOrDefault(x => x.Type == "UserId").Value));

            return View(message);
        }

        [HttpPost]
        public IActionResult NewMessage(Message message)
        {
            message.SenderUserId = Convert.ToInt32(User.Claims.SingleOrDefault(x => x.Type == "UserId").Value);

            validation = messageValidator.Validate(message);

            if (validation.IsValid)
            {
                _messageService.Add(message);

                return RedirectToAction("Sendbox");
            }

            foreach (var item in validation.Errors)
            {
                ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
            }

            ViewBag.Writers = GetWritersSeletListItems(Convert.ToInt32(User.Claims.SingleOrDefault(x => x.Type == "UserId").Value));

            return View();
        }

        public ICollection<SelectListItem> GetWritersSeletListItems(int userId)
        {
            return (from x in _writerService.GetAllWithoutUserId(userId)
                    select new SelectListItem
                    {
                        Text = x.User.UserFirstName + " " + x.User.UserLastName + " (" + x.User.UserEmail + ")",
                        Value = x.UserId.ToString()
                    }).ToList();
        }
    }
}
