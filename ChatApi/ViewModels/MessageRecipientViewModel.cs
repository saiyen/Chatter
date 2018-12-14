using System;
using System.Collections.Generic;
using System.Text;

namespace ChatApi.ViewModels
{
    public class MessageRecipientViewModel
    {
        public Guid MessageId { get; set; }
        public Guid RecipientId { get; set; }

        public UserViewModel Users { get; set; }
        public MessageViewModel Messages { get; set; }
    }
}
