using Freelancer.WebAPI.Entities;
using Freelancer.WebAPI.Helpers;
using Freelancer.WebAPI.Models;
using System.Linq.Dynamic.Core;

namespace Freelancer.WebAPI.Repositories
{
    public class FreelancerSqlRepository : IFreelancerRepository
    {
        private readonly FreelancerDbContext _freelancerDbContext;

        public FreelancerSqlRepository(FreelancerDbContext freelancerDbContext)
        {
            _freelancerDbContext = freelancerDbContext;
        }

        public FreelancerEntity GetSingle(int id)
        {
            return _freelancerDbContext.Freelancers.FirstOrDefault(x => x.Id == id);
        }

        public void Add(FreelancerEntity item)
        {
            _freelancerDbContext.Freelancers.Add(item);
        }

        public void Delete(int id)
        {
            FreelancerEntity freelancer = GetSingle(id);
            _freelancerDbContext.Freelancers.Remove(freelancer);
        }

        public FreelancerEntity Update(int id, FreelancerEntity item)
        {
            _freelancerDbContext.Freelancers.Update(item);
            return item;
        }

        public IQueryable<FreelancerEntity> GetAll(QueryParameters queryParameters)
        {
            IQueryable<FreelancerEntity> _allItems = _freelancerDbContext.Freelancers;

            return _allItems
                .Skip(queryParameters.PageCount * (queryParameters.Page - 1))
                .Take(queryParameters.PageCount);
        }

        public int Count()
        {
            return _freelancerDbContext.Freelancers.Count();
        }

        public bool Save()
        {
            return (_freelancerDbContext.SaveChanges() >= 0);
        }

    }
}
