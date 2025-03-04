using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp2.Common;

namespace WpfApp2.Models
{
    public class Person : BindableBase
    {
        private string _name;
        private int _age;
        private int _id;
        private DateTime _createdTime;
        private DateTime _updatedTime;
        public string Name
        {
            get => _name;
            set => SetProperty(ref _name, value);
        }

        public int Age
        {
            get => _age;
            set => SetProperty(ref _age, value);
        }

        public int Id
        {
            get => _id;
            set=> SetProperty(ref _id, value);
        }
        public DateTime CreatedTime
        {
            get => _createdTime;
            set => SetProperty(ref _createdTime, value);
        }

        public DateTime UpdatedTime
        {
            get => _updatedTime;
            set => SetProperty(ref _updatedTime, value);
        }
    }
}
