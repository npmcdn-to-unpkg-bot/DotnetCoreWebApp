using Core.Common.Data.Services;
using DotNetCoreTestWebProject.Models;
using DotNetCoreTestWebProject.Data.Repositories;

namespace DotNetCoreTestWebProject.Data.Services
{
    public class ArtistEntityService : BaseEntityService<Artist>, IArtistEntityService
    {
        public ArtistEntityService(IArtistsRepository repository)
        {
            _repository = repository;
        }
    }
}