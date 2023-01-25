using AutoMapper;
using Entities.Concrete;
using Entities.ViewModels.Author;
using Entities.ViewModels.Book;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Mapping.AutoMapper
{
    public class AuthorProfile : Profile
    {
        public AuthorProfile()
        {
            CreateMap<Author, CreateAuthorVM>();
            CreateMap<CreateAuthorVM, Author>();

            CreateMap<Author, UpdateAuthorVM>();
            CreateMap<UpdateAuthorVM, Author>();

            CreateMap<Author, DeleteAuthorVM>();
            CreateMap<DeleteAuthorVM, Author>();
        }
    }
}
