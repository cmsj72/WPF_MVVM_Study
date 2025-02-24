using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WPF1.Commands;
using WPF1.Models;

namespace WPF1.ViewModels
{
    public class MainViewModel : INotifyPropertyChanged
    {
        //  Person 모델을 포함하는 속성
        public Person Person { get; set; }
        //  버튼 클릭 시 실행할 Command
        public ICommand ChangeNameCommand { get; }

        private string _welcomeMessage;

        public string WelcomeMessage
        {
            get { return _welcomeMessage; }
            private set
            {
                _welcomeMessage = value;
                OnPropertyChanged(nameof(WelcomeMessage));
            }
        }

        //  생성자: 초기 값 설정 및 Command 생성
        public MainViewModel()
        {
            //  기본값 설정
            Person = new Person { Name = "홍길동" };
            UpdateWelcomMessage();

            //  버튼 클릭 시 실행될 메서드 등록
            ChangeNameCommand = new RelayCommand(ChangeName);

            //  Person.Name이 변경될 때 WelcomeMessage도 자동 변경
            Person.PropertyChanged += (sender, args) =>
            {
                if (args.PropertyName == nameof(Person.Name))
                {
                    UpdateWelcomMessage();
                }
            };
        }

        //  버튼 클릭 시 실행되는 메서드
        private void ChangeName(object parameter)
        {
            //  Name 속성을 변경하면 UI도 자동 업데이트됨
            Person.Name = "이순신";
        }

        private void UpdateWelcomMessage()
        {
            WelcomeMessage = $"{Person.Name}님, 환영합니다!";
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
