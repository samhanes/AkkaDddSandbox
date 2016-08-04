using AkkaDddSandbox.Core.Models;

namespace AkkaDddSandbox.Core.Commands
{
    public class RemoveRespondentFromCohort : CohortCommand
    {
        public RemoveRespondentFromCohort(CohortId id, RespondentId respondentId)
            :base(id)
        {
            RespondentId = respondentId;
        }
        
        public RespondentId RespondentId { get; }
    }
}