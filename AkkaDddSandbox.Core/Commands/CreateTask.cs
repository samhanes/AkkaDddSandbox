using AkkaDddSandbox.Core.Models;

namespace AkkaDddSandbox.Core.Commands
{
    public class CreateTask : TaskCommand
    {
        public CreateTask(TaskId id) : base(id)
        {
        }
    }
}