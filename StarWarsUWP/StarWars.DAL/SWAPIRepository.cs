using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StarWars.Domain;
using System.Net.Http;
using Newtonsoft.Json;
using System.Threading;
namespace StarWars.DAL
{
    public class SWAPIRepository : IStarWarsRepository
    {
        public async Task<List<SWMovie>> GetAllSWMovies()
        {
            string swapifilms = "http://swapi.co/api/films";
            var uri = new Uri(string.Format("{0}?format=json", swapifilms));
            var client = new HttpClient();
            var response = await Task.Run(() => client.GetAsync(uri));
            response.EnsureSuccessStatusCode();
            var result = await Task.Run(() => response.Content.ReadAsStringAsync());
            var root = JsonConvert.DeserializeObject<RootObject<SWMovie>>(result);
            return root.results;
        }

        public SWMovie GetMovieByUrl(string url)
        {
            var client = new HttpClient();
            var response = Task.Run(() => client.GetAsync(url)).Result;
            response.EnsureSuccessStatusCode();
            var result = Task.Run(() => response.Content.ReadAsStringAsync()).Result;
            var movie = JsonConvert.DeserializeObject<SWMovie>(result);
            return movie;
        }

        public async Task<SWPlanet> GetPlanet(string planet)
        {
            string swapifilms = planet;
            var uri = new Uri(string.Format("{0}?format=json", swapifilms));
            var client = new HttpClient();
            var response = await Task.Run(() => client.GetAsync(uri));
            response.EnsureSuccessStatusCode();
            var result = await Task.Run(() => response.Content.ReadAsStringAsync());
            var root = JsonConvert.DeserializeObject<SWPlanet>(result);
            return root;

        }

        class RootObject<T>
        {
            public int count { get; set; }
            public object next { get; set; }
            public object previous { get; set; }
            public List<T> results { get; set; }
        }
    }
}
