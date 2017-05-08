using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Windows.Input;
using System.Threading.Tasks;

namespace SearchSNLog
{
    public class DelegateCommand : ICommand
    {
        public Action<object> ExecuteCommand = null;
        public Func<object, bool> CanExecuteCommand = null;
        public event EventHandler CanExecuteChanged;

        public DelegateCommand(Action<object> executeCommand) : this(executeCommand, null) { }

        public DelegateCommand(Action<object> executeCommand, Func<object, bool> canExecuteCommand)
        {
            if (executeCommand != null)
            {
                ExecuteCommand = executeCommand;
                CanExecuteCommand = canExecuteCommand;
            }
        }

        public bool CanExecute(object parameter)
        {
            if (CanExecuteCommand != null)
            {
                return this.CanExecuteCommand(parameter);
            }
            else
            {
                return true;
            }
        }

        public void Execute(object parameter)
        {
            if (this.ExecuteCommand != null) this.ExecuteCommand(parameter);
        }

        public void RaiseCanExecuteChanged()
        {
            if (CanExecuteChanged != null)
            {
                CanExecuteChanged(this, EventArgs.Empty);
            }
        }
    }
}
