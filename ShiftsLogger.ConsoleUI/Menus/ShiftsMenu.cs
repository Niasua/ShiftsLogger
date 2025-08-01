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
        throw new NotImplementedException();
    }
    private static async Task ShowShiftById()
    {
        throw new NotImplementedException();
    }
    private static async Task CreateShift()
    {
        throw new NotImplementedException();
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
