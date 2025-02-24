using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace WPF1.Commands
{
    public class RelayCommand : ICommand
    {
        private readonly Action<object> execute;
        private readonly Func<object, bool> canExecute;

        public event EventHandler CanExecuteChanged;

        public RelayCommand(Action<object> execute, Func<object, bool> canExecute = null)
        {
            this.execute = execute;
            this.canExecute = canExecute;
        }

        //  버튼이 활성화될 수 있는지 확인 (기본값은 항상 true)
        public bool CanExecute(object parameter) => canExecute == null || canExecute(parameter);

        //  버튼 클릭 시 실행할 메서드 호출
        public void Execute(object parameter) => execute(parameter);
    }

}
