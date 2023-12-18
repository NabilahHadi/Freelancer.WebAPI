using AutoMapper;
using Freelancer.WebAPI.Dtos;
using Freelancer.WebAPI.Entities;

namespace Freelancer.WebAPI.MappingProfiles
{
    public class FreelancerMappings : Profile
    {
        public FreelancerMappings()
        {
            CreateMap<FreelancerEntity, FreelancerDto>().ReverseMap();
            CreateMap<FreelancerEntity, FreelancerUpdateDto>().ReverseMap();
            CreateMap<FreelancerEntity, FreelancerCreateDto>().ReverseMap();
        }
    }
}
