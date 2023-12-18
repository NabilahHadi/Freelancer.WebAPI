using Microsoft.AspNetCore.Mvc;
using Freelancer.WebAPI.Models;

namespace Freelancer.WebAPI.Services
{
    public interface ILinkService<T>
    {
        object ExpandFreelancer(object resource, int identifier, ApiVersion version);

        List<LinkDto> CreateLinksForCollection(QueryParameters queryParameters, int totalCount, ApiVersion version);
    }
}
