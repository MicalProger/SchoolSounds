using System;
using System.Collections.Generic;
using System.Globalization;
using System.Threading;
using System.Windows;
using System.Windows.Navigation;
using System.Windows.Threading;

namespace SSSApp
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Utils.CurrentLessons = new List<CallableLesson>();
            Utils.MuteList = new List<int> { };
            MainFrame.Navigate(new Pages.DefaultLessonsView(Utils.CurrentLessons));
            DispatcherTimer timer = new DispatcherTimer();
            Thread.CurrentThread.CurrentUICulture = CultureInfo.GetCultureInfo("ru-RU");
            timer.Interval = TimeSpan.FromSeconds(1);
            timer.Tick += UpdateWatch;
            timer.Start();
            
        }

        private void UpdateWatch(object sender, EventArgs e)
        {
            WatchTB.Text = Utils.CurrentTime.ToString("hh':'mm':'ss");
            NCTB.Text = (Utils.NextCallTime - Utils.CurrentTime).ToString("hh':'mm':'ss");
            Utils.CurrentLessons.ForEach(i => i.UpdateColors());
            var nextDelta = Utils.NextCallTime - Utils.CurrentTime;
            int dow = (int)(DateTime.Now.DayOfWeek + 5) % 7;
            if (!Utils.MuteList.Contains(dow))
                if (nextDelta.Seconds == 0)
                {
                    //MediaPlayer player = new MediaPlayer();
                    //player.Open(new Uri(""));
                    //player.Play();
                }
        }

        private void GoSetingsPage(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new Pages.SettingsPage());
        }
        private void AddCallingMode(object sender, RoutedEventArgs e)
        {
            Console.WriteLine("AddedPreset");
        }
    }
}
