using AkkaDddSandbox.Core.Interfaces;
using AkkaDddSandbox.Core.Models;

namespace AkkaDddSandbox.Core.Commands
{
    public abstract class RespondentCommand : IDomainCommand
    {
        protected RespondentCommand(RespondentId id)
        {
            Id = id;
        }

        public RespondentId Id { get; }
        public AggregateId AggregateId => Id;
    }
}