using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Threading;
using WpfApp4.Common;
using WpfApp4.Model;

namespace WpfApp4.ViewModel
{
    public class MainWindowViewModel : BindableBase
    {
        public ClickCounterModel ClickModel { get; }
        public TimerCounterModel TimerModel { get; }
        private readonly DispatcherTimer _timer;

        private bool _isTimerRunning;
        public bool IsTimerRunning
        {
            get => _isTimerRunning;
            set => SetProperty(ref _isTimerRunning, value);
        }

        public ICommand IncresementCommand { get; }
        public DelegateCommand ToggleTimerCommand { get; }
        public ICommand ResetTimerCommand { get; }

        public MainWindowViewModel()
        {
            ClickModel = new ClickCounterModel();
            TimerModel = new TimerCounterModel();

            IncresementCommand = new DelegateCommand(() => ClickModel.Count++);
            ToggleTimerCommand = new DelegateCommand(ToggleTimer);
            ResetTimerCommand = new DelegateCommand(() => TimerModel.Count = 0);

            _timer = new DispatcherTimer
            {
                Interval = TimeSpan.FromSeconds(1)
            };
            _timer.Tick += (s, e) => TimerModel.Count++;
        }

        private void ToggleTimer()
        {
            if (IsTimerRunning)
            {
                _timer.Stop();
            }
            else
            {
                _timer.Start();
            }
            IsTimerRunning = !IsTimerRunning;
        }
    }
}
