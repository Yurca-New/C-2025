using System;
using System.Collections.Generic;

namespace Lab7
{
    internal static class ConsoleInteraction
    {
        public static void DisplayEvents(List<EventInfo> events)
        {
            for (int i = 0; i < events.Count; i++)
            {
                Console.WriteLine($"[{i}]: {events[i].GetInfo()}");
            }
        }

        public static int SelectEvent(int eventCount)
        {
            Console.WriteLine("\nSelect Event");
            if (int.TryParse(Console.ReadLine(), out int selectedEvent) &&
                selectedEvent >= 0 && selectedEvent < eventCount)
            {
                return selectedEvent;
            }
            Console.WriteLine("Invalid selection.");
            return -1;
        }

        public static void ShowEventDetails(EventInfo eventInfo)
        {
            Console.WriteLine("Press Home for red or End for yellow");
            ConsoleKey key = Console.ReadKey(true).Key;
            ConsoleColor color = key == ConsoleKey.Home ? ConsoleColor.Red : ConsoleColor.Yellow;
            Console.ForegroundColor = color;
            Console.WriteLine($"You selected: {eventInfo.GetInfo()}");
            Console.WriteLine($"Time until event: {eventInfo.HowLongUntilEvent()}");
            Console.ResetColor();
        }

        public static void ShowOutputWritten()
        {
            Console.WriteLine("Информация записана в файл output.txt");
        }
    }
}