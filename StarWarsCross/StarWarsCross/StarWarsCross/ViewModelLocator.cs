

using StarWars.DAL;

namespace StarWarsCross
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
        public  PlanetsViewModel PlanetsViewModel
        {
            get
            {
                return planetsViewModel;
            }
        }
    }
}
