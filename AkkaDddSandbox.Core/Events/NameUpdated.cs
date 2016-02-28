using AkkaDddSandbox.Core.Interfaces;

namespace AkkaDddSandbox.Core.Events
{
    public class NameUpdated : IDomainEvent
    {
        public NameUpdated(string updatedFirst, string updatedLast)
        {
            UpdatedFirst = updatedFirst;
            UpdatedLast = updatedLast;
        }

        public string UpdatedFirst { get; }
        public string UpdatedLast { get; }
    }
}