using AkkaDddSandbox.Core.Models;

namespace AkkaDddSandbox.Core.Commands
{
    public class UpdateTaskStatus : TaskCommand
    {
        public UpdateTaskStatus(TaskId id, string newStatus) : base(id)
        {
            NewStatus = newStatus;
        }

        public string NewStatus { get; }
    }
}