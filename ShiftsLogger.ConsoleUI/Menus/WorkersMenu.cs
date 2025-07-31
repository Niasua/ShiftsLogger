using ShiftsLogger.ConsoleUI.Models;
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

                    await ShowWorkerById();

                    break;

                case "Create Worker":

                    await CreateWorker();

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
            }
            else
            {
                Display.ShowWorkers(workers);
            }

            AnsiConsole.MarkupLine("\n[grey]Press any key to go back...[/]");
            Console.ReadKey();

            Console.Clear();
            break;
        }
    }
    private static async Task ShowWorkerById()
    {
        while (true)
        {
            Console.Clear();
            AnsiConsole.MarkupLine("[green]View Worker\n[/]");

            var workerId = AnsiConsole.Ask<int>("Type worker's [green]ID[/]: ");

            var worker = await ApiService.GetWorkerByIdAsync(workerId);

            if (worker == null)
            {
                AnsiConsole.MarkupLine("[red]The worker could not be found.[/]");
            }
            else
            {
                Display.ShowWorker(worker);
            }

            AnsiConsole.MarkupLine("\n[grey]Press any key to go back...[/]");
            Console.ReadKey();

            Console.Clear();
            break;
        }
    }
    private static async Task CreateWorker()
    {
        while (true)
        {
            Console.Clear();
            AnsiConsole.MarkupLine("[green]Create Worker\n[/]");

            var name = AnsiConsole.Ask<string>("Type worker's [green]Name[/]: ");
            var job = AnsiConsole.Ask<string>("Type worker's [green]Job[/]: ");

            var worker = await ApiService.CreateWorkerAsync(new Worker { Name = name, Job = job });

            if (worker == null)
            {
                AnsiConsole.MarkupLine("\n[red]Worker creation was not posible.[/]");
            }
            else
            {
                AnsiConsole.MarkupLine("\n[green]Worker was successfully created.[/]");
            }

            AnsiConsole.MarkupLine("\n[grey]Press any key to go back...[/]");
            Console.ReadKey();

            Console.Clear();
            break;
        }
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
