namespace Hobbits.Services
{
    public class NumberIdGenerator : IRequestIdGenerator
    {
        private static int Current;

        public string RequestId { get; } = Current++.ToString();
    }
}
