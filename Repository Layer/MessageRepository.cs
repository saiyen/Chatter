using AutoMapper;
using Repository_Layer.DatabaseContexts;
using Repository_Layer.DtoModels;
using Microsoft.EntityFrameworkCore;
using Repository_Layer.DtoModels;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Repository_Layer
{
    public class MessageRepository : IMessageRepository, IDisposable
    {
        private readonly ChatContext _context;
        private readonly IMapper _mapper;

        public MessageRepository(ChatContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public void DeleteMessage(int messageID)
        {
            var message = _context.Messages.Find(messageID);
            _context.Messages.Remove(message);
        }

        public void Dispose()
        {
            Console.WriteLine("- {0} was disposed!", GetType().Name);
        }

        public MessageDTO GetMessageByID(int messageID)
        {
            return _mapper.Map<MessageDTO>(_context.Messages.Find(messageID));
        }

        public IEnumerable<MessageDTO> GetMessages()
        {
            //return _mapper.Map<List<MessageDTO>>( _context.Messages
            //            .Include(message => message.MessageRecipient)
            //                .ThenInclude(recipient => recipient.Users).ToList() );

            return _mapper.Map<List<MessageDTO>>(_context.Messages);
        }

        public IEnumerable<MessageDTO> GetMessagesForMainChat()
        {

            return _mapper.Map<List<MessageDTO>>(_context.Messages
                                                    .Include(x => x.Sender)
                                                    .Where(y => y.MessageRecipient.FirstOrDefault().RecipientId == Guid.Parse("c5218b69-59d6-4ca8-b685-952961ecf48f")));
        }

        public void InsertMessage(MessageDTO message)
        {
            var messageEntity = _mapper.Map<MessageEntity>(message);
            _context.Messages.Add(messageEntity);
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public void UpdateMessage(MessageDTO message)
        {
            var messageEntity = _mapper.Map<MessageEntity>(message);
            _context.Entry(messageEntity).State = EntityState.Modified;
        }
    }
}
