using lab3;
Device[] devices = new Device[]
    {
        new Laptop(),
        new Smartphone(),
        new Tablet()
    };

foreach (Device device in devices)
{
    device.TurnOn();
}