using AkkaDddSandbox.Core.Interfaces;

namespace AkkaDddSandbox.Core.Events
{
    public class TimeZoneUpdated : IDomainEvent
    {
        public TimeZoneUpdated(string updatedTimeZone)
        {
            UpdatedTimeZone = updatedTimeZone;
        }

        public string UpdatedTimeZone { get; }
    }
}