using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace WpfApp3
{
    public class DelegateCommand : ICommand
    {
        private readonly Predicate<object> _canExecute;
        private readonly Action _execute;

        public event EventHandler CanExecuteChanged;

        public DelegateCommand(Action execute, Predicate<object> canExecute)
        {
            _execute = execute;
            _canExecute = canExecute;
        }

        public DelegateCommand(Action execute) : this(execute, null) { }

        public bool CanExecute(object parameter = null)
        {
            return (_canExecute == null) || _canExecute(parameter);
        }

        public void Execute(object parameter = null)
        {
            _execute();
        }

        public void CheckExecute()
        {
            CanExecuteChanged?.Invoke(this, EventArgs.Empty);
        }
    }

    public class DelegateCommand<T> : ICommand
    {
        private readonly Predicate<object> _canExecute;
        private readonly Action<T> _execute;

        public event EventHandler CanExecuteChanged;

        public DelegateCommand(Action<T> execute, Predicate<object> canExecute)
        {
            _execute = execute;
            _canExecute = canExecute;
        }

        public DelegateCommand(Action<T> execute) : this(execute, null) { }

        public bool CanExecute(object parameter = null)
        {
            return (_canExecute == null) || _canExecute(parameter);
        }

        public void Execute(object parameter = null)
        {
            _execute((T)parameter);
        }

        public void CheckExecute()
        {
            CanExecuteChanged(this, EventArgs.Empty);
        }
    }
}
