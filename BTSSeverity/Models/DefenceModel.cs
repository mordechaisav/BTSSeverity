using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTSSeverity.Models
{
    //מודל שיסיע בקריאת ערכים של הגנות מתוך קובץ json
    public class DefenceModel
    {
        public int MinSeverity { get; set; }
        public int MaxSeverity { get; set; }
        public List<string> Defenses { get; set; }
    }
}
