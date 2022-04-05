using AutoMapper;
using FoodbWebAPI.Models;
using FoodbWebAPI.Dtos;

namespace FoodbWebAPI.Profiles
{
  public class UsersProfile:Profile
  {
    public UsersProfile()
    {
      // Source -> target
      CreateMap<User, UserReadDto>();
      CreateMap<UserCreateDto, User>();      
    }
  }
}