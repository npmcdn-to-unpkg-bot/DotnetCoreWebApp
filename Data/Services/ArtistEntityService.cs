using Core.Common.Data.Services;
using TestProject.Models;
using WebApplication.Data.Repositories;

namespace WebApplication.Data.Services
{
    public class ArtistEntityService : BaseEntityService<Artist>, IArtistEntityService
    {
        public ArtistEntityService(IArtistsRepository repository)
        {
            _repository = repository;
        }
    }
}