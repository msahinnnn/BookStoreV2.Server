using Core.Utilities.Results;
using Entities.Concrete;
using Entities.ViewModels.Publisher;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IPublisherService
    {
        Task<IDataResult<List<Publisher>>> GetAllPublishers();
        Task<IDataResult<Publisher>> GetById(Guid id);
        Task<IDataResult<List<Publisher>>> GetAllPublishersDetail();
        Task<IResult> CreatePublisher(CreatePublisherVM createPublisherVM);
        Task<IResult> DeletePublisher(DeletePublisherVM deletePublisherVM);
        Task<IResult> UpdatePublisher(UpdatePublisherVM updatePublisherVM);
    }
}
