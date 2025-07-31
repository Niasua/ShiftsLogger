using ShiftsLogger.ConsoleUI.UI;
using Spectre.Console;

namespace ShiftsLogger.ConsoleUI.Menus;

public class WorkersMenu
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
                .Title("[blue]Workers Menu[/]")
                .AddChoices(new[]
                {
                    "Show All Workers", "Show Worker by ID", "Create Worker", "Edit Worker", "Remove Worker", "Exit"
                }));

            switch (option)
            {
                case "Show All Workers":

                    await ShowAllWorkers();

                    break;

                case "Show Worker by ID":

                    ShowWorkerById();

                    break;

                case "Create Worker":

                    CreateWorker();

                    break;

                case "Edit Worker":

                    EditWorker();

                    break;

                case "Remove Worker":

                    RemoveWorker();

                    break;

                case "Exit":

                    exit = true;

                    break;
            }
        }
    }

    private async static Task ShowAllWorkers()
    {
        while (true)
        {
            Console.Clear();
            AnsiConsole.MarkupLine("[green]View Workers\n[/]");

            var workers = await ApiService.GetAllWorkersAsync();

            if (workers == null)
            {
                AnsiConsole.MarkupLine("[red]The workers could not be found.[/]");
                AnsiConsole.MarkupLine("[grey]Press any key to go back...[/]");
                Console.ReadKey();
                break;
            }

            Display.ShowWorkers(workers);

            AnsiConsole.MarkupLine("\n[grey]Press any key to go back...[/]");
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
