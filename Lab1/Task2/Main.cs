using Task2;
try
{
    var app = new SportsManApp();
    app.Run();
}
catch (Exception ex)
{
    Console.WriteLine($"Critical error: {ex.Message}");
}