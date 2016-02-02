using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace StarWars.Domain
{
    public class SWMovie : SWResource, INotifyPropertyChanged
    {
        public SWMovie()
        {
            Planets = new List<SWPlanet>();
            PlanetUris = new List<string>();
        }

        public string Title { get; set; }
        public int Episode_Id { get; set; }

        [JsonProperty(PropertyName = "opening_crawl")]
        public string OpeningCrawl { get; set; }

        public string Director { get; set; }
        public string Producer { get; set; }

        private double rating = 0;
        public double Rating {
            get { return rating; }
            set
            {
                rating = value;
                RaisePropertyChanged();
            }
        }

        [JsonProperty(PropertyName = "release_date")]
        public DateTime ReleaseDate { get; set; }

        [JsonIgnore]
        public virtual List<SWPlanet> Planets { get; set; }

        [JsonProperty(PropertyName = "planets")]
        public List<string> PlanetUris { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        private void RaisePropertyChanged([CallerMemberName]string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }

    }
}
