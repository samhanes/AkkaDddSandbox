using AkkaDddSandbox.Core.Models;

namespace AkkaDddSandbox.Core.Commands
{
    public class AddRespondentToCohort : CohortCommand
    {
        public AddRespondentToCohort(CohortId id, RespondentId respondentId) : base(id)
        {
            RespondentId = respondentId;
        }

        public RespondentId RespondentId { get; }
    }
}