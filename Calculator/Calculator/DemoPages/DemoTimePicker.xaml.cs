using System;
using System.ComponentModel;

using Xamarin.Forms;

namespace Calculator
{
    public partial class DemoTimePicker : ContentPage
    {
        DateTime _triggerTime;

        public DemoTimePicker()
        {
            InitializeComponent();

            Device.StartTimer(TimeSpan.FromSeconds(1), OnTimerTick);
        }

        bool OnTimerTick()
        {
            if (_switch.IsToggled && DateTime.Now >= _triggerTime)
            {
                _switch.IsToggled = false;
                DisplayAlert("Timer Alert", "The '" + _entry.Text + "' timer has elapsed", "OK");
            }
            return true;
        }

        void OnTimePickerPropertyChanged(object sender, PropertyChangedEventArgs args)
        {
            if (args.PropertyName == "Time")
            {
                SetTriggerTime();
            }
        }

        void OnSwitchToggled(object sender, ToggledEventArgs args)
        {
            SetTriggerTime();
        }

        void SetTriggerTime()
        {
            if (_switch.IsToggled)
            {
                _triggerTime = DateTime.Today + _timePicker.Time;
                if (_triggerTime < DateTime.Now)
                {
                    _triggerTime += TimeSpan.FromDays(1);
                }
            }
        }

        void OnStepperValueChanged(object sender, ValueChangedEventArgs e)
        {
            int value = Convert.ToInt32(e.NewValue);
            if (_timePicker != null)
            {
                _timePicker.Time = new TimeSpan(value, 0, 0);
            }
        }
    }
}
