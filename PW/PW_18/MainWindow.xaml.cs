using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;
using TimeZoneConverter;

namespace PW_18
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly DispatcherTimer _timer;
        private TimeZoneInfo _selectedTimeZone;

        public MainWindow()
        {
            InitializeComponent();

            // Установка локального часового пояса по умолчанию
            _selectedTimeZone = TimeZoneInfo.Local;

            // Настройка таймера
            _timer = new DispatcherTimer
            {
                Interval = TimeSpan.FromSeconds(1)
            };
            _timer.Tick += Timer_Tick;
            _timer.Start();

            UpdateTime();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            UpdateTime();
        }

        private void UpdateTime()
        {
            var now = DateTime.UtcNow;
            var timeInSelectedZone = TimeZoneInfo.ConvertTimeFromUtc(now, _selectedTimeZone);
            TimeTextBlock.Text = timeInSelectedZone.ToString("HH:mm:ss");
        }

        private void TimeZoneComboBox_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            if (TimeZoneComboBox.SelectedItem is System.Windows.Controls.ComboBoxItem selectedItem)
            {
                var timeZoneId = selectedItem.Tag as string;
                _selectedTimeZone = string.IsNullOrEmpty(timeZoneId)
                    ? TimeZoneInfo.Local
                    : TZConvert.GetTimeZoneInfo(timeZoneId);
            }
        }
    }
}
