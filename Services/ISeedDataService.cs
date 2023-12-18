using Freelancer.WebAPI.Repositories;

namespace Freelancer.WebAPI.Services
{
    public interface ISeedDataService
    {
        void Initialize(FreelancerDbContext context);
    }
}
