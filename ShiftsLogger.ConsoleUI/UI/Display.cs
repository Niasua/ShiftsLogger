using ShiftsLogger.ConsoleUI.Models;
using Spectre.Console;

namespace ShiftsLogger.ConsoleUI.UI;

public static class Display
{
    public static void ShowWorkers(List<Worker> workers)
    {
        var table = new Table();
        table.Border(TableBorder.Rounded);
        table.AddColumn("[yellow]Id[/]");
        table.AddColumn("[blue]Name[/]");
        table.AddColumn("[green]Job[/]");

        var apiService = new ApiService();

        foreach (var worker in workers)
        {
            table.AddRow(
                worker.Id.ToString(),
                worker.Name.ToString(),
                worker.Job.ToString()
                );
        }

        AnsiConsole.Write(table);
    }

    public static void ShowContact(Worker worker)
    {
        var table = new Table();
        table.Border(TableBorder.Rounded);
        table.AddColumn("[yellow]ID[/]");
        table.AddColumn("[blue]Name[/]");
        table.AddColumn("[green]Job[/]");

        var apiService = new ApiService();

        table.AddRow(
                 worker.Id.ToString(),
                 worker.Name.ToString(),
                 worker.Job.ToString()
                 );

        AnsiConsole.Write(table);
    }
}
