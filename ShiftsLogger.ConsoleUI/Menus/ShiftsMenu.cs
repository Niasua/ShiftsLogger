using ShiftsLogger.ConsoleUI.UI;
using Spectre.Console;

namespace ShiftsLogger.ConsoleUI.Menus;

public class ShiftsMenu
{
    public static ApiService ApiService { get; set; } = new();
    public static void Show()
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
                    "Show All Shifts", "Show Shift by Worker ID", "Show Shift by ID" ,"Create Shift", "Edit Shift", "Remove Shift", "Exit"
                }));

            switch (option)
            {
                case "Show All Shifts":

                    ShowAllShifts();

                    break;

                case "Show Shift by Worker ID":

                    ShowShiftByWorkerId();

                    break;

                case "Show Shift by ID":

                    ShowShiftById();


                    break; 

                case "Create Shift":

                    CreateShift();

                    break;

                case "Edit Shift":

                    EditShift();

                    break;

                case "Remove Shift":

                    RemoveShift();

                    break;

                case "Exit":

                    exit = true;

                    break;
            }
        }
    }

    private static void RemoveShift()
    {
        throw new NotImplementedException();
    }

    private static void EditShift()
    {
        throw new NotImplementedException();
    }

    private static void CreateShift()
    {
        throw new NotImplementedException();
    }

    private static void ShowShiftById()
    {
        throw new NotImplementedException();
    }

    private static void ShowShiftByWorkerId()
    {
        throw new NotImplementedException();
    }

    private static void ShowAllShifts()
    {
        throw new NotImplementedException();
    }

    private async static void ShowAllWorkers()
    {
        while (true)
        {
            Console.Clear();
            AnsiConsole.MarkupLine("[green]View Workers[/]");

            var workers = await ApiService.GetAllWorkersAsync();

            if (workers == null)
            {
                AnsiConsole.MarkupLine("[red]The workers could not be found.[/]");
                AnsiConsole.MarkupLine("[grey]Press any key to go back...[/]");
                Console.ReadKey();
                break;
            }

            Display.ShowWorkers(workers);

            AnsiConsole.MarkupLine("[grey]Press any key to go back...[/]");
            Console.ReadKey();
            break;
        }
    }
    private static void ShowWorkerById()
    {
        throw new NotImplementedException();
    }
    private static void CreateWorker()
    {
        throw new NotImplementedException();
    }
    private static void EditWorker()
    {
        throw new NotImplementedException();
    }
    private static void RemoveWorker()
    {
        throw new NotImplementedException();
    }
}
