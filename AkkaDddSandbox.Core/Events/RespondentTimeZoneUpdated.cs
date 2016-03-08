using AkkaDddSandbox.Core.Models;

namespace AkkaDddSandbox.Core.Events
{
    public class RespondentTimeZoneUpdated : RespondentEvent
    {
        public RespondentTimeZoneUpdated(RespondentId id, string updatedTimeZone) : base(id)
        {
            UpdatedTimeZone = updatedTimeZone;
        }

        public string UpdatedTimeZone { get; }
    }
}