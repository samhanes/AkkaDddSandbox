using AkkaDddSandbox.Core.Interfaces;
using AkkaDddSandbox.Core.Models;

namespace AkkaDddSandbox.Core.Events
{
    public class RespondentNameUpdated : IDomainEvent
    {
        public RespondentNameUpdated(RespondentId id, string updatedFirst, string updatedLast)
        {
            UpdatedFirst = updatedFirst;
            UpdatedLast = updatedLast;
            Id = id;
        }

        public RespondentId Id { get; }
        public string UpdatedFirst { get; }
        public string UpdatedLast { get; }
    }
}