namespace ChatApp.Models
{
    public class MessageViewModel
    {
        public string Sender { get; set; } = null!;
        public string MessageText { get; set; } = null!;
    }

    public class ChatViewModel
    {
        public List<MessageViewModel> Messages { get; set; } = new();
        public MessageViewModel CurrentMessage { get; set; } = new();
    }
}
