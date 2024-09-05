using BTSSeverity.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTSSeverity
{
    public class Threats
    {
        public void StartThearts()
        {
            string filePath = "C:/Users/Dell-pc/source/repos/BTSSeverity/BTSSeverity/Threats.json";
            string json = File.ReadAllText(filePath);
            List<ThreatsModel> defenses = JsonConvert.DeserializeObject<List<ThreatsModel>>(json);



        }

    }
}
