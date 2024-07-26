using AutoMapper;
using UserManagement.DataAccess.Entities;
using UserManagment.Contract.Dtos;
using UserManagment.Contract.Request;

namespace UseManagment.Business.Mapping
{
    public class MapProfile : Profile
    {
        public MapProfile() { 
        CreateMap<UserEntity,UserDto>().ReverseMap();
        CreateMap<UserCreate,UserEntity>();
        CreateMap<UserUpdate,UserEntity>();
        }
    }
}
