using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSSApp
{
    internal class CallingMode
    {
        public string Name { get; set; }
        public List<CallableLesson> Lessons { get; set; }
        public static List<int> MuteList;
        public static bool MuteEnable;
    }
}
