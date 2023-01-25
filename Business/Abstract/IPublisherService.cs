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
        IDataResult<List<Publisher>> GetAllPublishers();
        IDataResult<Publisher> GetById(Guid id);
        IDataResult<List<Publisher>> GetAllPublishersDetail();
        IResult CreatePublisher(CreatePublisherVM createPublisherVM);
        IResult DeletePublisher(DeletePublisherVM deletePublisherVM);
        IResult UpdatePublisher(UpdatePublisherVM updatePublisherVM);
    }
}
