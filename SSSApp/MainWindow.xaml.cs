using Microsoft.Win32;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Media;
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
            try
            {
                InitializeComponent();
                Utils.AppSettings = JsonConvert.DeserializeObject<AppSettings>(File.ReadAllText(Utils.SettingsPath));
                Utils.MuteList = new List<int> { };
                if (Utils.AppSettings.CallingModes != null && Utils.AppSettings.CallingModes.Count > 0)
                {
                    foreach (var mode in Utils.AppSettings.CallingModes)
                    {
                        var newTB = new TextBox();
                        newTB.DataContext = mode;
                        Binding binding = new Binding("Name");
                        newTB.SetBinding(TextBox.TextProperty, binding);
                        newTB.MouseDown += ChangeMode;
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
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }
        public void Call()
        {
            MediaPlayer player = new MediaPlayer();
            player.Open(new Uri(Utils.AppSettings.CallingMusic));
            player.Play();
        }

        public async void CallAsync()
        {
            await Task.Run(() => Call());
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
                    if (nextDelta.TotalMilliseconds < 1000)
                    {
                        if (!string.IsNullOrWhiteSpace(Utils.AppSettings.CallingMusic))
                            try
                            {
                                CallAsync();
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show(ex.Message);
                            }

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
            try
            {
                File.WriteAllText(Utils.SettingsPath, JsonConvert.SerializeObject(Utils.AppSettings, Formatting.Indented));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void SaveSt(object sender, RoutedEventArgs e)
        {
            SaveFileDialog save = new SaveFileDialog();
            save.Filter = "настройки (.json)|*.json";

            if (save.ShowDialog().GetValueOrDefault())
            {
                File.WriteAllText(save.FileName, JsonConvert.SerializeObject(Utils.AppSettings, Formatting.Indented));
            }
        }
        private void ImportSt(object sender, RoutedEventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            open.Filter = "настройки (.json)|*.json";
            if (open.ShowDialog().GetValueOrDefault())
            {
                var preSt = JsonConvert.DeserializeObject<AppSettings>(File.ReadAllText(open.FileName));
                if(preSt != null)
                {
                    Utils.AppSettings = preSt;
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
                }

            }
        }
        private void OnPlay(object sender, RoutedEventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            open.Filter = ".wav|*.wav|.mp3|*.mp3";
            if (open.ShowDialog().GetValueOrDefault())
            {
                try
                {
                    MediaPlayer player = new MediaPlayer();
                    player.Open(new Uri(open.FileName));
                    player.Play();
                }
                catch
                {
                    MessageBox.Show("Усп. Какая то ошибка. Проверьте формат файлов.");
                }
            }
        }

    }
}
