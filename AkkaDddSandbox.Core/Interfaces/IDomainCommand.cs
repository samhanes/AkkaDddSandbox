using AkkaDddSandbox.Core.Aggregates;
using AkkaDddSandbox.Core.Models;

namespace AkkaDddSandbox.Core.Interfaces
{
    public interface IDomainCommand<T> : IDomainMessage where T : AggregateRoot
    {
        AggregateId AggregateId { get; }
    }
}