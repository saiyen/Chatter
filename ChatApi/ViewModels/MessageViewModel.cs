using System;
using System.Collections.Generic;
using System.Text;

namespace ChatApi.ViewModels
{
    public class MessageViewModel
    {
        public Guid Id { get; set; }
        public DateTime SentDate { get; set; }
        public DateTime ReceivedDate { get; set; }
        public string Content { get; set; }
        public bool IsDeleted { get; set; }
        public UserViewModel Sender { get; set; }

        public ICollection<MessageRecipientViewModel> MessageRecipient { get; set; }
    }
}
