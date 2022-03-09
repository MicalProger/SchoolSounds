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
        public List<CallableLesson> Lessons { get; set; } = new List<CallableLesson>();
        public List<int> MuteList;
        public bool MuteEnable;
    }
}
