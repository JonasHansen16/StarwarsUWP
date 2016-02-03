using StarWarsCross.Views;

namespace StarWarsCross
{
    public sealed class NavigationService : INavigationService
    {
        public void Navigate(string Key)
        {
            
          if(Key == "Planets")
            {
                App.Current.MainPage = new PlanetsView();
            }
        }

    }
}
