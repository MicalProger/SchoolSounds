using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
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
            Utils.AppSettings = JsonConvert.DeserializeObject<AppSettings>(File.ReadAllText(Utils.AppDataPath));
            Utils.MuteList = new List<int> { };
            if (Utils.AppSettings.CallingModes != null && Utils.AppSettings.CallingModes.Count > 0)
            {
                foreach (var mode in Utils.AppSettings.CallingModes)
                {
                    var newTB = new TextBox();
                    newTB.DataContext = mode;
                    Binding binding = new Binding("Name");
                    newTB.SetBinding(TextBox.TextProperty, binding);
                    newTB.GotFocus += ChangeMode;
                    ModesCollector.Items.Insert(ModesCollector.Items.Count - 2, newTB);
                }
                MainFrame.Navigate(new Pages.DefaultLessonsView(Utils.CurrentLessons));
            }
            else
                Utils.AppSettings.CallingModes = new List<CallingMode>();
            DispatcherTimer timer = new DispatcherTimer();
            Thread.CurrentThread.CurrentUICulture = CultureInfo.GetCultureInfo("ru-RU");
            timer.Interval = TimeSpan.FromSeconds(1);
            timer.Tick += UpdateWatch;
            timer.Start();

        }

        private void UpdateWatch(object sender, EventArgs e)
        {
            WatchTB.Text = Utils.CurrentTime.ToString("hh':'mm':'ss");
            if (Utils.AppSettings.CallingModes != null && Utils.AppSettings.CallingModes.Count > 0)
            {
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

        }

        private void GoSetingsPage(object sender, RoutedEventArgs e)
        {
            var mi = e.Source as MenuItem;
            if (string.Equals(mi.Header, "Параметры"))
                MainFrame.Navigate(new Pages.SettingsPage());
        }
        private void AddCallingMode(object sender, RoutedEventArgs e)
        {
            Utils.AppSettings.CallingModes.Add(new CallingMode() { Name = "Новый режим" + (ModesCollector.Items.Count - 1) });
            var newTB = new TextBox();
            newTB.DataContext = Utils.AppSettings.CallingModes.Last();
            Binding binding = new Binding("Name");
            newTB.SetBinding(TextBox.TextProperty, binding);
            newTB.MouseUp += ChangeMode;
            ModesCollector.Items.Insert(ModesCollector.Items.Count - 2, newTB);
        }

        private void ChangeMode(object sender, RoutedEventArgs e)
        {
            Utils.AppSettings.CurrentModeId = ModesCollector.Items.IndexOf(sender);
            MainFrame.Navigate(new Pages.DefaultLessonsView(Utils.CurrentLessons));
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            File.WriteAllText(Utils.AppDataPath, JsonConvert.SerializeObject(Utils.AppSettings, Formatting.Indented));
        }
    }
}
