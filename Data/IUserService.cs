using System.Collections.Generic;
using FoodbWebAPI.Dtos;
using FoodbWebAPI.Models;

namespace FoodbWebAPI.Data
{
    public interface IUserService
    {
        bool SaveChanges();
        IEnumerable<User> GetAllUsers();
        User GetUserById(int id);
        void CreateUser(UserCreateDto user);
        string Authenticate(LoginDto credentials);
    }
}