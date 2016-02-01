using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StarWars.Domain;

namespace StarWars.DAL
{
    interface IStarWarsRepository
    {
        SWMovie GetMovieByUrl(string url);
        Task<List<SWMovie>> GetAllSWMovies();
    }
}
