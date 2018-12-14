using System;
using System.Collections.Generic;
using System.Text;

namespace Repository_Layer.DtoModels
{
    public class MessageRecipientDTO
    {
        public Guid MessageId { get; set; }
        public Guid RecipientId { get; set; }

        public UserDTO Users { get; set; }
        public MessageDTO Messages { get; set; }
    }
}
