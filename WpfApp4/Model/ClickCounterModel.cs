using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp4.Common;

namespace WpfApp4.Model
{
    public class ClickCounterModel : BindableBase
    {
        private int _count;
        public int Count
        {
            get => _count;
            set => SetProperty(ref _count, value);
        }
    }
}
