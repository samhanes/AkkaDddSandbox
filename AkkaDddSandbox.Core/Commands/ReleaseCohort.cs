using AkkaDddSandbox.Core.Models;

namespace AkkaDddSandbox.Core.Commands
{
    public class ReleaseCohort : CohortCommand
    {
        public ReleaseCohort(CohortId id) : base(id)
        {
        }
    }
}