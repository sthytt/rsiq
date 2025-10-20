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
        public int actionCount { get; private set; }
        public int totalRisk { get; private set; }

        public int timeElapsed { get; private set; }

        private System.Timers.Timer _riskTimer;

        public event EventHandler RiskLevelChanged;
        public event EventHandler ActionCountChanged;

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
            totalRisk = 0;
            RiskLevelChanged?.Invoke(this, EventArgs.Empty);
        }


        public void ResetTimer()
        {
            timeElapsed = 0;
            _riskTimer.Stop();
            _riskTimer.Dispose();
            _riskTimer = null;
        }

        public void IncreaseRisk()
        {
            if (totalRisk <= 99) 
            { 
                totalRisk += 1;
            }
            CountActions();

            RiskLevelChanged?.Invoke(this, EventArgs.Empty);
        }
        
        private void DecreaseRisk()
        {
            if (totalRisk >= 2)
            {
                totalRisk -= 3;
            }

            RiskLevelChanged?.Invoke(this, EventArgs.Empty);
        }

        private void CountActions()
        {
            if (actionCount < 500)
            {
                actionCount += 1;
                ActionCountChanged?.Invoke(this, EventArgs.Empty);
            }
        }

        public void ResetActions()
        {
            actionCount = 0;
            ActionCountChanged?.Invoke(this, EventArgs.Empty);
        }
    }
}
