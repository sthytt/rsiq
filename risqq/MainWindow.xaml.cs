using System.Windows;

namespace risqq
{
    public partial class MainWindow : Window
    {
        private InputMonitorService _inputMonitor;
        private RiskCalculationService _riskCalculator;
        private BreakService _breakManager;
        private DataService _dataService;
        private UserSettings _userSettings;
        private bool _sessionActive;
        public MainWindow()
        {
            InitializeComponent();
            _riskCalculator = new RiskCalculationService();
            _inputMonitor = new InputMonitorService();
            _userSettings = new UserSettings();
            _dataService = new DataService();

            _inputMonitor.InputDetected += OnInputDetected;
            _riskCalculator.RiskLevelChanged += RiskLevelIndicator;
        }
        private void OnInputDetected(object sender, EventArgs e)
        {
            if (_inputMonitor.isTracking == true)
            {
                _riskCalculator.IncreaseRisk();
            }

            Console.WriteLine(_riskCalculator.TotalRisk)  ;
        }

        private void SessionButton_Click(object sender, RoutedEventArgs e)
        {
            AbortButton.IsEnabled = true;
            AbortButton.Visibility = Visibility.Visible;

            if (!_sessionActive)
            {
                _inputMonitor.StartMonitoring();
                _riskCalculator.StartTimer();
                SessionButton.Content = "Pause";
                _sessionActive = true;
            }
            else
            {
                // pausing
                _inputMonitor.StopMonitoring();
                _riskCalculator.PauseTimer();
                SessionButton.Content = "Resume";
                _sessionActive = false;
            }
        }

        public void RiskLevelIndicator(object sender, EventArgs e)
        {
            switch (_riskCalculator.TotalRisk)
            {
                case <= 20:
                    RiskIndicator.Stroke = System.Windows.Media.Brushes.Green;
                    break;
                case <= 50:
                    RiskIndicator.Stroke = System.Windows.Media.Brushes.Yellow;
                    break;
                case <= 80:
                    RiskIndicator.Stroke = System.Windows.Media.Brushes.Orange;
                    break;
                case <= 100:
                    RiskIndicator.Stroke = System.Windows.Media.Brushes.Red;
                    break;
            }
        }

        private void SettingsButton_Click(object sender, RoutedEventArgs e)
        {
            SettingsWindow settingsWindow = new SettingsWindow();
            settingsWindow.Show();
        }

        private void AutoclickButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void AbortButton_Click(object sender, RoutedEventArgs e)
        {
            if (_sessionActive)
            {
                _inputMonitor.StopMonitoring();
                _riskCalculator.ResetTimer();
                _riskCalculator.ResetRisk();
                RiskIndicator.Stroke = System.Windows.Media.Brushes.Gray;
                _sessionActive = false;
                SessionButton.Content = "Start";
                AbortButton.IsEnabled = false;
                AbortButton.Visibility = Visibility.Hidden;
            }
        }
        private void LogButton_Click(object sender, RoutedEventArgs e)
        {
        }
    }
}