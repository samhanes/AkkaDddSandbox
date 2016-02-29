using AkkaDddSandbox.Core.Interfaces;
using AkkaDddSandbox.Core.Models;

namespace AkkaDddSandbox.Core.Events
{
    public class RespondentTimeZoneUpdated : IDomainEvent
    {
        public RespondentTimeZoneUpdated(RespondentId id, string updatedTimeZone)
        {
            Id = id;
            UpdatedTimeZone = updatedTimeZone;
        }

        public RespondentId Id { get; }
        public string UpdatedTimeZone { get; }
    }
}