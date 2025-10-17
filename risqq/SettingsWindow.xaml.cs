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

        public SettingsWindow()
        {
            InitializeComponent();
            _dataService = new DataService();
            LoadSettings();

        }

        private async void LoadSettings()
        {
            await _dataService.LoadUserSettingsAsync();
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            // Save all settings
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            // Close window without saving
        }

        private void BreakDurationSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            // Handle break duration change
        }

        private void TimeBetweenBreaksSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            // Handle time between breaks change
        }

        private void PostponeDurationSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            // Handle postpone duration change
        }

        private void NotificationsOnRadio_Checked(object sender, RoutedEventArgs e)
        {
            // Handle notifications enabled
        }

        private void NotificationsOffRadio_Checked(object sender, RoutedEventArgs e)
        {
            // Handle notifications disabled
        }

        private void BreaksOnRadio_Checked(object sender, RoutedEventArgs e)
        {
            // Handle breaks enabled
        }

        private void BreaksOffRadio_Checked(object sender, RoutedEventArgs e)
        {
            // Handle breaks disabled
        }

        private void NotificationSoundComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // Handle notification sound selection change
        }
    }
}
