using System;
using System.Collections.Generic;
using System.Linq;

namespace SSSApp
{
    static class Utils
    {
        public static string AppDataPath = /*Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData)*/@"C:\Users\mmm60\Desktop\AppDatas\settings.ssss";

        public static AppSettings AppSettings;

        public static Dictionary<int, string> WeekDays = new Dictionary<int, string>() { { 0, "Понедельник" }, { 1, "Вторник" }, { 2, "Среда" },
            { 3, "Четверг" }, { 4, "Пятница" }, { 5, "Суббота" }, { 6, "Воскресенье" } };
        public static List<int> MuteList;
        public static bool MuteEnable;
        public static List<CallableLesson> CurrentLessons => AppSettings.CurrentMode.Lessons;

        public static TimeSpan CurrentTime => DateTime.Now.TimeOfDay;


        public static List<TimeSpan> With(this List<TimeSpan> left, List<TimeSpan> right)
        {
            List<TimeSpan> result = new List<TimeSpan>();
            result.AddRange(left);
            result.AddRange(right);
            return result;
        }

        public static TimeSpan NextCallTime
        {
            get
            {
                if (CurrentLessons != null && CurrentLessons.Count > 0)
                {
                    var allTimes = CurrentLessons.Select(i => i.STime).ToList().With(CurrentLessons.Select(i => i.ETime).ToList());
                    allTimes = allTimes.Where(i => i > DateTime.Now.TimeOfDay).ToList();
                    if (allTimes.Count > 0)
                        return allTimes.Min();
                    else
                    {
                        allTimes = CurrentLessons.Select(i => i.STime).ToList().With(CurrentLessons.Select(i => i.ETime).ToList());
                        allTimes = allTimes.Where(i => i < DateTime.Now.TimeOfDay).ToList();
                        var preOut = allTimes.Min();
                        preOut += TimeSpan.FromDays(1);
                        return preOut;
                    }
                }
                else
                    return TimeSpan.Zero;

            }
        }
    }
}
