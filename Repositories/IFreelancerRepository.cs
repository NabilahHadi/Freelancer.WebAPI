using Freelancer.WebAPI.Entities;
using Freelancer.WebAPI.Models;

namespace Freelancer.WebAPI.Repositories
{
    public interface IFreelancerRepository
    {
        FreelancerEntity GetSingle(int id);
        void Add(FreelancerEntity item);
        void Delete(int id);
        FreelancerEntity Update(int id, FreelancerEntity item);
        IQueryable<FreelancerEntity> GetAll(QueryParameters queryParameters);
        int Count();
        bool Save();
    }
}
