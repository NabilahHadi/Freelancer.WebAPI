using System.ComponentModel.DataAnnotations;

namespace Freelancer.WebAPI.Dtos
{
    public class FreelancerCreateDto
    {
        [Required]
        public string Username { get; set; }
        public string Mail { get; set; }
        public string PhoneNo { get; set; }
        public string? Skillsets { get; set; }
        public string? Hobby { get; set; }
    }
    
}
