using StarWars.DAL;
using StarWars.Domain;
using StarWarsUWP.App.Utility;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;


namespace StarWarsUWP.App.ViewModels
{
    public class PlanetsViewModel : INotifyPropertyChanged
    {
        private ObservableCollection<SWPlanet> planets = new ObservableCollection<SWPlanet>();
        public ObservableCollection<SWPlanet> Planets {
            get { return planets; }
            set {
                planets = value;
                   
                RaisePropertyChanged("Planets");
            } }
        public SWMovie Movie { get; set; }
        private SWPlanet planet = new SWPlanet();
        public SWPlanet Planet
        {
            get { return planet; }
            set
            {
                planet = value;

                RaisePropertyChanged("Planet");
            }
        }
        private IStarWarsRepository repo;

        public event PropertyChangedEventHandler PropertyChanged;

        public PlanetsViewModel(IStarWarsRepository repo)
        {
            Messenger.Default.Register<SWMovie>(this, OnMovieReceived, "Movies");
            this.repo = repo;
        }

        private async void OnMovieReceived(SWMovie obj)
        {
            Movie = obj;
            for(int i = 0; Movie.PlanetUris.Count > i; i++)
            {
                planets.Add( await repo.GetPlanet(Movie.PlanetUris[i]));
            }
           
            Planet = planets[0];
            

        }
        private void RaisePropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
