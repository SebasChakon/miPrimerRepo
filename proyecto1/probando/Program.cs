using System.Text.Json;
using System.Text.Json.Nodes;

const string defaultConnectionMessage = "No se encontró la cadena de conexión.";
string connectionString = defaultConnectionMessage;
string configPath = Path.Combine(AppContext.BaseDirectory, "appsettings.json");

if (File.Exists(configPath))
{
    try
    {
        var json = JsonNode.Parse(File.ReadAllText(configPath));
        connectionString = json?["ConnectionStrings"]?["DefaultConnection"]?.GetValue<string>() ?? defaultConnectionMessage;
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Error leyendo la configuración: {ex.Message}");
    }
}

Console.WriteLine("Hello, Platzi!");
Console.WriteLine();
Console.WriteLine("Simulación de cadena de conexión:");
Console.WriteLine(connectionString);
