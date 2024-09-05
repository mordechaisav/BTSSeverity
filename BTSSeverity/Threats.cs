using BTSSeverity.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTSSeverity
{
    //מחלקה שמאתחלת התקפות סייבר
    internal class Threats
    {

        //מתחיל את המתקפה
        //o(n)
        public async Task StartThearts(DefenceStrategies tree)
        {
            //כתובת של קובץ שמכיל את ההתקפות
            string filePath = "C:/Users/Dell-pc/source/repos/BTSSeverity/BTSSeverity/Threats.json";

            try
            {
                //קורא מהקובץ וממיר אותו לרשימה של מודלים של התקפות
                string json = await File.ReadAllTextAsync(filePath);
                List<ThreatsModel> threats = JsonConvert.DeserializeObject<List<ThreatsModel>>(json);
                //רץ על כל ההתקפות
                foreach (var threat in threats)
                {
                    Console.WriteLine($"the threat {threat.ThreatType} sent");
                    await Task.Delay(2000);

                    //חישוב החומרה של ההתקפה על ידי פונקציית עזר
                    int severity = CalculateSeverity(threat);

                    //חיפוש ההגנה המתאימה
                    var def = tree.Find(severity);
                    if (def == null)
                    {
                        //הדפסה נכונה במקרה שאין הגנה מתאימה
                        DefenceNotFound(tree,severity);
                        continue;
                    }
                    //הדפסת הסוג של ההתקפה ואת ההגנות המתאימות
                    Console.WriteLine($"The threat is: {threat.ThreatType}, the defenses are {def.Defenses}");

                }
            }
            catch (Exception ex)
            {
                //הדפסת השגיאה במקרה ולא הצליח לקרוא מהקובץ
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }

        //חישוב החומרה של ההתקפה לפי הנוסחה המתאימה
        //O(1)
        private int CalculateSeverity(ThreatsModel threat)
        {
            int targetValue = CalculatTarget(threat.Target);
            int severity = (threat.Volume * threat.Sophistication) + targetValue;
            return severity;
        }

        //חישוב החומרה של מטרה לפי השם
        //O(1)
        private static int CalculatTarget(string value)
        {
            
            Dictionary<string, int> Targets = new Dictionary<string, int>()
            {
                { "Web Server", 10 },
                { "Database", 15 },
                { "User Credentials", 20 }

            };
            //בדיקה אם המטרה קיימת במילון להחזיר את ערך החומרה שלה ואם לא להחזיר 
            //ערך דיפולטיבי של 5
            if (Targets.ContainsKey(value))
            {
                return Targets[value];
            }
            return 5;
        }

        //חישוב הדפסה מתאימה במקרה שאין הגנה
        //o(log(n))
        private void DefenceNotFound(DefenceStrategies tree,int severity)
        {
            //קבלת הטווח המינימלי של הגנה
            int? minDefence = tree.GetMin();
            if (minDefence != null)
            {
                if (minDefence > severity)
                {
                    //במקרה שהחומרה של ההתקפה נמוכה מהחומרה המינימלית 
                    Console.WriteLine("is severity Attack below the threshold. Attack is ignored");
                    return;
                }
                
            }
            //הדפסה במקרה שאין הגנה מתאימה
            Console.WriteLine("was defence suitable No !found. Brace for impact");

        }

    }
}
