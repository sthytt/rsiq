using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace risqq
{
    class UserSettings
    {
        public TimeSpan BreakDuration { get; set; } = TimeSpan.FromMinutes(5);
        public TimeSpan TimeBetweenBreaks { get; set; } = TimeSpan.FromMinutes(25);

        public TimeSpan PostponeTime { get; set; } = TimeSpan.FromMinutes(3);

        public bool EnableNotifications { get; set; } = true;

        public bool EnableBreaks { get; set; } = true;

        public enum NotificationSound { 
            Bell, 
            Bird, 
            Digital,
            Kitchen,
            Wood
        }
    }
}
