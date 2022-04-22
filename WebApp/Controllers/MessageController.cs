using Business.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace WebApp.Controllers
{
    public class MessageController : Controller
    {
        private IMessageService _messageService;

        public MessageController(IMessageService messageService)
        {
            _messageService = messageService;
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
    }
}
