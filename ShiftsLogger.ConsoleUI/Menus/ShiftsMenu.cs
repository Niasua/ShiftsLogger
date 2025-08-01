using ShiftsLogger.ConsoleUI.Models;
using ShiftsLogger.ConsoleUI.UI;
using Spectre.Console;

namespace ShiftsLogger.ConsoleUI.Menus;

public class ShiftsMenu
{
    public static ApiService ApiService { get; set; } = new();
    public static async Task Show()
    {
        bool exit = false;

        while (!exit)
        {
            Console.Clear();
            var option = AnsiConsole.Prompt(
                new SelectionPrompt<string>()
                .Title("[blue]Shifts Menu[/]")
                .AddChoices(new[]
                {
                    "Show All Shifts", "Show Shift by Worker ID", "Show Shift by ID" ,"Create Shift", "Edit Shift", "Remove Shift", "Back"
                }));

            switch (option)
            {
                case "Show All Shifts":

                    await ShowAllShifts();

                    break;

                case "Show Shift by Worker ID":

                    await ShowShiftByWorkerId();

                    break;

                case "Show Shift by ID":

                    await ShowShiftById();

                    break; 

                case "Create Shift":

                    await CreateShift();

                    break;

                case "Edit Shift":

                    await EditShift();

                    break;

                case "Remove Shift":

                    await RemoveShift();

                    break;

                case "Back":

                    exit = true;

                    break;
            }
        }
    }

    private static async Task ShowAllShifts()
    {
        Console.Clear();
        AnsiConsole.MarkupLine("[green]View Shifts\n[/]");

        var shifts = await ApiService.GetAllShiftsAsync();

        if (shifts == null)
        {
            AnsiConsole.MarkupLine("[red]The shifts could not be found.[/]");
        }
        else
        {
            await Display.ShowShifts(shifts);
        }

        AnsiConsole.MarkupLine("\n[grey]Press any key to go back...[/]");
        Console.ReadKey();

        Console.Clear();
    }
    private static async Task ShowShiftByWorkerId()
    {
        Console.Clear();
        AnsiConsole.MarkupLine("[green]View Worker's Shifts\n[/]");

        var workers = await ApiService.GetAllWorkersAsync();

        var worker = Display.PromptSelectWorker(workers);

        var shifts = await ApiService.GetShiftsByWorkerIdAsync(worker.Id);

        if (shifts == null || shifts.Count == 0)
        {
            AnsiConsole.MarkupLine("\n[red]The shifts could not be found.[/]");
        }
        else
        {
            await Display.ShowShifts(shifts);
        }

        AnsiConsole.MarkupLine("\n[grey]Press any key to go back...[/]");
        Console.ReadKey();

        Console.Clear();
    }
    private static async Task ShowShiftById()
    {
        Console.Clear();
        AnsiConsole.MarkupLine("[green]View Shift\n[/]");

        var id = AnsiConsole.Ask<int>("Type shift's [green]ID[/]: ");

        var shift = await ApiService.GetShiftByIdAsync(id);

        if (shift == null)
        {
            AnsiConsole.MarkupLine("\n[red]The shift could not be found.[/]");
        }
        else
        {
            await Display.ShowShift(shift);
        }

        AnsiConsole.MarkupLine("\n[grey]Press any key to go back...[/]");
        Console.ReadKey();

        Console.Clear();
    }
    private static async Task CreateShift()
    {
        Console.Clear();
        AnsiConsole.MarkupLine("[green]Create Shift\n[/]");

        DateTime start, end;

        while(true)
        {
            AnsiConsole.MarkupLine("[green]Shift start:[/]");
            start = Display.PromptSelectDateTime();
            AnsiConsole.MarkupLine($"\n[green]You've typed {start:g}[/]\n");

            AnsiConsole.MarkupLine("[green]Shift end:[/]");
            end = Display.PromptSelectDateTime();
            AnsiConsole.MarkupLine($"\n[green]You've typed {end:g}[/]\n");

            if (end <= start)
            {
                AnsiConsole.MarkupLine("[red]End time must be after start time. Try again.[/]\n");
            }
            else
            {
                break;
            }
        }

        var type = AnsiConsole.Prompt(
            new SelectionPrompt<ShiftType>()
            .Title("\nSelect type:")
            .AddChoices(Enum.GetValues<ShiftType>())
            );

        var workers = await ApiService.GetAllWorkersAsync();
        var worker = Display.PromptSelectWorker(workers);

        var created = await ApiService.CreateShiftAsync(new Shift { Start = start, End = end, Type = type, WorkerId = worker.Id });

        if (created == null)
        {
            AnsiConsole.MarkupLine("\n[red]Shift creation was not possible.[/]");
        }
        else
        {
            AnsiConsole.MarkupLine("\n[green]Shift was successfully created.[/]");
        }

        AnsiConsole.MarkupLine("\n[grey]Press any key to go back...[/]");
        Console.ReadKey();

        Console.Clear();
    }
    private static async Task EditShift()
    {
        throw new NotImplementedException();
    }
    private static async Task RemoveShift()
    {
        throw new NotImplementedException();
    }
}
