using AkkaDddSandbox.Core.Models;

namespace AkkaDddSandbox.Core.Events
{
    public class RespondentRemovedFromCohort : CohortEvent
    {
        public RespondentRemovedFromCohort(RespondentId respondentId)
        {
            RespondentId = respondentId;
        }

        public RespondentId RespondentId { get; }
    }
}