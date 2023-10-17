namespace Hobbits.Services
{
    public class GuidIdGenerator : IRequestIdGenerator
    {
        public string RequestId { get; } = Guid.NewGuid().ToString();
    }
}
