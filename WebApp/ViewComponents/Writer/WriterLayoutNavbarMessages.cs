using Business.Abstract;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace WebApp.ViewComponents.Writer
{
    public class WriterLayoutNavbarMessages : ViewComponent
    {
        private IMessageService _messageService;

        public WriterLayoutNavbarMessages(IMessageService messageService)
        {
            _messageService = messageService;
        }

        public IViewComponentResult Invoke(int receiverId)
        {
            var result = _messageService.GetAllByReceiverId(receiverId).Where(x => !x.MessageStatus).ToList();

            return View(result);
        }
    }
}
