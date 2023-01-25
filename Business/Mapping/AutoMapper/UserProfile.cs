using AutoMapper;
using Core.Entities.Concrete;
using Entities.ViewModels.UserVM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Mapping.AutoMapper
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<User, CreateUserVM>();
            CreateMap<CreateUserVM, User>();

            CreateMap<User, LoginUserVM>();
            CreateMap<LoginUserVM, User>();

            CreateMap<User, UpdateUserVM>();
            CreateMap<UpdateUserVM, User>();

            CreateMap<User, DeleteUserVM>();
            CreateMap<DeleteUserVM, User>();
        }
    }
}
