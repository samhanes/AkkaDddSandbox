using AkkaDddSandbox.Core.Models;

namespace AkkaDddSandbox.Core.Events
{
    public class RespondentAddedToCohort : CohortEvent
    {
        public RespondentAddedToCohort(RespondentId respondentId, bool isCohortReleased)
        {
            RespondentId = respondentId;
            IsCohortReleased = isCohortReleased;
        }

        public RespondentId RespondentId { get; }
        public bool IsCohortReleased { get; }
    }
}