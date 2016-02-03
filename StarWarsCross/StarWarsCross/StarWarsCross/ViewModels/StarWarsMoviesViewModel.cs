using System.Collections.Generic;
using System.Windows.Input;
using System.ComponentModel;
using Xamarin.Forms;
using StarWars.DAL;
using StarWars.Domain;
using StarWarsCross.Utility;


namespace StarWarsCross
{
    public class StarWarsMoviesViewModel : INotifyPropertyChanged
    {





        public ICommand PageLoadedCommand { get; set; }
        private INavigationService nav;

        public CustomCommand RatingUpCommand { get; set; }
        public CustomCommand RatingDownCommand { get; set; }
        public ICommand NavigateCommand { get; set; }
        private IStarWarsRepository repo; 
        private double rating = 0;

        public StarWarsMoviesViewModel(IStarWarsRepository rep, INavigationService nav)
        {
            repo = rep;
            this.nav = nav;

            LoadCommands();
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void LoadCommands()
        {
            PageLoadedCommand = new CustomCommand(PageLoaded, CanExecute);
            RatingUpCommand = new CustomCommand(ChangeRatingUp, CanChangeRatingUp);
            RatingDownCommand = new CustomCommand(ChangeRatingDown, CanChangeRatingDown);
            NavigateCommand = new CustomCommand(Navigate, CanExecute);
        }

        private void Navigate(object obj)
        {
            MessagingCenter.Send<StarWarsMoviesViewModel, SWMovie>(this,"Movie", selectedmovie);
           
            nav.Navigate("Planets");

        }



        private async void PageLoaded(object obj)
        {
            SWMovies = await repo.GetAllSWMovies();


            SelectedSWMovie = SWMovies[0];


        }
        private SWMovie selectedmovie;
        public SWMovie SelectedSWMovie
        {
            get { return selectedmovie; }
            set
            {
                selectedmovie = value;
                RaisePropertyChanged("SelectedSWMovie");

            }
        }
        private List<SWMovie> swmovies;
        public List<SWMovie> SWMovies
        {
            get { return swmovies; }
            set
            {
                swmovies = value;
                RaisePropertyChanged("SWMovies");

            }
        }

        private void ChangeRatingUp(object obj)
        {

            SelectedSWMovie.Rating += 0.5;
            rating += 0.5;
            RatingUpCommand.RaiseCanExecuteChanged();
            RatingDownCommand.RaiseCanExecuteChanged();



        }
        private void ChangeRatingDown(object obj)
        {

            SelectedSWMovie.Rating -= 0.5;
            rating -= 0.5;
            RatingDownCommand.RaiseCanExecuteChanged();
            RatingUpCommand.RaiseCanExecuteChanged();

        }
        private bool CanChangeRatingUp(object obj)
        {
            if (rating >= 10)
                return false;
            return true;
        }
        private bool CanChangeRatingDown(object obj)
        {
            if (rating <= 0)
                return false;
            return true;
        }

        private bool CanExecute(object obj)
        {
            return true;
        }

        private void RaisePropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }


    }
}
