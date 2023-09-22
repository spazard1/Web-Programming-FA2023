using System.Diagnostics;

namespace Hobbits.Services
{
    public class HobbitLogger
    {
        private readonly IRequestIdGenerator requestIdGenerator;
        private readonly TimeOfDayGenerator timeOfDayGenerator;

        public HobbitLogger(IRequestIdGenerator requestIdGenerator, TimeOfDayGenerator timeOfDayGenerator)
        {
            this.requestIdGenerator = requestIdGenerator;
            this.timeOfDayGenerator = timeOfDayGenerator;
        }

        public void Log(string message) { 
            Debug.WriteLine(message + " " + requestIdGenerator.RequestId + " " + timeOfDayGenerator.Current);
        }
    }
}
