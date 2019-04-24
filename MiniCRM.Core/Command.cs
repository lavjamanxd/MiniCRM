using System;
using System.Windows.Input;

namespace MiniCRM.Core
{
    public class Command<T> : ICommand
    {
        private readonly Action<T> _action;

        public Command(Action<T> action)
        {
            _action = action;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            _action((T) parameter);
        }

        public event EventHandler CanExecuteChanged;
    }
}