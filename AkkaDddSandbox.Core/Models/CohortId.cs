namespace AkkaDddSandbox.Core.Models
{
    public class CohortId : AggregateId
    {
        public CohortId(string id)
        {
            Id = id;
        }

        public string Id { get; }

        public override string ToString()
        {
            return Id;
        }
    }
}