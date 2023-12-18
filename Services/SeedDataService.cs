using Freelancer.WebAPI.Entities;
using Freelancer.WebAPI.Repositories;

namespace Freelancer.WebAPI.Services
{
    public class SeedDataService : ISeedDataService
    {
        public void Initialize(FreelancerDbContext context)
        {
            context.Freelancers.Add(new FreelancerEntity() { Username = "Kevin", PhoneNo = "0197765432", Mail="kevin@gmail.com", Hobby = "nothing", Skillsets = "GIS"});
            context.Freelancers.Add(new FreelancerEntity() { Username = "Zach", PhoneNo = "0197765432", Mail = "Zach@gmail.com", Hobby = "nothing", Skillsets = "JAVA" });
            context.Freelancers.Add(new FreelancerEntity() { Username = "Martin", PhoneNo = "0197765432", Mail = "Martin@gmail.com", Hobby = "nothing", Skillsets = "C#" });
            context.Freelancers.Add(new FreelancerEntity() { Username = "Andy", PhoneNo = "0197765432", Mail = "Andy@gmail.com", Hobby = "nothing", Skillsets = "C++" });
            
            context.SaveChanges();
        }
    }
}
