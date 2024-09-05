using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTSSeverity.Models
{
    public class DefenceModel
    {
        public int MinSeverity { get; set; }
        public int MaxSeverity { get; set; }
        public List<string> Defenses { get; set; }
        public DefenceModel Left {  get; set; }
        public DefenceModel Right { get; set; }
    }
}
