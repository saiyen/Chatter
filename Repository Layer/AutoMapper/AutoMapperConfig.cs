using AutoMapper;
using Repository_Layer.DtoModels;
using Repository_Layer.DtoModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repository_Layer.AutoMapper
{
    public class AutoMapperConfig : Profile
    {
        public AutoMapperConfig()
        {
            CreateMap<UserEntity, UserDTO>();
            CreateMap<UserDTO, UserEntity>();

            CreateMap<MessageRecipientEntity, MessageRecipientDTO>();
            CreateMap<MessageRecipientDTO, MessageRecipientEntity>();

            CreateMap<MessageEntity, MessageDTO>();
            CreateMap<MessageDTO, MessageEntity>();
        }
    }
}
