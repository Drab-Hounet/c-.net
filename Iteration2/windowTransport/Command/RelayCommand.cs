using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;

namespace windowTransport.Command
{
    public class RelayCommand : ICommand
    {
        private Action<object> execute;

        public event EventHandler CanExecuteChanged;

        public RelayCommand(Action<object> execute)
        {
            this.execute = execute;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            execute(parameter);
        }
    }  
}
