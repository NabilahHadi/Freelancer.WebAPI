using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Freelancer.WebAPI.Dtos;
using Freelancer.WebAPI.Entities;
using Freelancer.WebAPI.Helpers;
using Freelancer.WebAPI.Services;
using Freelancer.WebAPI.Models;
using Freelancer.WebAPI.Repositories;
using System.Text.Json;

namespace Freelancer.WebAPI.Controllers.v1
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class FreelancersController : ControllerBase
    {
        private readonly IFreelancerRepository _freelancerRepository;
        private readonly IMapper _mapper;
        private readonly ILinkService<FreelancersController> _linkService;

        public FreelancersController(
            IFreelancerRepository freelancerRepository,
            IMapper mapper,
            ILinkService<FreelancersController> linkService)
        {
            _freelancerRepository = freelancerRepository;
            _mapper = mapper;
            _linkService = linkService;
        }

        [HttpGet(Name = nameof(GetAllFreelancers))]
        public ActionResult GetAllFreelancers(ApiVersion version, [FromQuery] QueryParameters queryParameters)
        {
            List<FreelancerEntity> freelancers = _freelancerRepository.GetAll(queryParameters).ToList();

            var allItemCount = _freelancerRepository.Count();

            var paginationMetadata = new
            {
                totalCount = allItemCount,
                pageSize = queryParameters.PageCount,
                currentPage = queryParameters.Page,
                totalPages = queryParameters.GetTotalPages(allItemCount)
            };

            Response.Headers.Add("X-Pagination", JsonSerializer.Serialize(paginationMetadata));

            var links = _linkService.CreateLinksForCollection(queryParameters, allItemCount, version);
            var toReturn = freelancers.Select(x => _linkService.ExpandFreelancer(x, x.Id, version));

            return Ok(new
            {
                value = toReturn,
                links = links
            });
        }

        [HttpGet]
        [Route("{id:int}", Name = nameof(GetFreelancer))]
        public ActionResult GetFreelancer(ApiVersion version, int id)
        {
            FreelancerEntity freelancer = _freelancerRepository.GetSingle(id);

            if (freelancer == null)
            {
                return NotFound();
            }

            FreelancerDto item = _mapper.Map<FreelancerDto>(freelancer);

            return Ok(_linkService.ExpandFreelancer(item, item.Id, version));
        }

        [HttpPost(Name = nameof(AddFreelancer))]
        public ActionResult<FreelancerDto> AddFreelancer(ApiVersion version, [FromBody] FreelancerCreateDto freelancerCreateDto)
        {
            if (freelancerCreateDto == null)
            {
                return BadRequest();
            }

            FreelancerEntity toAdd = _mapper.Map<FreelancerEntity>(freelancerCreateDto);

            _freelancerRepository.Add(toAdd);

            if (!_freelancerRepository.Save())
            {
                throw new Exception("Creating a freelancer failed on save.");
            }

            FreelancerEntity newFreelancer = _freelancerRepository.GetSingle(toAdd.Id);
            FreelancerDto freelancerDto = _mapper.Map<FreelancerDto>(newFreelancer);

            return CreatedAtRoute(nameof(GetFreelancer),
                 new { version = version.ToString(), id = newFreelancer.Id },
                 _linkService.ExpandFreelancer(freelancerDto, freelancerDto.Id, version));
        }

        [HttpDelete]
        [Route("{id:int}", Name = nameof(RemoveFreelancer))]
        public ActionResult RemoveFreelancer(int id)
        {
            FreelancerEntity freelancer = _freelancerRepository.GetSingle(id);

            if (freelancer == null)
            {
                return NotFound();
            }

            _freelancerRepository.Delete(id);

            if (!_freelancerRepository.Save())
            {
                throw new Exception("Deleting a freelancer failed on save.");
            }

            return NoContent();
        }

        [HttpPut]
        [Route("{id:int}", Name = nameof(UpdateFreelancer))]
        public ActionResult<FreelancerDto> UpdateFreelancer(ApiVersion version, int id, [FromBody] FreelancerUpdateDto freelancerUpdateDto)
        {
            if (freelancerUpdateDto == null)
            {
                return BadRequest();
            }

            var existingFreelancer = _freelancerRepository.GetSingle(id);

            if (existingFreelancer == null)
            {
                return NotFound();
            }

            _mapper.Map(freelancerUpdateDto, existingFreelancer);

            _freelancerRepository.Update(id, existingFreelancer);

            if (!_freelancerRepository.Save())
            {
                throw new Exception("Updating a freelancer failed on save.");
            }

            FreelancerDto freelancerDto = _mapper.Map<FreelancerDto>(existingFreelancer);

            return Ok(_linkService.ExpandFreelancer(freelancerDto, freelancerDto.Id, version));
        }

    }
}
