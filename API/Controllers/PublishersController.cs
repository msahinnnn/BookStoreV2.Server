﻿using Business.Abstract;
using Business.Concrete;
using Entities.ViewModels.Book;
using Entities.ViewModels.Publisher;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PublishersController : ControllerBase
    {
        private IPublisherService _publisherService;

        public PublishersController(IPublisherService publisherService)
        {
            _publisherService = publisherService;
        }

        [Authorize(Roles = "Admin, Standard")]
        [HttpGet("publishers")]
        public IActionResult Get()
        {
            var result = _publisherService.GetAllPublishers();
            if (result != null)
            {
                return Ok(result);
            }
            return BadRequest();
        }

        [Authorize(Roles = "Admin, Standard")]
        [HttpGet("publisher/{id}")]
        public IActionResult GetById(Guid id)
        {
            var result = _publisherService.GetById(id);
            if (result != null)
            {
                return Ok(result);
            }
            return BadRequest();
        }

        [Authorize(Roles = "Admin, Standard")]
        [HttpGet("publishers-detailed")]
        public IActionResult GetDetail()
        {
            var result = _publisherService.GetAllPublishersDetail();
            if (result != null)
            {
                return Ok(result);
            }
            return BadRequest();
        }

        //[Authorize(Roles = "Admin")]
        [HttpPost]
        public IActionResult Post([FromBody] CreatePublisherVM createPublisherVM)
        {
            var result = _publisherService.CreatePublisher(createPublisherVM);
            if (result.Success == true)
            {
                return Ok(result.Message);
            }
            return BadRequest(result.Message);
        }

        [Authorize(Roles = "Admin")]
        [HttpDelete]
        public IActionResult Delete([FromBody] DeletePublisherVM deletePublisherVM)
        {
            var result = _publisherService.DeletePublisher(deletePublisherVM);
            if (result.Success == true)
            {
                return Ok(result.Message);
            }
            return BadRequest(result.Message);
        }

        [Authorize(Roles = "Admin")]
        [HttpPut]
        public IActionResult Update([FromBody] UpdatePublisherVM updatePublisherVM)
        {
            var result = _publisherService.UpdatePublisher(updatePublisherVM);
            if (result.Success == true)
            {
                return Ok(result.Message);
            }
            return BadRequest(result.Message);
        }
    }
}
