using ShiftsLogger.ConsoleUI;

ApiService apiService = new ApiService();

var workers = await apiService.GetWorkersAsync();

if (workers != null)
{
    Console.WriteLine("Trabajadores:");
    foreach (var w in workers)
    {
        Console.WriteLine($"ID: {w.Id} - Nombre: {w.Name} - Trabajo: {w.Job}");
    }
}
else
{
    Console.WriteLine("No se pudo obtener la lista de trabajadores.");
}