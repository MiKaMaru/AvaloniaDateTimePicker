using System;
using System.Runtime.InteropServices;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace AvaloniaDateTimePicker
{
    public class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
#if DEBUG
            this.AttachDevTools();
#endif
            TimePickerInit();
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);

        }

        private void TimePickerInit()
        {
            var stkTimePicker = this.FindControl<StackPanel>("stkTimePicker");
            var tpExample = new TimePicker();
            stkTimePicker.Children.Add(tpExample);
            Console.WriteLine("dg was borned");
        }
    }
}
