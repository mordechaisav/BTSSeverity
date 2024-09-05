using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTSSeverity.Models
    //מודל שיסייע לשלוף ערכים של התקפות מתוך קובץ
{public class ThreatsModel
    {
        public string ThreatType { get; set; }
        public int Volume { get; set; }
        public int Sophistication { get; set; }
        public string Target { get; set; }
    }
}
