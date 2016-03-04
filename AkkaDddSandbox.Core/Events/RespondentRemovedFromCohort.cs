using AkkaDddSandbox.Core.Interfaces;
using AkkaDddSandbox.Core.Models;

namespace AkkaDddSandbox.Core.Events
{
    public class RespondentRemovedFromCohort : IDomainEvent
    {
        public RespondentRemovedFromCohort(RespondentId respondentId)
        {
            RespondentId = respondentId;
        }

        public RespondentId RespondentId { get; }
    }
}