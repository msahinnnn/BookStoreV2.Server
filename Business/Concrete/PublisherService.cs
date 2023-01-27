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

        public async Task<IResult> CreatePublisher(CreatePublisherVM createPublisherVM)
        {
            IResult check = BusinessRules.Run(await CheckIfPublisherExists(createPublisherVM.PublisherName));
            if (check != null)
            {
                return new Result(false, "Publisher couldn' t added...");
            }

            ValidationTool.Validate(new PublisherValidator(), createPublisherVM);
            Publisher publisher = _mapper.Map<Publisher>(createPublisherVM);
            _publisherDal.Add(publisher);
            return new Result(true, "Publisher added succesfully...");
        }

        public async Task<IResult> DeletePublisher(DeletePublisherVM deletePublisherVM)
        {
            IResult check = BusinessRules.Run(await CheckIfPublisherExistsById(deletePublisherVM.Id));
            if (check != null)
            {
                return new Result(false, "Publisher couldn' t deleted!");
            }
            Publisher publisher = await _publisherDal.GetById(a => a.Id == deletePublisherVM.Id);
            _publisherDal.Delete(publisher);
            return new Result(true, "Publisher deleted succesfully...");
        }

        public async Task<IResult> UpdatePublisher(UpdatePublisherVM updatePublisherVM)
        {
            IResult check = BusinessRules.Run(await CheckIfPublisherExistsById(updatePublisherVM.Id));
            if (check != null)
            {
                return new Result(false, "Book couldn' t updated!");
            }
            Publisher publisher = await _publisherDal.GetById(a => a.Id == updatePublisherVM.Id);
            publisher.PublisherName = updatePublisherVM.PublisherName;
            _publisherDal.Update(publisher);
            return new Result(true, "Publisher updated succesfully...");
        }

        public async Task<IDataResult<List<Publisher>>> GetAllPublishers()
        {
            var res = await _publisherDal.GetAll();
            return new DataResult<List<Publisher>>(res, true, "Publisher listed...");
        }

        public async Task<IDataResult<List<Publisher>>> GetAllPublishersDetail()
        {
            var res = await _publisherDal.GetAllPublishersDetails();
            return new DataResult<List<Publisher>>(res, true, "Publisher with detail listed...");
        }

        public async Task<IDataResult<Publisher>> GetById(Guid id)
        {
            var res = await _publisherDal.GetById(p => p.Id == id);
            return new DataResult<Publisher>(res, true, "Publisher by id...");
        }      

        private async Task<IResult> CheckIfPublisherExists(string publisherName)
        {
            var result = await _publisherDal.GetAll(p => p.PublisherName == publisherName);
            if (result is not null)
            {
                return new Result(false, "Publisher aldready exists!");
            }
            return new Result(true, "Publisher not exists!");
        }

        private async Task<IResult> CheckIfPublisherExistsById(Guid id)
        {
            var result = await _publisherDal.GetAll(p => p.Id == id);
            if (result is not null)
            {
                return new Result(true, "Publisher aldready exists!");
            }
            return new Result(false, "Publisher not exists!");
        }

    }
}
