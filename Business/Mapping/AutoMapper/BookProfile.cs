using AutoMapper;
using Entities.Concrete;
using Entities.ViewModels.Book;
using Entities.ViewModels.Publisher;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Mapping.AutoMapper
{
    public class BookProfile : Profile
    {
        public BookProfile()
        {
            CreateMap<Book, CreateBookVM>();
            CreateMap<CreateBookVM, Book>();

            CreateMap<Book, UpdateBookVM>();
            CreateMap<UpdateBookVM, Book>();

            CreateMap<Book, DeleteBookVM>();
            CreateMap<DeleteBookVM, Book>();
        }
    }
}
