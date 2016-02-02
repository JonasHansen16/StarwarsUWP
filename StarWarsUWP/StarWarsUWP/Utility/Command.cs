using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace StarWarsUWP.App.Utility
{
    public class Command : ICommand
    {
        private Action<object> _execute;
        private Predicate<object> _canExecute;

        public Command(Action<object> execute, Predicate<object> canExecute)
        {
            _execute = execute;
            _canExecute = canExecute;
        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            bool b = _canExecute == null ? true : _canExecute(parameter);
            return b;
        }

        public void Execute(object parameter)
        {
            _execute(parameter);
        }
        public void RaiseCanExecuteChanged()
        {
            if (CanExecuteChanged != null)
                CanExecuteChanged(this, EventArgs.Empty);
        }
    }
}
