using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
