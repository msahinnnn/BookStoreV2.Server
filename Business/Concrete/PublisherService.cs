using AutoMapper;
using Business.Abstract;
using Business.ValidationRules.FluentValidation;
using Core.CrossCuttingConcerns.Validation;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using Entities.ViewModels.Book;
using Entities.ViewModels.Publisher;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class PublisherService : IPublisherService
    {
        IPublisherDal _publisherDal;
        IMapper _mapper;

        public PublisherService(IPublisherDal publisherDal, IMapper mapper)
        {
            _publisherDal = publisherDal;
            _mapper = mapper;
        }

        public IResult CreatePublisher(CreatePublisherVM createPublisherVM)
        {
            IResult check = BusinessRules.Run(CheckIfPublisherExists(createPublisherVM.PublisherName));
            if (check != null)
            {
                return new Result(false, "Publisher couldn' t added...");
            }

            ValidationTool.Validate(new PublisherValidator(), createPublisherVM);
            Publisher publisher = _mapper.Map<Publisher>(createPublisherVM);
            _publisherDal.Add(publisher);
            return new Result(true, "Publisher added succesfully...");
        }

        public IResult DeletePublisher(DeletePublisherVM deletePublisherVM)
        {
            IResult check = BusinessRules.Run(CheckIfPublisherExistsById(deletePublisherVM.Id));
            if (check != null)
            {
                return new Result(false, "Publisher couldn' t deleted!");
            }
            Publisher publisher = _publisherDal.GetById(a => a.Id == deletePublisherVM.Id);
            _publisherDal.Delete(publisher);
            return new Result(true, "Publisher deleted succesfully...");
        }

        public IResult UpdatePublisher(UpdatePublisherVM updatePublisherVM)
        {
            IResult check = BusinessRules.Run(CheckIfPublisherExistsById(updatePublisherVM.Id));
            if (check != null)
            {
                return new Result(false, "Book couldn' t updated!");
            }
            Publisher publisher = _publisherDal.GetById(a => a.Id == updatePublisherVM.Id);
            publisher.PublisherName = updatePublisherVM.PublisherName;
            _publisherDal.Update(publisher);
            return new Result(true, "Publisher updated succesfully...");
        }

        public IDataResult<List<Publisher>> GetAllPublishers()
        {
            return new DataResult<List<Publisher>>(_publisherDal.GetAll(), true, "Publisher listed...");
        }

        public IDataResult<List<Publisher>> GetAllPublishersDetail()
        {
            return new DataResult<List<Publisher>>(_publisherDal.GetAllPublishersDetails(), true, "Publisher with detail listed...");
        }

        public IDataResult<Publisher> GetById(Guid id)
        {
            return new DataResult<Publisher>(_publisherDal.GetById(p => p.Id == id), true, "Publisher by id...");
        }      

        private IResult CheckIfPublisherExists(string publisherName)
        {
            var result = _publisherDal.GetAll(p => p.PublisherName == publisherName).Any();
            if (result)
            {
                return new Result(false, "Publisher aldready exists!");
            }
            return new Result(true, "Publisher not exists!");
        }

        private IResult CheckIfPublisherExistsById(Guid id)
        {
            var result = _publisherDal.GetAll(p => p.Id == id).Any();
            if (result)
            {
                return new Result(true, "Publisher aldready exists!");
            }
            return new Result(false, "Publisher not exists!");
        }

    }
}
