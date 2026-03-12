using Microsoft.AspNetCore.Mvc;
using ChatApp.Models;

namespace ChatApp.Controllers
{
    public class ChatController : Controller
    {
        private static readonly List<KeyValuePair<string, string>> Messages = new();

        public IActionResult Show()
        {
            var model = new ChatViewModel();
            if (Messages.Any())
            {
                model.Messages = Messages.Select(m => new MessageViewModel
                {
                    Sender = m.Key,
                    MessageText = m.Value
                }).ToList();
            }

            return View(model);
        }

        [HttpPost]
        public IActionResult Send(ChatViewModel chat)
        {
            if (ModelState.IsValid && !string.IsNullOrWhiteSpace(chat.CurrentMessage.Sender) && !string.IsNullOrWhiteSpace(chat.CurrentMessage.MessageText))
            {
                Messages.Add(new KeyValuePair<string, string>(chat.CurrentMessage.Sender, chat.CurrentMessage.MessageText));
            }

            return RedirectToAction("Show");
        }
    }
}
