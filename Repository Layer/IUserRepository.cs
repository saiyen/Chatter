using Repository_Layer.DtoModels;
using System;
using System.Collections.Generic;

namespace Repository_Layer
{
    public interface IUserRepository : IDisposable
    {
        IEnumerable<UserDTO> GetUsers();
        UserDTO GetUserByID(int userID);
        void InsertUser(UserDTO user);
        void DeleteUser(int userID);
        void UpdateUser(UserDTO user);
        void Save();
    }
}
