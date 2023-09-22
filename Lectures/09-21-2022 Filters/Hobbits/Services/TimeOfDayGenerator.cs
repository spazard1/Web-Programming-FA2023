namespace Hobbits.Services
{
    public class TimeOfDayGenerator
    {
        public DateTime Current { get; } = DateTime.UtcNow;
    }
}
