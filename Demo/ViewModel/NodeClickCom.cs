using System;
using System.Windows.Input;

namespace Demo.ViewModel
{
    public class NodeClickCom : ICommand
    {
        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            var d = parameter;
        }
    }
}
