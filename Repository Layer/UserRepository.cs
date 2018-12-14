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
    public class UserRepository : IUserRepository, IDisposable
    {
        private readonly ChatContext _context;
        private readonly IMapper _mapper;

        public UserRepository(ChatContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public void DeleteUser(int userID)
        {
            var user = _context.Users.Find(userID);
            _context.Users.Remove(user);
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public UserDTO GetUserByID(int userID)
        {
            return _mapper.Map<UserDTO>(_context.Users.Find(userID));
        }

        public IEnumerable<UserDTO> GetUsers()
        {
            return _mapper.Map<List<UserDTO>>(_context.Users.ToList());
        }

        public void InsertUser(UserDTO user)
        {
            var userEntity = _mapper.Map<UserEntity>(user);
            _context.Users.Add(userEntity);
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public void UpdateUser(UserDTO user)
        {
            var userEntity = _mapper.Map<UserEntity>(user);
            _context.Entry(userEntity).State = EntityState.Modified;
        }
    }
}
