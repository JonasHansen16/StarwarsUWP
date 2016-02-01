using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StarWarsUWP.App.ViewModels;

namespace StarWarsUWP.App
{
    public class ViewModelLocator
    {
        private static StarWarsMoviesViewModel mainViewViewModel = new StarWarsMoviesViewModel();

        public static StarWarsMoviesViewModel MainViewViewModel
        {
            get
            {
                return mainViewViewModel;
            }
        }
    }
}
