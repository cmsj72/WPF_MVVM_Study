using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace WpfApp1
{
    public class MainViewModel : INotifyPropertyChanged
    {
        public string Message { get; set; } = "초기 메세지";
        public ICommand UpdateMessageCommand { get; }

        public MainViewModel()
        {
            UpdateMessageCommand = new RelayCommand(UpdateMessage, CanUpdateMessage);
        }

        private void UpdateMessage(object param)
        {
            Message = "메시지가 업데이트됨!";
            OnPropertyChanged(nameof(Message));
        }

        private bool CanUpdateMessage(object param)
        {
            //  조건에 따라 버튼 활서와 여부 결정
            return Message != "메시지가 업데이트됨!";
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
        }
    }

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
