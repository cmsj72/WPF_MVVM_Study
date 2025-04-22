using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp3
{
    public class MyViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<string> Items { get; set; }

        private string _newItem;
        public string NewItem
        {
            get => _newItem;
            set
            {
                if(_newItem != value)
                {
                    _newItem = value;
                    OnPropertyChanged();
                    AddItemCommand?.CheckExecute();
                }
            }
        }
        public DelegateCommand AddItemCommand {  get; set; }

        public MyViewModel()
        {
            Items = new ObservableCollection<string>()
            {
                "Item 1",
                "Item 2"
            };

            AddItemCommand = new DelegateCommand(AddItem, o => !string.IsNullOrWhiteSpace(NewItem));
        }

        public void AddItem()
        {
            if(!string.IsNullOrEmpty(NewItem))
            {
                Items.Add(NewItem);
                NewItem = string.Empty;
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName]string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
