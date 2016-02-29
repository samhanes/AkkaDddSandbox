namespace AkkaDddSandbox.Core.Models
{
    public abstract class AggregateId
    {
        public abstract string ToPersistenceId();
    }
}