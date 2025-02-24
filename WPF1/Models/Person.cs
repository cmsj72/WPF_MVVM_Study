using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF1.Models
{
    public class Person : INotifyPropertyChanged
    {
        private string _name;

        public string Name
        {
            get { return _name; }
            set
            {
                //  값이 변경될 때만 실행
                if(_name != value)
                {
                    _name = value;

                    //  UI에 변경 사항 알림
                    OnPropertyChanged(nameof(Name));
                }
            }
        }

        //  속성 변경을 알리는 이벤트 (WPF UI 자동 업데이트)
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
