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

    public static void ShowWorker(Worker worker)
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

    public static Worker? PromptSelectWorker(List<Worker> workers)
    {
        if (workers == null || workers.Count == 0)
        {
            AnsiConsole.MarkupLine("[red]No workers available.[/]");
            return null;
        }

        var selected = AnsiConsole.Prompt(
            new SelectionPrompt<Worker>()
            .Title("[green]Select a worker:[/]")
            .PageSize(10)
            .UseConverter(w => $"[green]{w.Id}[/] - [green]{w.Name}[/] - [green]{w.Job}[/]")
            .AddChoices(workers)
        );

        return selected;
    }

    public static async Task ShowShifts(List<Shift> shifts)
    {
        var table = new Table();
        table.Border(TableBorder.Rounded);
        table.AddColumn("[yellow]Start[/]");
        table.AddColumn("[blue]End[/]");
        table.AddColumn("[green]Type[/]");
        table.AddColumn("[cyan]Worker[/]");

        var apiService = new ApiService();

        foreach (var shift in shifts)
        {
            var worker = await apiService.GetWorkerByIdAsync(shift.WorkerId);

            table.AddRow(
                shift.Start.ToString("g"),
                shift.End.ToString("g"),
                shift.Type.ToString(),
                worker?.Name ?? "[Unknown]"
            );
        }

        AnsiConsole.Write(table);
    }
}
