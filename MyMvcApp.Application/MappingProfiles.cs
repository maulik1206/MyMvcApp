using AutoMapper;
using MyMvcApp.Application.DTOs;
using MyMvcApp.Domain.Entities;

namespace MyMvcApp.Application
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            // Map Entity <-> DTO
            CreateMap<User, UserDTO>().ReverseMap();
        }
    }
}
