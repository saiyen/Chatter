using System;
using System.Collections.Generic;
using System.Text;

namespace Repository_Layer.DtoModels
{
    public class MessageRecipientEntity
    {
        public Guid MessageId { get; set; }
        public Guid? RecipientId { get; set; }

        public UserEntity Users { get; set; }
        public MessageEntity Messages { get; set; }
    }
}
