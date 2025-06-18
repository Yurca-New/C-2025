using System;
using System.Collections.Generic;

namespace Lab7
{
    internal static class ConsoleInteraction
    {
        /// <summary>
        /// Displays a message to the console.
        /// </summary>
        /// <param name="message">The message to display.</param>
        private static void DisplayeMessage(string message)
        {
            Console.WriteLine(message);
        }

        /// <summary>
        /// Displays an error message in red color to the console.
        /// </summary>
        /// <param name="errorMessage">The error message to display.</param>
        private static void DisplayError(string errorMessage)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            DisplayeMessage($"Error: {errorMessage}");
            Console.ResetColor();
        }

        /// <summary>
        /// Displays a list of events with their indices.
        /// </summary>
        /// <param name="events">The list of <see cref="EventInfo"/> objects to display.</param>
        public static void DisplayEvents(List<EventInfo> events)
        {
            for (int i = 0; i < events.Count; i++)
            {
                DisplayeMessage($"[{i}]: {events[i].GetInfo()}");
            }
        }

        /// <summary>
        /// Prompts the user to select an event by index and returns the selected index.
        /// </summary>
        /// <param name="eventCount">The total number of events available for selection.</param>
        /// <returns>
        /// The index of the selected event if valid; otherwise, -1.
        /// </returns>
        public static int SelectEvent(int eventCount)
        {
            DisplayeMessage("\nSelect Event");
            if (int.TryParse(Console.ReadLine(), out int selectedEvent) &&
                selectedEvent >= 0 && selectedEvent < eventCount)
            {
                return selectedEvent;
            }
            DisplayError("Invalid selection.");
            return -1;
        }

        /// <summary>
        /// Shows detailed information about the specified event and highlights the output in red or yellow based on user input.
        /// </summary>
        /// <param name="eventInfo">The <see cref="EventInfo"/> object whose details are to be displayed.</param>
        public static void ShowEventDetails(EventInfo eventInfo)
        {
            DisplayeMessage("Press Home for red or End for yellow");
            ConsoleKey key = Console.ReadKey(true).Key;
            ConsoleColor color = key == ConsoleKey.Home ? ConsoleColor.Red : ConsoleColor.Yellow;
            Console.ForegroundColor = color;
            DisplayeMessage($"You selected: {eventInfo.GetInfo()}");
            DisplayeMessage($"Time until event: {eventInfo.HowLongUntilEvent()}");
            Console.ResetColor();
        }

        /// <summary>
        /// Displays a message indicating that the output has been written to the file.
        /// </summary>
        public static void ShowOutputWritten()
        {
            DisplayeMessage("Информация записана в файл output.txt");
        }
    }
}