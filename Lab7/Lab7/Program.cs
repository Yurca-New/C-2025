using System;
using System.Collections.Generic;
using Lab7;

enum SocialEvent
{
    Conference,
    Workshop,
    Seminar,
    Meetup
}

class Program
{
    static void Main()
    {
        string inputFile = "../../../input.txt";
        string outputFile = "../../../output.txt";

        List<EventInfo> Events = FileInteraction.ReadEvents(inputFile);

        ConsoleInteraction.DisplayEvents(Events);

        int selectedEvent = ConsoleInteraction.SelectEvent(Events.Count);
        if (selectedEvent != -1)
        {
            ConsoleInteraction.ShowEventDetails(Events[selectedEvent]);
        }

        FileInteraction.WriteEvents(outputFile, Events);

        ConsoleInteraction.ShowOutputWritten();
    }
}
