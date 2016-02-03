using StarWarsCross.Views;
using Xamarin.Forms;

namespace StarWarsCross
{
    public class App : Application
    {
        private ViewModelLocator locator;
        public App()
        {

            // The root page of your application

            locator = new ViewModelLocator();
            MainPage = new StarWarsMainView();
        }
        public ViewModelLocator ViewModelLocator
        {
            get { return locator; }
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
