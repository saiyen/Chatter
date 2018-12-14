using System;
using System.Collections.Generic;
using System.Text;

namespace Repository_Layer.DtoModels
{
    public class MessageDTO
    {
        public Guid Id { get; set; }
        public DateTime SentDate { get; set; }
        public DateTime ReceivedDate { get; set; }
        public string Content { get; set; }
        public bool IsDeleted { get; set; }
        public UserDTO Sender { get; set; }

        public ICollection<MessageRecipientDTO> MessageRecipient { get; set; }
    }
}
