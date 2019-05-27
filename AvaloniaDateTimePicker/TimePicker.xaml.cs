using System.Collections.Generic;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;

#region directives of standart control
using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using Avalonia.Controls.Primitives;
using Avalonia.Data;
using Avalonia.Input;
using Avalonia.Interactivity;
using Avalonia.Media;
#endregion

namespace AvaloniaDateTimePicker
{
    public class Times
    {
        private TimeSpan _first;
        private TimeSpan _second;
        private TimeSpan _third;
        private TimeSpan _fourth;

        public Times(TimeSpan first, TimeSpan second, TimeSpan third, TimeSpan fourth)
        {
            _first = first;
            _second = second;
            _third = third;
            _fourth = fourth;
        }

        public string First
        {
            get=> _first.ToString(@"hh\:mm");
        }
        public string Second
        {
            get => _second.ToString(@"hh\:mm");
        }
        public string Third
        {
            get => _third.ToString(@"hh\:mm");
        }
        public string Fourth
        {
            get => _fourth.ToString(@"hh\:mm");
        }
    }
    public class TimePicker : UserControl
    {
        //private List<Times> _timeList;
        private List<Times> _times;
        private TimeSpan _timeNow = TimeSpan.Zero;
        private string catcher;

        public string Now
        {
            get => _timeNow.ToString(@"hh\:mm");
            set
            {
                try
                {
                    _timeNow = TimeSpan.Parse(value);
                }
                catch
                {
                    _timeNow = TimeSpan.Zero;
                    catcher = "Invalid TimePicker input. Turned to zero value. Check it";
                }
            }
        }

        private void TimerInitialize()
        {
            //_timeList = new List<TimeSpan>();
            _times = new List<Times>();
            for (int i = 0; i < 6; i++)
            {
                _times.Add(new Times(
                    TimeSpan.Parse(i * 4 + ":00"),
                    TimeSpan.Parse(i * 4 + 1 + ":00"),
                    TimeSpan.Parse(i * 4 + 2 + ":00"),
                    TimeSpan.Parse(i * 4 + 3 + ":00")));
                Console.WriteLine(TimeSpan.Parse(i * 4 + ":00").ToString());
                // _timeList.Add(TimeSpan.Parse(i+".00"));
            }
            var collectionTimes = new Avalonia.Collections.DataGridCollectionView(_times);
            var dgTimer = this.FindControl<DataGrid>("dgTimer");
            //dgTimer.IsReadOnly = true;
            dgTimer.ColumnHeaderHeight = 20;
            dgTimer.CellPointerPressed();
            dgTimer.Items = collectionTimes;
        }
        public TimePicker()
        {
            this.InitializeComponent();
            TimerInitialize();
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }
        //private void dgTimer_CellClick(object sender, DataGridViewCellEventArgs e)
        public void SelectedItem()
        {

        }
    }
}
