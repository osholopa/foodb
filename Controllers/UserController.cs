using System.Collections.Generic;
using FoodbWebAPI.Data;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using FoodbWebAPI.Dtos;
using FoodbWebAPI.Models;
using Microsoft.Extensions.Options;
using FoodbWebAPI.Helpers;

namespace FoodbWebAPI.Controllers
{
    [Route("api/users")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IMapper _mapper;

        public UserController(IUserService userSvc, IMapper mapper)
        {
            _userService = userSvc;
            _mapper = mapper;
        }

        // GET api/users
        [HttpGet]
        public ActionResult<IEnumerable<Models.Recipe>> GetAllUsers()
        {
            var users = _userService.GetAllUsers();
            return Ok(_mapper.Map<IEnumerable<UserReadDto>>(users));
        }

        // GET api/users/{id}
        [HttpGet("{id}", Name = "GetUserById")]
        public ActionResult<Models.User> GetUserById(int id)
        {
            var user = _userService.GetUserById(id);
            if (user != null)
            {
                return Ok(_mapper.Map<UserReadDto>(user));
            }
            return NotFound();
        }

        // POST api/users
        [HttpPost]
        public ActionResult<UserReadDto> CreateUser(UserCreateDto userCreateDto)
        {

            try
            {
                _userService.CreateUser(userCreateDto);
                _userService.SaveChanges();
        
                return Ok();
            }
            catch (System.Exception)
            {
                return BadRequest("Username already exists");
            }
        }





    }
}