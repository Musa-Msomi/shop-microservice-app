using Carter;

internal class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        builder.Services.AddCarter();

        var app = builder.Build();
        app.MapCarter();

        app.Run();
    }
}