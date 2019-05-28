using System.Collections.Generic;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Layout;
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
        private List<TimeSpan> content;

        public Times(List<TimeSpan> _content)
        {
           content = new List<TimeSpan>(_content);
        }

        public string First
        {
            get=> content[0].ToString(@"hh\:mm");
        }
        public string Second
        {
            get => content[1].ToString(@"hh\:mm");
        }
        public string Third
        {
            get => content[2].ToString(@"hh\:mm");
        }
        public string Fourth
        {
            get => content[3].ToString(@"hh\:mm");
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
                var tmp = new List<TimeSpan>();
                tmp.Add(TimeSpan.Parse(i * 4 + ":00"));
                tmp.Add(TimeSpan.Parse(i * 4 + 1 + ":00"));
                tmp.Add(TimeSpan.Parse(i * 4 + 2 + ":00"));
                tmp.Add(TimeSpan.Parse(i * 4 + 3 + ":00"));
                _times.Add(new Times(tmp));
                Console.WriteLine(_times[i].First);
            }
            var collectionTimes = new Avalonia.Collections.DataGridCollectionView(_times);
            var dgTimer = this.Get<DataGrid>("dgTimer");
            //dgTimer.IsReadOnly = true;
            dgTimer.ColumnHeaderHeight = 20;
            dgTimer.CellPointerPressed += DgTimer_CellPointerPressed; ;
            dgTimer.Items = collectionTimes;
            dgTimer.ColumnWidth = new DataGridLength(40);
            dgTimer.VerticalAlignment = VerticalAlignment.Center;
        }

        private void DgTimer_CellPointerPressed(object sender, DataGridCellPointerPressedEventArgs e)
        {
            var dg = (DataGrid) sender;
            var column = dg.CurrentColumn;
            var cell = column.GetCellContent(dg.SelectedItem);
            Console.WriteLine(cell.ToString());
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
