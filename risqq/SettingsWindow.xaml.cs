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
using System.Windows.Shapes;

namespace risqq
{
    public partial class SettingsWindow : Window
    {
        private DataService _dataService;
        private UserSettings _userSettings;

        public SettingsWindow()
        {
            InitializeComponent();
            _dataService = new DataService();
            _userSettings = new UserSettings();
            LoadSettings();

        }

        private async void LoadSettings()
        {
            try
            {
                _userSettings = await _dataService.LoadUserSettingsAsync();
                // update UI
                BreakDurationSlider.Value = _userSettings.BreakDuration.TotalMinutes;
                TimeBetweenBreaksSlider.Value = _userSettings.TimeBetweenBreaks.TotalMinutes;
                PostponeDurationSlider.Value = _userSettings.PostponeTime.TotalMinutes;

                NotificationsOnRadio.IsChecked = _userSettings.EnableNotifications;
                NotificationsOffRadio.IsChecked = !_userSettings.EnableNotifications;

                BreaksOnRadio.IsChecked = _userSettings.EnableBreaks;
                BreaksOffRadio.IsChecked = !_userSettings.EnableBreaks;

                // sound selected here
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Settings not loaded. Error: {ex.Message}");
            }
        }

        private async void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            _userSettings.BreakDuration = TimeSpan.FromMinutes(BreakDurationSlider.Value);
            _userSettings.TimeBetweenBreaks = TimeSpan.FromMinutes(TimeBetweenBreaksSlider.Value);
            _userSettings.PostponeTime = TimeSpan.FromMinutes(PostponeDurationSlider.Value);

            _userSettings.EnableNotifications = NotificationsOnRadio.IsChecked == true;
            _userSettings.EnableBreaks = BreaksOnRadio.IsChecked == true;

            await _dataService.SaveUserSettingsAsync(_userSettings);

            MessageBox.Show("Settings saved!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
            this.Close();
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
