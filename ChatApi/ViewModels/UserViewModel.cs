using System;
using System.Collections.Generic;
using System.Text;

namespace ChatApi.ViewModels
{
    public class UserViewModel
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }
        public bool IsDeleted { get; set; }

        public ICollection<MessageRecipientViewModel> MessageRecipient { get; set; }
    }
}
