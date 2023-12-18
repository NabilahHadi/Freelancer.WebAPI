using Microsoft.EntityFrameworkCore;
using Freelancer.WebAPI.Entities;

namespace Freelancer.WebAPI.Repositories
{
    public class FreelancerDbContext : DbContext
    {
        public FreelancerDbContext(DbContextOptions<FreelancerDbContext> options)
            : base(options)
        {
        }

        public DbSet<FreelancerEntity> Freelancers { get; set; } = null!;
    }
}
