using AkkaDddSandbox.Core.Models;

namespace AkkaDddSandbox.Core.Interfaces
{
    public interface IDomainCommand : IDomainMessage
    {
        AggregateId AggregateId { get; }
    }
}