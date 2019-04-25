using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using Xamarin.Forms;

namespace Calculator
{
    public class DemoCommandViewModel : INotifyPropertyChanged
    {
        public DemoCommandViewModel()
        {
            IncreaseCommand = new Command(IncreaseCount);
        }

        public ICommand IncreaseCommand { get; }

        int Count = 0;

        void IncreaseCount()
        {
            Count++;
            OnPropertyChanged(nameof(DisplayCount));
        }

        public string DisplayCount => $"You have clicked {Count} times.";
        public event PropertyChangedEventHandler PropertyChanged;

        void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
