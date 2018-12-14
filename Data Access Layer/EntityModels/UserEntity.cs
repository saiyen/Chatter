using System;
using System.Collections.Generic;
using System.Text;

namespace Repository_Layer.DtoModels
{
    public class UserEntity
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }
        public bool IsDeleted { get; set; }

        public ICollection<MessageRecipientEntity> MessageRecipient { get; set; }
    }
}
