using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using StarWars.DAL;
using StarWars.Domain;
using StarWarsUWP.App.Utility;
using Windows.UI.Xaml.Controls;
using System.ComponentModel;

namespace StarWarsUWP.App.ViewModels
{
    public class StarWarsMoviesViewModel : INotifyPropertyChanged
    {
        public List<SWMovie> SWMovies { get; private set; }
        public SWMovie SelectedSWMovie { get; set; }

        public ICommand ShowDetailsCommand { get; set; }

        public ICommand PageLoadedCommand { get; set; }

        public StarWarsMoviesViewModel()
        {
            SWAPIRepository repo = new SWAPIRepository();
            LoadCommands();
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void LoadCommands()
        {
            ShowDetailsCommand = new Command(ShowMovieDetails, null);
            PageLoadedCommand = new Command(PageLoaded, null);
        }

        private void ShowMovieDetails(object movie)
        {
           SelectedSWMovie = (SWMovie)movie;
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs("SelectedSWMovie"));
        }

        private async void PageLoaded(object page)
        {
            SWMovies = await new SWAPIRepository().GetAllSWMovies();
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs("SWMovies"));
        }
    }
}
