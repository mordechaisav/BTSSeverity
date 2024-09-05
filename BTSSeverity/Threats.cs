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
        public async Task StartThearts(DefenceStrategies tree)
        {
            string filePath = "C:/Users/Dell-pc/source/repos/BTSSeverity/BTSSeverity/Threats.json";

            try
            {
                string json = await File.ReadAllTextAsync(filePath);
                List<ThreatsModel> threats = JsonConvert.DeserializeObject<List<ThreatsModel>>(json);

                foreach (var threat in threats)
                {
                    Console.WriteLine($"the threat {threat.ThreatType} sent");
                    await Task.Delay(2000);
                    int severity = CalculateSeverity(threat);
                    var def = tree.Find(severity);
                    if (def == null)
                    {
                        DefenceNotFound(tree,severity);
                        continue;
                    }
                    Console.WriteLine($"The threat is: {threat.ThreatType}, the defenses are {def.Defenses}");

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
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
        public void DefenceNotFound(DefenceStrategies tree,int severity)
        {
            int? minDefence = tree.GetMin();
            if (minDefence != null)
            {
                if (minDefence > severity)
                {
                    Console.WriteLine("is severity Attack below the threshold. Attack is ignored");
                    return;
                }
                
            }
            Console.WriteLine("was defence suitable No !found. Brace for impact");

        }

    }
}
