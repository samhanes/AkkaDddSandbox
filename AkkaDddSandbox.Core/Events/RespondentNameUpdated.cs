using AkkaDddSandbox.Core.Models;

namespace AkkaDddSandbox.Core.Events
{
    public class RespondentNameUpdated : RespondentEvent
    {
        public RespondentNameUpdated(RespondentId id, string updatedFirst, string updatedLast) : base(id)
        {
            UpdatedFirst = updatedFirst;
            UpdatedLast = updatedLast;
        }

        public string UpdatedFirst { get; }
        public string UpdatedLast { get; }
    }
}