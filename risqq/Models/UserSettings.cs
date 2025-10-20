using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace risqq
{
    public enum NotificationSound
    {
        Bell,
        Bird,
        Digital,
        Kitchen,
        Wood
    }
    class UserSettings
    {
        public TimeSpan BreakDuration { get; set; } = TimeSpan.FromMinutes(5);
        public TimeSpan TimeBetweenBreaks { get; set; } = TimeSpan.FromMinutes(25);

        public TimeSpan PostponeTime { get; set; } = TimeSpan.FromMinutes(3);
        public NotificationSound SelectedSound { get; set; } = NotificationSound.Bell;

        public bool EnableNotifications { get; set; } = true;

        public bool EnableBreaks { get; set; } = true;

        private static readonly Dictionary<NotificationSound, string> SoundFiles = new()
        {
            {NotificationSound.Bell, "sounds/bell-notification.mp3" },
            {NotificationSound.Bird, "sounds/bird-notification.mp3" }
        };
    }
}
