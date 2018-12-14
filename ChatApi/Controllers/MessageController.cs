using AutoMapper;
using ChatApi.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Repository_Layer;
using System.Collections.Generic;

namespace ChatApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MessageController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IMessageRepository _messageRepo;

        public MessageController(IMapper mapper, IMessageRepository messageRepo)
        {
            _messageRepo = messageRepo;
            _mapper = mapper;
        }

        [HttpGet]
        public IEnumerable<MessageViewModel> Get()
        {
            //var test = JsonConvert.SerializeObject(_mapper.Map<List<MessageViewModel>>(_messageRepo.GetMessages()), Formatting.None,
            //     new JsonSerializerSettings()
            //     {
            //         ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            //     });

            return _mapper.Map<List<MessageViewModel>>(_messageRepo.GetMessages());
        }

        [Route("GetMessagesForMainChat")]
        [HttpGet]
        public IEnumerable<MessageViewModel> GetMessagesForMainChat()
        {
            return _mapper.Map<List<MessageViewModel>>(_messageRepo.GetMessagesForMainChat());
        }
    }
}