using AkkaDddSandbox.Core.Interfaces;

namespace AkkaDddSandbox.Core.Commands
{
    public class UpdateTaskStatus : IDomainCommand
    {
        public UpdateTaskStatus(string newStatus)
        {
            NewStatus = newStatus;
        }

        public string NewStatus { get; }
    }
}