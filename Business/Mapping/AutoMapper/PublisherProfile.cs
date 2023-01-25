using AutoMapper;
using Core.Entities.Concrete;
using Entities.ViewModels.Publisher;
using Entities.ViewModels.UserVM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.Concrete;

namespace Business.Mapping.AutoMapper
{
    public class PublisherProfile : Profile
    {
        public PublisherProfile()
        {
            CreateMap<Publisher, CreatePublisherVM>();
            CreateMap<CreatePublisherVM, Publisher>();

            CreateMap<Publisher, DeletePublisherVM>();
            CreateMap<DeletePublisherVM, Publisher>();

            CreateMap<Publisher, UpdatePublisherVM>();
            CreateMap<UpdatePublisherVM, Publisher>();
        }
            
    }
}
