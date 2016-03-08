using AkkaDddSandbox.Core.Models;

namespace AkkaDddSandbox.Core.Events
{
    public class CohortCreated : CohortEvent
    {
        public CohortCreated(CohortId id)
        {
            Id = id;
        }

        public CohortId Id { get; }
    }
}