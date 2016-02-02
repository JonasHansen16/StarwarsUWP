using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StarWarsUWP.App.ViewModels;
using StarWars.DAL;
using StarWarsUWP.App.Utility;
using StarWarsUWP.App.Extensions;

namespace StarWarsUWP.App
{
    public class ViewModelLocator
    {
        private static IStarWarsRepository rep = new SWAPIRepository();
        private static INavigationService navsev = new NavigationService();
        private static StarWarsMoviesViewModel mainViewViewModel = new StarWarsMoviesViewModel(rep, navsev);
        private static PlanetsViewModel planetsViewModel = new PlanetsViewModel(rep);

        public static StarWarsMoviesViewModel MainViewViewModel
        {
            get
            {
                return mainViewViewModel;
            }
        }
        public static PlanetsViewModel PlanetsViewModel
        {
            get
            {
                return planetsViewModel;
            }
        }
    }
}
