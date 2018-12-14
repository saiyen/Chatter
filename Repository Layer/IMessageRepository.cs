using Repository_Layer.DtoModels;
using System;
using System.Collections.Generic;

namespace Repository_Layer
{
    public interface IMessageRepository : IDisposable
    {
        IEnumerable<MessageDTO> GetMessages();
        IEnumerable<MessageDTO> GetMessagesForMainChat();
        MessageDTO GetMessageByID(int MessageID);
        void InsertMessage(MessageDTO Message);
        void DeleteMessage(int MessageID);
        void UpdateMessage(MessageDTO Message);
        void Save();
    }
}
