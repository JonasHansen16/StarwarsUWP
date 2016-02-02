using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.ComponentModel;

namespace StarWars.Domain
{
    public class SWPlanet : SWResource, INotifyPropertyChanged
    {
        public SWPlanet()
        {
            Films = new List<SWMovie>();
            FilmUris = new List<string>();
        }

        public string Name { get; set; }

        [JsonProperty("rotation_period")]
        public int RotationPeriod { get; set; }
        [JsonProperty("orbital_peroid")]
        public int OrbitalPeriod { get; set; }
        public int Diameter { get; set; }
        public string Climate { get; set; }
        public string Gravity { get; set; }
        public string Terrain { get; set; }

        [JsonProperty("surface_water")]
        public string SurfaceWater { get; set; }

        public string Population { get; set; }

        [JsonIgnore]
        public virtual List<SWMovie> Films { get; set; }

        [JsonProperty(PropertyName = "films")]
        public List<string> FilmUris { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
