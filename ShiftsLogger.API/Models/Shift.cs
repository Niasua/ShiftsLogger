namespace ShiftsLogger.API.Models;

public class Shift
{
    public int Id { get; set; }
    public DateTime Start { get; set; }
    public DateTime End { get; set; }
    public ShiftType Type { get; set; }
    public int WorkerId { get; set; }
    public Worker Worker { get; set; } = null!;
}
