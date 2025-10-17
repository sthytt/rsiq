using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents;
using System.Threading;
using System.Drawing.Printing;


namespace risqq
{
    class RiskCalculationService
    {
        public int TotalRisk { get; private set; }

        public int TimeElapsed { get; private set; }

        private System.Timers.Timer _riskTimer;

        public event EventHandler RiskLevelChanged;

        public void SetTimer()
        {
            _riskTimer = new System.Timers.Timer(1000);
            _riskTimer.Elapsed += TimerOnElapsed;
            _riskTimer.AutoReset = true;
            _riskTimer.Enabled = true;
        }

        public void TimerOnElapsed(object? sender, System.Timers.ElapsedEventArgs e)
        {
            DecreaseRisk();
        }

        public void StartTimer()
        {
            if (_riskTimer == null)
            {
                SetTimer();
            }
            else
            {
                _riskTimer.Start(); // resume existing timer
            }
        }

        public void PauseTimer()
        {
            _riskTimer.Stop();
        }

        public void ResetRisk()
        {
            TotalRisk = 0;
            RiskLevelChanged?.Invoke(this, EventArgs.Empty);
        }


        public void ResetTimer()
        {
            TimeElapsed = 0;
            _riskTimer.Stop();
            _riskTimer.Dispose();
            _riskTimer = null;
        }

        public void IncreaseRisk()
        {
            if (TotalRisk <= 99) 
            { 
                TotalRisk += 1;
            }

            RiskLevelChanged?.Invoke(this, EventArgs.Empty);
        }
        
        private void DecreaseRisk()
        {
            if (TotalRisk >= 2)
            {
                TotalRisk -= 3;
            }

            RiskLevelChanged?.Invoke(this, EventArgs.Empty);
        }
    }
}
