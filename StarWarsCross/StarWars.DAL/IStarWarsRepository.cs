using System.Collections.Generic;
using System.Threading.Tasks;
using StarWars.Domain;

namespace StarWars.DAL
{
    public interface IStarWarsRepository
    {
        SWMovie GetMovieByUrl(string url);
        Task<List<SWMovie>> GetAllSWMovies();
        Task<SWPlanet> GetPlanet(string planet);
    }
}
