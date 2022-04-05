using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using FoodbWebAPI.Helpers;
using FoodbWebAPI.Models;
using FoodbWebAPI.Auth;
using FoodbWebAPI.Dtos;

namespace FoodbWebAPI.Data
{
    public class UserService : IUserService
    {
        private readonly IMapper _mapper;
        private readonly IJwtAuthenticationManager _jwtManager;

        private readonly FooDBContext _context;

        public UserService(FooDBContext context, IMapper mapper, IJwtAuthenticationManager jwtManager)
        {
            _context = context;
            _mapper = mapper;
            _jwtManager = jwtManager;
        }

        public string Authenticate(LoginDto login)
        {
            var _users = _context.Users.ToList();
            var user = _users.SingleOrDefault(x => x.Username == login.Username);
            
            // Validate
            if(user == null || !BCrypt.Net.BCrypt.Verify(login.Password, user.PasswordHash))
            {
                return null;
            }

            // Auth successful, Generate JWT token
            var response = _jwtManager.GenerateToken(user);
            return response;
        }

        public void CreateUser(UserCreateDto newUser)
        {
            var _users = _context.Users.ToList();
            // Validate the request
            if(_users.Any(u => u.Username == newUser.Username))
            {
                throw new AppException("Username already exists");
            }

            // Map the DTO to a model
            var user = _mapper.Map<User>(newUser);

            // Hash the password
            user.PasswordHash = BCrypt.Net.BCrypt.HashPassword(newUser.Password);

            // Save the user
            _context.Users.Add(user);
        }




        public void DeleteUser(User user)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<User> GetAllUsers()
        {
            var _users = _context.Users.ToList();
            return _users;
        }

        public User GetUserById(int id)
        {
            var _users = _context.Users.ToList();
            var user = _users.Find(u => u.Id == id);   
            if(user == null) throw new KeyNotFoundException("User not found");
            return user;
        }

        public bool SaveChanges()
        {
            return (_context.SaveChanges() >= 0);
        }

        public void UpdateUser(User user)
        {
            throw new System.NotImplementedException();
        }
    }
}