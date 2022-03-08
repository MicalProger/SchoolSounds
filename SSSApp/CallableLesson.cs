using System;
using System.ComponentModel;
using System.Windows.Media;

namespace SSSApp
{
    public class CallableLesson : INotifyPropertyChanged
    {
        public bool IsDefaultLsTime { get; set; } = true;
        public bool IsLessonTime(TimeSpan time) => STime < DateTime.Now.TimeOfDay && ETime > DateTime.Now.TimeOfDay;
        public SolidColorBrush LsColor
        {
            get
            {
                if (STime < DateTime.Now.TimeOfDay && ETime > DateTime.Now.TimeOfDay)
                    return new SolidColorBrush(Colors.Green);
                else if (STime < DateTime.Now.TimeOfDay)
                    return new SolidColorBrush(Colors.Yellow);
                else return new SolidColorBrush(Colors.White);
            }
        }
        public int Id { get; set; }
        public string Name => $"{Id}-й урок";
        public TimeSpan STime;
        public TimeSpan ETime;

        public event PropertyChangedEventHandler PropertyChanged;

        public string STimeStr
        {
            get => STime.ToString("hh':'mm");
            set
            {
                if (TimeSpan.TryParse(value, out STime) && IsDefaultLsTime)
                {                    
                    ETime = STime + TimeSpan.FromMinutes(45);
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(ETimeStr)));
                }
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(LsColor)));
            }

        }
        public string ETimeStr
        {
            get => ETime.ToString("hh':'mm");
            set
            {
                if (TimeSpan.TryParse(value, out ETime) && IsDefaultLsTime)
                {
                    STime = ETime - TimeSpan.FromMinutes(45);
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(STimeStr)));
                }
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(LsColor)));
            }
        }

        public void UpdateColors() => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(LsColor)));
    }
}
