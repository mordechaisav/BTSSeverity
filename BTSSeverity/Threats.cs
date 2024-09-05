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
        public void StartThearts(DefenceStrategies tree)
        {
            string filePath = "C:/Users/Dell-pc/source/repos/BTSSeverity/BTSSeverity/Threats.json";
            string json = File.ReadAllText(filePath);
            List<ThreatsModel> threats = JsonConvert.DeserializeObject<List<ThreatsModel>>(json);
            foreach (var threat in threats)
            {
                int severity = CalculateSeverity(threat);
                var def = tree.Find(severity);

                Console.WriteLine($"the threat is: {threat.ThreatType}, the defenses is {def.Defenses}");
            }


        }
        public int CalculateSeverity(ThreatsModel threat)
        {
            int targetValue = CalculatTarget(threat.Target);
            int severity = (threat.Volume * threat.Sophistication) + targetValue;
            return severity;
        }
        public static int CalculatTarget(string value)
        {
            
            Dictionary<string, int> Targets = new Dictionary<string, int>()
            {
                { "Web Server", 10 },
                { "Database", 15 },
                { "User Credentials", 20 }

            };
            
            if (Targets.ContainsKey(value))
            {
                return Targets[value];
            }
            return 5;
        }

    }
}
