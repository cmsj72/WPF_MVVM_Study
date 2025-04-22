using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace WpfApp4.Model
{
    public class DelegateCommand : ICommand
    {
        private readonly Predicate<object> _canExecute;
        private readonly Action _execute;

        public event EventHandler CanExecuteChanged;

        public DelegateCommand(Action execute)
            : this(execute, null)
        { 
        }

        public DelegateCommand(Action execute, Predicate<object> canExecute)
        {
            _execute = execute;
            _canExecute = canExecute;
        }

        public bool CanExecute(object parameter = null)
        {
            return (_canExecute == null) || _canExecute(parameter);
        }

        public void Execute(object parameter = null)
        {
            _execute?.Invoke();
        }

        public void CanExecute()
        {
            CanExecuteChanged?.Invoke(this, EventArgs.Empty);
        }

        public void RaiseCanExecuteChanged()
        {
            CanExecuteChanged?.Invoke(this, EventArgs.Empty);
        }
            
    }
}
