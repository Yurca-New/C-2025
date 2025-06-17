using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Lab7
{
    internal static class FileInteraction
    {
        public static List<EventInfo> ReadEvents(string inputFile)
        {
            return File.ReadAllLines(inputFile)
                .Select(line => line.Split(';'))
                .Where(parts => parts.Length == 3)
                .Select(parts => new EventInfo(
                    Enum.Parse<SocialEvent>(parts[0]),
                    DateTime.Parse(parts[1]),
                    parts[2]
                ))
                .ToList();
        }

        public static void WriteEvents(string outputFile, List<EventInfo> events)
        {
            using (StreamWriter writer = new StreamWriter(outputFile, false, Encoding.UTF8))
            {
                foreach (SocialEvent evt in Enum.GetValues(typeof(SocialEvent)))
                {
                    writer.WriteLine(evt);
                    var matching = events.Where(e => e.EventType == evt).ToList();

                    if (matching.Count == 0)
                    {
                        writer.WriteLine("не запланировано");
                        writer.WriteLine();
                    }
                    else
                    {
                        writer.WriteLine("№\tМесто проведения\tДата проведения\tКоличество дней до мероприятия");
                        for (int i = 0; i < matching.Count; i++)
                        {
                            writer.WriteLine($"{i + 1}\t{matching[i].Location}\t{matching[i].Date:d}\t{matching[i].HowLongUntilEvent()}");
                        }
                        writer.WriteLine();
                    }
                }
            }
        }
    }
}