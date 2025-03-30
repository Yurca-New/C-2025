using Task1;
try
{
    var app = new ArrayProcessingApp();
    app.Run();
}
catch (Exception ex)
{
    Console.WriteLine($"Critical error: {ex.Message}");
}