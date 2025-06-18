using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Lab7
{
    internal static class FileInteraction
    {
        private const int EventPartsCount = 3;
        private const int EventTypeIndex = 0;
        private const int EventDateIndex = 1;
        private const int EventLocationIndex = 2;
        /// <summary>
        /// Reads event information from a specified input file and returns a list of <see cref="EventInfo"/> objects.
        /// </summary>
        /// <param name="inputFile">The path to the input file containing event data.</param>
        /// <returns>A list of <see cref="EventInfo"/> objects parsed from the file.</returns>

        public static List<EventInfo> ReadEvents(string inputFile)
        {
            return File.ReadAllLines(inputFile)
                .Select(line => line.Split(';'))
                .Where(parts => parts.Length == EventPartsCount)
                .Select(parts => new EventInfo(
                    Enum.Parse<SocialEvent>(parts[EventTypeIndex]),
                    DateTime.Parse(parts[EventDateIndex]),
                    parts[EventLocationIndex]
                ))
                .ToList();
        }

        /// <summary>
        /// Writes the provided list of events to the specified output file, grouping them by event type.
        /// </summary>
        /// <param name="outputFile">The path to the output file where event data will be written.</param>
        /// <param name="events">The list of <see cref="EventInfo"/> objects to write to the file.</param>
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