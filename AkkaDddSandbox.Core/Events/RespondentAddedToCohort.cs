using AkkaDddSandbox.Core.Interfaces;
using AkkaDddSandbox.Core.Models;

namespace AkkaDddSandbox.Core.Events
{
    public class RespondentAddedToCohort : IDomainEvent
    {
        public RespondentAddedToCohort(RespondentId respondentId)
        {
            RespondentId = respondentId;
        }

        public RespondentId RespondentId { get; }
    }
}