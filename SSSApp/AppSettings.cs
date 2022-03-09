using System;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSSApp
{
    internal class AppSettings
    {
        public List<CallingMode> CallingModes { get; set; }
        public int LsDuration { get; set; }
        public string CallingMusic { get; set; }
        public int CurrentModeId;
        [JsonIgnore]
        public CallingMode CurrentMode => CallingModes[CurrentModeId];
    }
}
