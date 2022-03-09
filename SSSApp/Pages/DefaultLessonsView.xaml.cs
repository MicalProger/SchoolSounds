using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace SSSApp.Pages
{
    /// <summary>
    /// Логика взаимодействия для DefaultLessonsView.xaml
    /// </summary>
    public partial class DefaultLessonsView : Page
    {
        public List<CallableLesson> Lessons;
        public DefaultLessonsView(List<CallableLesson> lessons)
        {
            InitializeComponent();
            Lessons = lessons;
            if (Lessons != null)
                LsLB.ItemsSource = Lessons;
            if (Utils.AppSettings.CurrentMode.MuteList == null)
                Utils.AppSettings.CurrentMode.MuteList = new List<int>();
            foreach (var item in Utils.AppSettings.CurrentMode.MuteList)
            {
                (WBCollector.Children[item] as CheckBox).IsChecked = false;
            }
            if (Utils.AppSettings.CurrentMode.MuteEnable)
            {
                MuteRB.IsChecked = true;
                WBCollector.IsEnabled = true;
            }
        }

        private void LsAdd(object sender, RoutedEventArgs e)
        {
            CallableLesson callableLesson = new CallableLesson() { Id = Lessons.Count + 1 };

            Lessons.Add(callableLesson);
            LsLB.ItemsSource = null;
            LsLB.ItemsSource = Lessons;
        }

        private void LsRemove(object sender, RoutedEventArgs e)
        {
            if (Lessons.Count > 0)
                Lessons.RemoveAt(Lessons.Count - 1);
            LsLB.ItemsSource = null;
            LsLB.ItemsSource = Lessons;
        }

        private void ResetMuteMode(object sender, RoutedEventArgs e)
        {
            var rb = sender as RadioButton;
            if (rb.Content as string == "Активно всегда")
            {
                WBCollector.IsEnabled = false;
                Utils.AppSettings.CurrentMode.MuteEnable = false;
            }
            else
            {
                WBCollector.IsEnabled = true;
                Utils.AppSettings.CurrentMode.MuteEnable = true;
            }
        }

        private void UpdateDayMute(object sender, RoutedEventArgs e)
        {
            var cb = sender as CheckBox;
            if (Utils.AppSettings.CurrentMode.MuteList == null)
                Utils.AppSettings.CurrentMode.MuteList = new List<int>();
            if (!cb.IsChecked.GetValueOrDefault())
                Utils.AppSettings.CurrentMode.MuteList.Add((cb.Parent as WrapPanel).Children.IndexOf(cb));
            else
                Utils.AppSettings.CurrentMode.MuteList.Remove((cb.Parent as WrapPanel).Children.IndexOf(cb));

        }
    }
}
